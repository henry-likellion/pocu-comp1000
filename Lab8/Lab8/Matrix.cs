using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public static class Matrix
    {
        public static int DotProduct(int[] v1, int[] v2)
        {
            int dot = 0;
            for (int i = 0; i < v1.Length; ++i)
            {
                dot += v1[i] * v2[i];
            }

            return dot;
        }

        public static int[,] Transpose(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int length = matrix.GetLength(1);
            int[,] transposed = new int[length, height];

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }

            return transposed;
        }

        public static int[,] GetIdentityMatrix(int size)
        {
            int[,] identityMatrix = new int[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (i == j)
                    {
                        identityMatrix[i, j] = 1;
                    }
                    else
                    {
                        identityMatrix[i, j] = 0;
                    }
                }
            }

            return identityMatrix;
        }

        public static int[] GetRowOrNull(int[,] matrix, int row)
        {
            int height = matrix.GetLength(0);
            

            if (row < height)
            {
                int length = matrix.GetLength(1);
                int[] rowMatrix = new int[length];

                for (int i = 0; i < length; ++i)
                {
                    rowMatrix[i] = matrix[row, i];
                }
                return rowMatrix;
            }

            return null;
        }

        public static int[] GetColumnOrNull(int[,] matrix, int col)
        {
            int length = matrix.GetLength(1);

            if (col < length)
            {
                int height = matrix.GetLength(0);
                int[] colMatrix = new int[height];

                for (int i = 0; i < height; ++i)
                {
                    colMatrix[i] = matrix[i, col];
                }
                return colMatrix;
            }

            return null;
        }

        public static int[] MultiplyMatrixVectorOrNull(int[,] matrix, int[] vector)
        {
            int lengthMatrix = matrix.GetLength(1);
            int lengthVector = vector.Length;

            if (lengthMatrix != lengthVector)
            {
                return null;
            }

            int heightMatrix = matrix.GetLength(0);

            int[] vectorMultipliedMatrixVector = new int[heightMatrix];

            for (int i = 0; i < heightMatrix; ++i)
            {
                int[] rowMatrix = GetRowOrNull(matrix, i);
                vectorMultipliedMatrixVector[i] = DotProduct(rowMatrix, vector);
            }

            return vectorMultipliedMatrixVector;
        }

        public static int[] MultiplyVectorMatrixOrNull(int[] vector, int[,] matrix)
        {
            int heightMatrix = matrix.GetLength(0);
            int lengthVector = vector.Length;

            if (heightMatrix != lengthVector)
            {
                return null;
            }

            int lengthMatrix = matrix.GetLength(1);

            int[] vectorMultipliedVectorMatrix = new int[lengthMatrix];

            for (int i = 0; i < lengthMatrix; ++i)
            {
                int[] colMatrix = GetColumnOrNull(matrix, i);
                vectorMultipliedVectorMatrix[i] = DotProduct(colMatrix, vector);
            }

            return vectorMultipliedVectorMatrix;
        }

        public static int[,] MultiplyOrNull(int[,] multiplicand, int[,] multiplier)
        {
            int lengthMultiplicand = multiplicand.GetLength(1);
            int heightMultiplier = multiplier.GetLength(0);

            if (lengthMultiplicand != heightMultiplier)
            {
                return null;
            }

            int heightMultiplicand = multiplicand.GetLength(0);
            int lengthMultiplier = multiplier.GetLength(1);

            int[,] product = new int[heightMultiplicand, lengthMultiplier];

            for (int i = 0; i < heightMultiplicand; ++i)
            {
                for (int j = 0; j < lengthMultiplier; ++j)
                {
                    int[] rowVectorMultiplicand = GetRowOrNull(multiplicand, i);
                    int[] colVectorMultiplier = GetColumnOrNull(multiplier, j);
                    product[i, j] = DotProduct(rowVectorMultiplicand, colVectorMultiplier);
                }
            }

            return product;
        }
    }
}
