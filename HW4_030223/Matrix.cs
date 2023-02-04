using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW4_030223
{
    internal class Matrix <T> // Извините, но мне очень интересно всё это попробовать
    {
        private int _rows;
        private int _columns;
        private T[,] _data;
        public int Rows{
            get { return _rows; }
            private set
            {
                if (value < 0) throw new ArgumentException("Rows cannot be less than zero"); // стандартное исключение
                else _rows = value; // value - значение которое передается в сеттер
            }
        }
        public int Columns
        {
            get { return _columns; }
            private set
            {
                if (value < 0) throw new ArgumentException("Rows cannot be less than zero");
                else _columns = value;
            }
        }
        public int[,] Data
        {
            get; // { return _data; }
            private set; //  { _data = value; }
        }
        public int this[int row, int col] // перегрузка оператора [int, int]
        {
            get
            {
                return Data[row, col];
            }
            set
            {
                Data[row, col] = value;
            }
        }
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Data = new int[Rows, Columns];
        }
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(Data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static Matrix<T> operator *(Matrix<T> matrix, int scalar)
        {
            Matrix<T> result = new Matrix<T>(matrix.Rows, matrix.Columns);
            result.Rows = matrix.Rows;
            result.Columns = matrix.Columns;
            result.Data = new int[result.Rows, result.Columns];

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result.Data[i, j] = matrix.Data[i, j] * scalar;
                }
            }

            return result;
        }
        public Matrix<T> MultiplyByScalar(int scalar) // Почему я не могу перегрузить оператор *= ???
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    this.Data[i, j] *= scalar;
                }
            }

            return this;
        }
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new ArgumentException("The matrices must have the same dimensions.");
            }

            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Columns);
            result.Data = new int[matrix1.Rows, matrix1.Columns];

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result.Data[i, j] = matrix1.Data[i, j] + matrix2.Data[i, j];
                }
            }

            return result;
        }
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Columns)
            {
                throw new ArgumentException("It is necessary that the number of rows of the first matrix be equal to the number of columns of the second matrix");
            }
            Matrix<T> result = new Matrix<T>(matrix1.Columns, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    dynamic sum = 0;
                    for (int k = 0; k < matrix2.Columns; k++)
                    {
                        sum += (dynamic)matrix1.Data[i, k] * (dynamic)matrix2.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            }

            return result;
        }
    }
}
