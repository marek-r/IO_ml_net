
## Cel zadania
Zastosowanie uczenia maszynowego do wykrywania anomalii na podstawie platformy ML.NET.
Program został napisany w języku c# na podstawie samouczków Microsoft ze względu na dostęp do obszernej dokumentacji.

## Źródło danych
[NAB Data Corpus](https://github.com/numenta/NAB/tree/master/data)

## Jakie dane zawiera każda kolumna zbioru danych?
**1. nyc\_taxi.csv- data i czas | liczba pasażerów taksówek w Nowym Yorku**<p> 
Liczba pasażerów taksówek w Nowym Jorku, gdzie pięć anomalii występuje podczas maratonu w Nowym Jorku, Święta Dziękczynienia, Bożego Narodzenia, Nowego Roku i burzy śnieżnej. Surowe dane pochodzą z NYC Taxi and Limousine Commission. Zawarty tutaj plik danych składa się z agregacji całkowitej liczby pasażerów taksówek w przedziałach 30-minutowych.</p>

**2. realTraffic speed\_7578.csv - data i czas | prędkość**<p> 
Dane o ruchu drogowym w czasie rzeczywistym z obszaru Twin Cities Metro w Minnesocie, zebrane przez Departament Transportu Minnesoty. Uwzględnione dane obejmują prędkość.</p>

**3. realTweets Twitter\_volume\_GOOG.csv- data i czas | liczba wzmianek**<p> 
Zbiór wzmianek na Twitterze o dużych firmach notowanych na giełdzie, takich jak Google i IBM. Wartość reprezentuje liczbę wzmianek dla danego symbolu giełdowego co 5 minut.</p>

## Wnioski i podsumowanie (analiza otrzymanych wyników)
1. Lista wykrytych anomalii dla danych z pliku nyc\_taxi.csv (Numer wiersza, liczba pasażerów, wartość p)
</p><p>Testując różne ustawienia w przypadku wykrywania anomalii dla liczby pasażerów taksówek w Nowym Jorku udało się wykryć anomalię pokrywającą się z datami w opisie danych:
    </p>
    
    373: 1  23875.00        0.06 <-- Wykryto anomalię
    374: 1  25290.00        0.04 <-- Wykryto anomalię
    375: 1  25510.00        0.04 <-- Wykryto anomalię
    376: 1  24535.00        0.06 <-- Wykryto anomalię
    381: 1  25209.00        0.06 <-- Wykryto anomalię
    5955: 1 39197.00        0.01 <-- Wykryto anomalię 2014-11-02 Maraton
    5956: 1 35212.00        0.04 <-- Wykryto anomalię 2014-11-02 Maraton
    8825: 1 25524.00        0.05 <-- Wykryto anomalię 2014-12-31 Sylwester
    8826: 1 26779.00        0.04 <-- Wykryto anomalię 2014-12-31 Sylwester
    8827: 1 27804.00        0.03 <-- Wykryto anomalię 2014-12-31 Sylwester
    8828: 1 27315.00        0.04 <-- Wykryto anomalię 2014-12-31 Sylwester
    8834: 1 29547.00        0.03 <-- Wykryto anomalię 2015-01-01 Nowy Rok
    8835: 1 30236.00        0.02 <-- Wykryto anomalię 2015-01-01 Nowy Rok
    8836: 1 28348.00        0.05 <-- Wykryto anomalię 2015-01-01 Nowy Rok
    10263: 1        27289.00        0.06 <-- Wykryto anomalię
    10264: 1        28107.00        0.05 <-- Wykryto anomalię

2. Lista wykrytych anomalii  dla danych z pliku speed\_7578.csv (Numer wiersza, prędkość, wartość p):
</p><p>Wykryte wiersze mogą wskazywać na korki lub większą przepustowość ruchu niż zwykle, niestety w źródle danych nie wskazano rekordów które są zweryfikowanymi anomaliami.</p>

    48: 1   71.00   0.05 <-- Wykryto anomalię
    51: 1   62.00   0.05 <-- Wykryto anomalię
    53: 1   59.00   0.01 <-- Wykryto anomalię
    55: 1   58.00   0.02 <-- Wykryto anomalię
    61: 1   57.00   0.05 <-- Wykryto anomalię
    72: 1   73.00   0.05 <-- Wykryto anomalię
    73: 1   77.00   0.02 <-- Wykryto anomalię
    98: 1   79.00   0.01 <-- Wykryto anomalię
    113: 1  55.00   0.01 <-- Wykryto anomalię
    114: 1  48.00   0.00 <-- Wykryto anomalię
    118: 1  43.00   0.02 <-- Wykryto anomalię
    141: 1  55.00   0.04 <-- Wykryto anomalię
    151: 1  73.00   0.02 <-- Wykryto anomalię
    158: 1  75.00   0.02 <-- Wykryto anomalię
    196: 1  76.00   0.01 <-- Wykryto anomalię
    222: 1  62.00   0.05 <-- Wykryto anomalię
    231: 1  71.00   0.06 <-- Wykryto anomalię
    242: 1  56.00   0.00 <-- Wykryto anomalię
    276: 1  60.00   0.02 <-- Wykryto anomalię
    277: 1  81.00   0.00 <-- Wykryto anomalię
    307: 1  62.00   0.01 <-- Wykryto anomalię
    309: 1  60.00   0.01 <-- Wykryto anomalię
    314: 1  60.00   0.04 <-- Wykryto anomalię
    317: 1  59.00   0.04 <-- Wykryto anomalię
    318: 1  23.00   0.00 <-- Wykryto anomalię
    349: 1  61.00   0.06 <-- Wykryto anomalię
    350: 1  58.00   0.02 <-- Wykryto anomalię
    359: 1  56.00   0.04 <-- Wykryto anomalię
    360: 1  47.00   0.00 <-- Wykryto anomalię
    364: 1  79.00   0.00 <-- Wykryto anomalię
    368: 1  78.00   0.03 <-- Wykryto anomalię
    400: 1  62.00   0.05 <-- Wykryto anomalię
    436: 1  62.00   0.03 <-- Wykryto anomalię
    440: 1  60.00   0.02 <-- Wykryto anomalię
    460: 1  76.00   0.06 <-- Wykryto anomalię
    489: 1  59.00   0.00 <-- Wykryto anomalię
    497: 1  72.00   0.05 <-- Wykryto anomalię
    503: 1  74.00   0.02 <-- Wykryto anomalię
    526: 1  56.00   0.00 <-- Wykryto anomalię
    533: 1  55.00   0.02 <-- Wykryto anomalię
    534: 1  75.00   0.05 <-- Wykryto anomalię
    596: 1  59.00   0.03 <-- Wykryto anomalię
    597: 1  57.00   0.03 <-- Wykryto anomalię
    624: 1  59.00   0.01 <-- Wykryto anomalię
    625: 1  36.00   0.00 <-- Wykryto anomalię
    626: 1  21.00   0.00 <-- Wykryto anomalię
    657: 1  72.00   0.05 <-- Wykryto anomalię
    664: 1  74.00   0.02 <-- Wykryto anomalię
    674: 1  90.00   0.00 <-- Wykryto anomalię
    711: 1  74.00   0.03 <-- Wykryto anomalię
    734: 1  72.00   0.04 <-- Wykryto anomalię
    738: 1  74.00   0.03 <-- Wykryto anomalię
    747: 1  56.00   0.04 <-- Wykryto anomalię
    748: 1  49.00   0.00 <-- Wykryto anomalię
    749: 1  43.00   0.01 <-- Wykryto anomalię
    752: 1  42.00   0.04 <-- Wykryto anomalię
    753: 1  25.00   0.00 <-- Wykryto anomalię
    754: 1  10.00   0.00 <-- Wykryto anomalię
    755: 1  8.00    0.03 <-- Wykryto anomalię
    784: 1  57.00   0.00 <-- Wykryto anomalię
    785: 1  52.00   0.00 <-- Wykryto anomalię
    786: 1  51.00   0.02 <-- Wykryto anomalię
    811: 1  59.00   0.05 <-- Wykryto anomalię
    841: 1  69.00   0.05 <-- Wykryto anomalię
    854: 1  71.00   0.05 <-- Wykryto anomalię
    876: 1  61.00   0.04 <-- Wykryto anomalię
    882: 1  59.00   0.03 <-- Wykryto anomalię
    894: 1  56.00   0.02 <-- Wykryto anomalię
    917: 1  51.00   0.00 <-- Wykryto anomalię
    918: 1  50.00   0.02 <-- Wykryto anomalię
    919: 1  34.00   0.00 <-- Wykryto anomalię
    920: 1  24.00   0.01 <-- Wykryto anomalię
    921: 1  7.00    0.00 <-- Wykryto anomalię
    922: 1  14.00   0.05 <-- Wykryto anomalię
    923: 1  7.00    0.05 <-- Wykryto anomalię
    954: 1  55.00   0.03 <-- Wykryto anomalię
    955: 1  30.00   0.00 <-- Wykryto anomalię
    956: 1  11.00   0.00 <-- Wykryto anomalię
    957: 1  12.00   0.03 <-- Wykryto anomalię
    960: 1  1.00    0.03 <-- Wykryto anomalię
    999: 1  59.00   0.05 <-- Wykryto anomalię
    1000: 1 56.00   0.01 <-- Wykryto anomalię
    1005: 1 57.00   0.05 <-- Wykryto anomalię
    1026: 1 53.00   0.04 <-- Wykryto anomalię
    1034: 1 73.00   0.00 <-- Wykryto anomalię
    1039: 1 72.00   0.05 <-- Wykryto anomalię
    1047: 1 38.00   0.00 <-- Wykryto anomalię
    1077: 1 69.00   0.06 <-- Wykryto anomalię
    1081: 1 71.00   0.04 <-- Wykryto anomalię
    1092: 1 55.00   0.01 <-- Wykryto anomalię
    1115: 1 56.00   0.02 <-- Wykryto anomalię
    1116: 1 41.00   0.00 <-- Wykryto anomalię
    1118: 1 46.00   0.04 <-- Wykryto anomalię
    1123: 1 33.00   0.02 <-- Wykryto anomalię
    1124: 1 23.00   0.01 <-- Wykryto anomalię
    1125: 1 26.00   0.05 <-- Wykryto anomalię
    1126: 1 19.00   0.04 <-- Wykryto anomalię

3. Lista wykrytych anomalii dla danych z pliku Twitter_volume_GOOG.csv (Numer wiersza, prędkość, wartość p):
</p><p>Wykryte wiersze mogą wskazywać na pojawienie interesujących faktów, które są odzwierciedlone w komentarzach, niestety w źródle danych nie wskazano rekordów które są zweryfikowanymi anomaliami.</p>
    
    7999: 1 93.00   0.01 <-- Wykryto anomalię
    8026: 1 88.00   0.01 <-- Wykryto anomalię
    8435: 1 115.00  0.00 <-- Wykryto anomalię
    8436: 1 110.00  0.00 <-- Wykryto anomalię
    8437: 1 105.00  0.00 <-- Wykryto anomalię
    8441: 1 109.00  0.00 <-- Wykryto anomalię
    8446: 1 115.00  0.00 <-- Wykryto anomalię
    8447: 1 152.00  0.00 <-- Wykryto anomalię
    8448: 1 174.00  0.00 <-- Wykryto anomalię
    8449: 1 154.00  0.00 <-- Wykryto anomalię
    8450: 1 199.00  0.00 <-- Wykryto anomalię
    8451: 1 123.00  0.00 <-- Wykryto anomalię
    8452: 1 204.00  0.00 <-- Wykryto anomalię
    9021: 1 98.00   0.01 <-- Wykryto anomalię
    9502: 1 101.00  0.01 <-- Wykryto anomalię
    9546: 1 93.00   0.01 <-- Wykryto anomalię
    9580: 1 187.00  0.00 <-- Wykryto anomalię
    9581: 1 244.00  0.00 <-- Wykryto anomalię
    9582: 1 179.00  0.00 <-- Wykryto anomalię
    9583: 1 121.00  0.00 <-- Wykryto anomalię
    9584: 1 136.00  0.00 <-- Wykryto anomalię
    9585: 1 112.00  0.01 <-- Wykryto anomalię
    9586: 1 100.00  0.01 <-- Wykryto anomalię
    9587: 1 103.00  0.01 <-- Wykryto anomalię
    9588: 1 98.00   0.01 <-- Wykryto anomalię
    9589: 1 100.00  0.01 <-- Wykryto anomalię
    9602: 1 110.00  0.01 <-- Wykryto anomalię
    9603: 1 215.00  0.00 <-- Wykryto anomalię
    9611: 1 134.00  0.00 <-- Wykryto anomalię
    9612: 1 206.00  0.00 <-- Wykryto anomalię
    9613: 1 156.00  0.00 <-- Wykryto anomalię
    9614: 1 140.00  0.00 <-- Wykryto anomalię
    9615: 1 105.00  0.01 <-- Wykryto anomalię
    9619: 1 99.00   0.01 <-- Wykryto anomalię
    9701: 1 100.00  0.01 <-- Wykryto anomalię
    9763: 1 218.00  0.00 <-- Wykryto anomalię
    9764: 1 465.00  0.00 <-- Wykryto anomalię
    9765: 1 174.00  0.00 <-- Wykryto anomalię
    9766: 1 172.00  0.00 <-- Wykryto anomalię
    9768: 1 103.00  0.01 <-- Wykryto anomalię
    9786: 1 238.00  0.00 <-- Wykryto anomalię
    9787: 1 160.00  0.00 <-- Wykryto anomalię
    10874: 1        113.00  0.01 <-- Wykryto anomalię
    10875: 1        201.00  0.00 <-- Wykryto anomalię
    10876: 1        161.00  0.00 <-- Wykryto anomalię
    11197: 1        111.00  0.01 <-- Wykryto anomalię
    11198: 1        120.00  0.01 <-- Wykryto anomalię
    11221: 1        105.00  0.01 <-- Wykryto anomalię
    13524: 1        101.00  0.01 <-- Wykryto anomalię
    13686: 1        92.00   0.01 <-- Wykryto anomalię
    14246: 1        132.00  0.00 <-- Wykryto anomalię
    14258: 1        130.00  0.00 <-- Wykryto anomalię
    15520: 1        119.00  0.00 <-- Wykryto anomalię
    15531: 1        93.00   0.01 <-- Wykryto anomalię
    15726: 1        131.00  0.00 <-- Wykryto anomalię
    15727: 1        127.00  0.00 <-- Wykryto anomalię
      15749: 1        134.00  0.00 <-- Wykryto anomalię
      15754: 1        116.00  0.00 <-- Wykryto anomalię
      15769: 1        148.00  0.00 <-- Wykryto anomalię
      15770: 1        127.00  0.00 <-- Wykryto anomalię
      15772: 1        107.00  0.01 <-- Wykryto anomalię
      15797: 1        139.00  0.00 <-- Wykryto anomalię
      15798: 1        111.00  0.01 <-- Wykryto anomalię
      15799: 1        106.00  0.01 <-- Wykryto anomalię
      15801: 1        98.00   0.01 <-- Wykryto anomalię
      15802: 1        107.00  0.01 <-- Wykryto anomalię
      15807: 1        98.00   0.01 <-- Wykryto anomalię
      15808: 1        102.00  0.01 <-- Wykryto anomalię
      15821: 1        106.00  0.01 <-- Wykryto anomalię
   

Dla powyższych przykładów model nie wykrył istotnych punktów zmian.

## Bibliografia
1. Algorytmy sztucznej inteligencji. Ilustrowany przewodnik, Rishal Hurbans, Helion S.A., Gliwice 2021
2. https://docs.microsoft.com/pl-pl/dotnet/api/?view=ml-dotnet
3. https://docs.microsoft.com/pl-pl/dotnet/machine-learning/
4. Uczenie maszynowe w C#. Szybkie, sprytne i solidne aplikacjie, Matt R. Cole, Helion S.A., Gliwice 2020<

## Kod źródłowy rozwiązania wraz z dodatkowymi (szczegółowymi) komentarzami
````c#
// Kod z pliku Program.cs
using System;
using System.IO;
using Microsoft.ML;
using System.Collections.Generic;

namespace Detekcja
{
    class Program
    {
        /// <summary>
        /// Zmienna zawierająca ścieżkę do pliku z danymi.
        /// W tym przypadku katalog Data w katalogu Moje dokumenty.
        /// Zmieniamy nazwę pliku, który ma zostać przeanalizowany.
        /// </summary>
        static readonly string _dataPath= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data", "Twitter_volume_GOOG.csv");
        /// <summary>
        /// Zmienna reprezentująca liczbę rekordów w pliku z danymi
        /// </summary>
        const int _docsize = 15842;
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
            var iidSpikeEstimator = mlContext.Transforms.DetectIidSpike(outputColumnName: nameof(Predykcja.Prediction), inputColumnName: nameof(DetekcjaAnomalii.value), confidence: 99, pvalueHistoryLength: docSize / 2);

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

// Kod z pliku DetekcjaAnomalii.cs

using Microsoft.ML.Data;
using System.Numerics;

namespace Detekcja
{
    /// <summary>
    /// Klasa danych wejściowych (dane z pliku).
    /// </summary>
    public class DetekcjaAnomalii
    {
        /// <summary>
        /// Atrybut określający kolumnę do załadowania.
        /// Kolumna timeStamp
        /// </summary>
        [LoadColumn(0)]

        // Miesiąc
        public string timeStamp;

        /// <summary>
        /// Atrybut określający kolumnę do załadowania.
        /// Kolumna value
        /// </summary>
        [LoadColumn(1)]

        // wartość
        public float value;
    }

    /// <summary>
    /// Klasa danych przewidywania.
    /// Dla anomalii np:
    /// Alert Score   P-Value
    /// 7999: 1 93.00   0.01 <-- Wykryto anomalię
    /// Im p bliższe 0 tym większe prawdopodobieństwo wystąpienia anomalii
    /// </summary>
    public class Predykcja
    {
        //Dane dla wartości alert,score,p-value
        [VectorType(3)]
        public double[] Prediction { get; set; }
    }
}
                                                                                                            
````
                                                                                                             
