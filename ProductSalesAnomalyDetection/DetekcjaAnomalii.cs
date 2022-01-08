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
