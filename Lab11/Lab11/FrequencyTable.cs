using System;
using System.Collections.Generic;

namespace Lab11
{
    public static class FrequencyTable
    {
        public static List<Tuple<Tuple<int, int>, int>> GetFrequencyTable(int[] data, int maxBinCount)
        {
            int max = data[0];
            int min = data[0];

            for (int i = 1; i < data.Length; ++i)
            {
                if (max < data[i])
                {
                    max = data[i];
                }

                if (min > data[i])
                {
                    min = data[i];
                }
            }

            Console.WriteLine(max);
            Console.WriteLine(min);

            int binIntervals;
            int numBins;

            if (max == min)
            {
                return new List<Tuple<Tuple<int, int>, int>>
                {
                    new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(min, min + 1), data.Length)
                };
            }

            binIntervals = (int)Math.Round((max - min) / (double)maxBinCount + 0.5000000000001);
            numBins = (int)Math.Ceiling((max - min) / (double)binIntervals);

            if ((max - min) == numBins * binIntervals)
            { 
                ++numBins;
            }

            

            Console.WriteLine($"BinIntervals: {binIntervals}");
            Console.WriteLine($"numBins: {numBins}");

            int[] binValues = new int[numBins + 1];

            binValues[0] = min;

            for (int i = 1; i < binValues.Length; ++i)
            {
                binValues[i] = binValues[i - 1] + binIntervals;
            }

            for (int i = 0; i < binValues.Length; ++i)
            {
                Console.WriteLine(binValues[i]);
            }

            int[] counters = new int[numBins];

            for (int i = 0; i < numBins; ++i)
            {
                int currentIntervalMin = min + binIntervals * i;
                int currentIntervalMax = min + binIntervals * (i + 1);
                int counter = 0;

                for (int j = 0; j < data.Length; ++j)
                {
                    if (data[j] >= currentIntervalMin && data[j] < currentIntervalMax)
                    {
                        ++counter;
                    }
                }

                counters[i] = counter;
            }

            Console.WriteLine("Conters:");

            for (int i = 0; i < numBins; ++i)
            {
                Console.WriteLine(counters[i]);
            }

            List<Tuple<Tuple<int, int>, int>> frequenceTable = new List<Tuple<Tuple<int, int>, int>>(numBins);

            for (int i = 0; i < numBins; ++i)
            {
                Console.WriteLine(i);
                frequenceTable.Add(new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(binValues[i], binValues[i + 1]), counters[i]));
            }

            return frequenceTable;
        }
    }
}