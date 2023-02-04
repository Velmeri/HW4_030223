using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_030223
{
    internal static class MyFunctions <T>
    {
        private static readonly Random random = new Random();
        public static void PrintArr(T[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
        public static void PrintArr(T[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++) {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintArr(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void RandArr(int[] arr, int min, int max)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(min, max);
            }
        }
        public static void RandArr(int[,] arr, int min, int max)
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(min, max);
                }
            }
        }
        public static void RandArr(int[][] arr, int min, int max)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = random.Next(min, max);
                }
            }
        }
        public static void Encrypt()
        {
            Console.WriteLine("Enter a string to encrypt: ");
            string plainText = Console.ReadLine();
            int key = 3;

            char[] cipherText = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                cipherText[i] = (char)(plainText[i] + key);
            }

            Console.WriteLine("Encrypted string: " + new string(cipherText));
        }
        public static void decrypt()
        {
            Console.WriteLine("Enter an encrypted string: ");
            string cipherText = Console.ReadLine();
            int key = 3;

            char[] plainText = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                plainText[i] = (char)(cipherText[i] - key);
            }

            Console.WriteLine("Decrypted string: " + new string(plainText));
        }
    }
}
