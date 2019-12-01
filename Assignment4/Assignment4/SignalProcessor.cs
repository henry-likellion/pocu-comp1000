using System;
using System.Drawing;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            int filterLength = (int)Math.Ceiling(sigma * 6);

            if (filterLength % 2 == 0)
            {
                filterLength++;
            }

            double[] gaussianFilter1D = new double[filterLength];
            int centerIndex = filterLength / 2;

            for (int i = 0; i < filterLength; ++i)
            {
                gaussianFilter1D[i] = 1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Pow(Math.E, -(centerIndex - i) * (centerIndex - i) / (2 * sigma * sigma));
            }

            return gaussianFilter1D;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            int signalLength = signal.Length;
            int centerIndex = filter.Length / 2;
            double[] convolution1D = new double[signalLength];
            
            for (int i = 0; i < signalLength; ++i)
            {
                double[] filterConvolution = new double[signalLength];
                filterConvolution[i] = filter[centerIndex];

                for (int j = 1; j < centerIndex + 1; ++j)
                {
                    if (i - j >= 0)
                    {
                        filterConvolution[i - j] = filter[centerIndex +j];
                    }
                    
                    if (i + j < signalLength)
                    {
                        filterConvolution[i + j] = filter[centerIndex - j];
                    }
                }

                for (int j = 0; j < signalLength; ++j)
                {
                    convolution1D[i] += signal[j] * filterConvolution[j];
                }

                for (int j = 0; j < signalLength; ++j)
                {
                    Console.Write($"{convolution1D[j]} ");
                }

                Console.WriteLine("");
            }

            return convolution1D;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            int filterLength = (int)Math.Ceiling(sigma * 6);

            if (filterLength % 2 == 0)
            {
                filterLength++;
            }

            double[,] gaussianFilter2D = new double[filterLength, filterLength];
            int centerIndex = filterLength / 2;

            for (int i = 0; i < filterLength; ++i)
            {
                for (int j = 0; j < filterLength; ++j)
                {
                    gaussianFilter2D[i, j] = 1 / (sigma * sigma * 2 * Math.PI) * Math.Pow(Math.E, -((centerIndex - i) * (centerIndex - i) + (centerIndex - j) * (centerIndex - j)) / (2 * sigma * sigma));
                    Console.Write(gaussianFilter2D[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            return gaussianFilter2D;
        }
        
        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            int x, y;
            int imageWidth = bitmap.Width;
            int imageHeight = bitmap.Height;
            int filterWidth = filter.GetLength(0);
            int filterLength = filter.GetLength(1);
            int[,] matrixRedColor = new int[imageWidth, imageHeight];
            int[,] updatedMatrixRedColor = new int[imageWidth, imageHeight];
            int[,] matrixGreenColor = new int[imageWidth, imageHeight];
            int[,] updatedMatrixGreenColor = new int[imageWidth, imageHeight];
            int[,] matrixBlueColor = new int[imageWidth, imageHeight];
            int[,] updatedMatrixBlueColor = new int[imageWidth, imageHeight];

            /*
            double[,] sampleMatrix = new double[,] {
                { 10, 20, 30, 50, 20 },
                { 20, 40, 50, 30, 10 },
                { 70, 50, 60, 30, 20 },
                { 40, 10, 80, 20, 10 },
                { 30, 20, 60, 70, 10 }
            };

            double[,] newSampleMatrix = new double[5, 5];
            */

            int centerIndex = filterWidth / 2;

            double[,] filterConvolution = new double[filterWidth, filterLength];

            Bitmap newImage = new Bitmap(imageWidth, imageHeight);

            for (int i = 0; i < centerIndex * 2 + 1; ++i)
            {
                for (int j = 0; j < centerIndex * 2 + 1; ++j)
                {
                    filterConvolution[i, j] = filter[2 * centerIndex - i, 2 * centerIndex - j];
                }
            }

            for (int i = 0; i < centerIndex * 2 + 1; ++i)
            {
                for (int j = 0; j < centerIndex * 2 + 1; ++j)
                {
                    Console.Write($"{filterConvolution[i, j]} ");
                }
                Console.WriteLine();
            }

            /*
            for (x = 0; x < sampleMatrix.GetLength(0); ++x)
            {
                for (y = 0; y < sampleMatrix.GetLength(1); ++y)
                {
                    for (int i = 0; i < centerIndex * 2 + 1; ++i)
                    {
                        for (int j = 0; j < centerIndex * 2 + 1; ++j)
                        {
                            // Console.Write($"{filterConvolution[i, j]} ");
                            if (x - centerIndex + i >= 0 && x - centerIndex + i < 5 && y - centerIndex + j >= 0 && y - centerIndex + j < 5)
                            {
                                newSampleMatrix[x, y] += sampleMatrix[x - centerIndex + i, y - centerIndex + j] * filterConvolution[i, j];
                            }
                        }
                    }
                }
            }

            for (x = 0; x < sampleMatrix.GetLength(0); ++x)
            {
                for (y = 0; y < sampleMatrix.GetLength(1); ++y)
                {
                    Console.Write($"{newSampleMatrix[x, y]} ");
                }
                Console.WriteLine();
            }

            */

                    
            for (x = 0; x < imageWidth; ++x)
            {
                for (y = 0; y < imageHeight; ++y)
                {
                    Color currentColor = bitmap.GetPixel(x, y);
                    matrixRedColor[x, y] = currentColor.R;
                    matrixGreenColor[x, y] = currentColor.G;
                    matrixBlueColor[x, y] = currentColor.B;
                }
            }

            for (x = 0; x < imageWidth; ++x)
            {
                for (y = 0; y < imageHeight; ++y)
                {

                    for (int i = 0; i < centerIndex * 2 + 1; ++i)
                    {
                        for (int j = 0; j < centerIndex * 2 + 1; ++j)
                        {
                            // Console.Write($"{filterConvolution[i, j]} ");
                            if (x - centerIndex + i >= 0 && x - centerIndex + i < imageWidth && y - centerIndex + j >= 0 && y - centerIndex + j < imageHeight)
                            {
                                updatedMatrixRedColor[x, y] += (int)(matrixRedColor[x - centerIndex + i, y - centerIndex + j] * filterConvolution[i, j]);
                                updatedMatrixGreenColor[x, y] += (int)(matrixGreenColor[x - centerIndex + i, y - centerIndex + j] * filterConvolution[i, j]);
                                updatedMatrixBlueColor[x, y] += (int)(matrixBlueColor[x - centerIndex + i, y - centerIndex + j] * filterConvolution[i, j]);                                
                            }
                        }
                    }

                    newImage.SetPixel(x, y, Color.FromArgb((int)updatedMatrixRedColor[x, y], (int)updatedMatrixGreenColor[x, y], (int)updatedMatrixBlueColor[x, y]));
                }
            }

            Console.WriteLine($"{matrixRedColor[0, 0]}");
            Console.WriteLine($"{updatedMatrixRedColor[0, 0]}");
            Console.WriteLine($"{matrixRedColor[125, 125]}");
            Console.WriteLine($"{updatedMatrixRedColor[125, 125]}");

            return newImage;
        }
    }
}