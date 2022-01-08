using System;
using System.IO;
using Microsoft.ML;
using System.Collections.Generic;

namespace Detekcja
{

    /*
     Linki:
    https://docs.microsoft.com/pl-pl/dotnet/machine-learning/
    https://docs.microsoft.com/pl-pl/dotnet/machine-learning/tutorials/sales-anomaly-detection
     */
    class Program
    {
        /// <summary>
        /// Zmienna zawierająca ścieżkę do pliku z danymi.
        /// W tym przypadku katalog Data w katalogu Moje dokumenty.
        /// Zmieniamy nazwę pliku, który ma zostać przeanalizowany.
        /// </summary>
              
        
        static readonly string _dataPath= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data", "product-sales.csv");
        ///static readonly string _dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data", "nyc_taxi.csv");
        //static readonly string _dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data", "speed_7578.csv");
        //static readonly string _dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data", "Twitter_volume_GOOG.csv");

        /// <summary>
        /// Zmienna reprezentująca liczbę rekordów w pliku z danymi
        /// </summary>
        
        /// Sprzedaż
        const int _docsize = 36;
      
        ///Taxi
        ///const int _docsize = 10320;

        ///Speed
        //const int _docsize = 10320;
        static void Main(string[] args)
        {                     
            // Obiekt klasy MLContext 
            MLContext mlContext = new MLContext();

            // Krok 1-Ładuje dane z pliku tekstowego
            // Jest to interfejs opisujący dane tabelaryczne
            // Czy ma nagłówek oraz znak separatora
            // LoadFromTextFile-> definiuje schemat danych, odczytuje go w pliku i zwraca jako obiekt IDataView
            IDataView dataView = mlContext.Data.LoadFromTextFile<DetekcjaAnomalii>(path: _dataPath, hasHeader: true, separatorChar: ',');
            
            // Wywouje metodę wykrywającą wzorzec tymczasowych zmian.
            DetectSpike(mlContext, _docsize, dataView);

            // Changepoint detects pattern persistent changes
            DetectChangepoint(mlContext, _docsize, dataView);
        }

        /// <summary>
        /// Metoda tworzy przekształcenie estymatora, wykrywa skoki i wyświetla wyniki
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="docSize"></param>
        /// <param name="productSales"></param>
        static void DetectSpike(MLContext mlContext, int docSize, IDataView productSales)
        {
            Console.WriteLine("Wykrywa wzorzec tymczasowych zmian");

            /*
            Krok 2: Ustawia algorytm treningowy
            Trenuje model do wykrewania skoków

            Parametry confidence i mają wpływ na sposób wykrycia pvalueHistoryLength wzrostów. 
            confidence określa, jak wrażliwy jest model na skoki. 
            Im mniejsza pewność, tym większe prawdopodobieństwo, że algorytm wykryje "mniejsze" wzrosty. 
            Parametr pvalueHistoryLength definiuje liczbę punktów danych w oknie przesuwanym. 
            Wartość tego parametru jest zwykle procentem całego zestawu danych. 
            Im niższe wartości pvalueHistoryLength, tym szybciej model zapomni o poprzednich dużych skokach.
             */
            var iidSpikeEstimator = mlContext.Transforms.DetectIidSpike(outputColumnName: nameof(Predykcja.Prediction), inputColumnName: nameof(DetekcjaAnomalii.value), confidence: 95, pvalueHistoryLength: docSize / 4);

            // Krok 3: Tworzy przekształcenie wykrywania skoków
            Console.WriteLine("=============== Model treningowy ===============");
            ITransformer iidSpikeTransform = iidSpikeEstimator.Fit(CreateEmptyDataView(mlContext));

            Console.WriteLine("=============== Koniec procesu treningowego ===============");
            // Stosuje transformację danych w celu utworzenia prognozy
            // Metoda transform() służy do tworzzenia prognoz dla wielu wierszy wejściowych danych
            IDataView transformedData = iidSpikeTransform.Transform(productSales);
            
            var predictions = mlContext.Data.CreateEnumerable<Predykcja>(transformedData, reuseRowObject: false);

            /*
            Tworzy nagłówek
            Alert wskazuje alert o skoku dla danego punktu danych.
            Score to wartość ProductSales dla danego punktu danych w zestawie danych.
            Wartość P „P” oznacza prawdopodobieństwo. 
            Im wartość p jest bliższa 0, tym bardziej prawdopodobne jest, że punkt danych jest anomalią.
            */
            Console.WriteLine("Alert\tScore\tP-Value");

            // Dla każdego p w predictions wyświetla wyniki
            // Zmienna dla oznaczenia numeru wiersza.
            int i = 0;
            foreach (var p in predictions)
            {
                i++;
                var results = $"{p.Prediction[0]}\t{p.Prediction[1]:f2}\t{p.Prediction[2]:F2}";

                if (p.Prediction[0] == 1)
                {
                    results += " <-- Wykryto anomalię";
                    Console.WriteLine(i+": "+results);
                }
                //Console.WriteLine(results);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Metoda wykrywająca punkty zmian.
        /// Punkty zmiany to trwałe zmiany w rozkładzie wartości strumienia zdarzeń szeregów czasowych, takie jak zmiany poziomu i trendy. 
        /// Te trwałe zmiany trwają znacznie dłużej niż skoki i mogą wskazywać na katastrofalne zdarzenia. 
        /// Punkty zmiany zwykle nie są widoczne gołym okiem, ale można je wykryć w danych za pomocą podejść, takich jak poniższa metoda.
        /// Metoda DetectChangepoint() wykonuje następujące zadania:
        /// Tworzy transformację z estymatora.
        /// Wykrywa punkty zmiany na podstawie historycznych danych sprzedaży.
        /// Wyświetla wyniki.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="docSize"></param>
        /// <param name="productSales"></param>
        static void DetectChangepoint(MLContext mlContext, int docSize, IDataView productSales)
        {
            Console.WriteLine("Wykrywa trwałe zmiany.");
            /*
            Krok 2: Ustawia algorytm treningowy.

            Wykrywanie punktów zmiany odbywa się z niewielkim opóźnieniem, ponieważ model musi upewnić się, że 
            bieżące odchylenie jest trwałą zmianą, a nie tylko przypadkowymi skokami przed utworzeniem alertu. 
            Wielkość tego opóźnienia jest równa parametrowi changeHistoryLength. 
            Zwiększając wartość tego parametru, wykrywanie zmian ostrzega o bardziej trwałych zmianach, 
            ale kompromisem byłoby dłuższe opóźnienie.
             */
            var iidChangePointEstimator = mlContext.Transforms.DetectIidChangePoint(outputColumnName: nameof(Predykcja.Prediction), inputColumnName: nameof(DetekcjaAnomalii.value), confidence: 95, changeHistoryLength: docSize / 4);

            //STEP 3: Tworzy przekształcenie danych
            Console.WriteLine("=============== Uczenie modelu za pomocą algorytmu wykrywania punktów zmian===============");
        
            var iidChangePointTransform = iidChangePointEstimator.Fit(CreateEmptyDataView(mlContext));
           
            Console.WriteLine("=============== Koniec procesu trenowania ===============");

            //Stosuje transformację danych, aby utworzyć prognozy.
            IDataView transformedData = iidChangePointTransform.Transform(productSales);

            var predictions = mlContext.Data.CreateEnumerable<Predykcja>(transformedData, reuseRowObject: false);

            // Tworzy nagłówek
            /*
             Alert wskazuje alert punktu zmiany dla danego punktu danych.
             Score to wartość ProductSales dla danego punktu danych w zestawie danych.
             Wartość P „P” oznacza prawdopodobieństwo. Im wartość P jest bliższa 0, tym bardziej prawdopodobne jest, że punkt danych jest anomalią.
             Wartość Martingale służy do określenia, jak „dziwny” jest punkt danych, na podstawie sekwencji wartości P.
             */
            Console.WriteLine("Alert\tScore\tP-Value\tMartingale value");

            // Dla każdego p w predictions wyświetla wyniki
            // Zmienna dla oznaczenia numeru wiersza
            int j =0;
            foreach (var p in predictions)
            {
                j++;
                var results = $"{p.Prediction[0]}\t{p.Prediction[1]:f2}\t{p.Prediction[2]:F2}\t{p.Prediction[3]:F2}";

                if (p.Prediction[0] == 1)
                {
                    results += " <-- alert, przewidywany punkt zmiany";
                    Console.WriteLine(j + ": " + results);
                }
                //Console.WriteLine(results);
            }
            Console.WriteLine("");
            Console.ReadKey();
    
        }

        /// <summary>
        /// Metoda tworząca pusty widok danych w celu wywołania metody fit() w:
        /// ITransformer iidSpikeTransform = iidSpikeEstimator.Fit(CreateEmptyDataView(mlContext));
        /// dla przekształceń 
        /// szeregów czasowych.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        static IDataView CreateEmptyDataView(MLContext mlContext)
        {
            IEnumerable<DetekcjaAnomalii> enumerableData = new List<DetekcjaAnomalii>();
            return mlContext.Data.LoadFromEnumerable(enumerableData);
        }
        
    }
}
