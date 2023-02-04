using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW4_030223
{
    internal static class Task // iternal - делает класс/структуру доступной в любом месте сборки
    {
        public static void N1()
        {
            Console.WriteLine("N1:");

            // Creating an A:
            Console.WriteLine("Enter 5 numbers for array A:");
            int[] A = new int[5];
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Number {i+1}: ");
                A[i] = int.Parse(Console.ReadLine());
            }

            // Creating an B:
            int[,] B = new int[3, 4];
            MyFunctions<int>.RandArr(B, 0, 10);

            // Outputting arrays:
            Console.WriteLine("\nArray A:");
            MyFunctions<int>.PrintArr(A);
            Console.WriteLine("\n\nArray B:");
            MyFunctions<int>.PrintArr(B);

            // Creating a List with Shared Array Elements
            List<int> crossedList= new List<int>();
            foreach (int num in B)
                if (A.Contains(num)) crossedList.Add(num);

            // Counting all searched values:
            int maxNum = int.MinValue;
            int minNum = int.MaxValue;
            int sum = 0;
            int product = 1;
            int EvenSumA = 0; // Sum of even elements of Array A
            int OddSumB = 0; // Sum of odd elements of Array B
            foreach(int num in crossedList)
            {
                maxNum = Math.Max(maxNum, num);
                minNum = Math.Min(minNum, num);
                sum += num;
                product *= num;
            }
            foreach (int num in A)
            {
                if (num % 2 == 0) EvenSumA += num;
            }
            foreach (int num in B)
            {
                if (num % 2 == 1) OddSumB += num;
            }

            // Outputting results to the console:
            Console.WriteLine();
            Console.WriteLine($"Max = {maxNum}");
            Console.WriteLine($"Min = {minNum}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Product = {product}");
            Console.WriteLine($"Sum of even elements of Array A = {EvenSumA}");
            Console.WriteLine($"Sum of odd elements of Array B = {OddSumB}");
        }
        public static void N2()
        {
            Console.WriteLine("\nN2:");

            int[,] arr = new int[5, 5];
            MyFunctions<int>.RandArr(arr, -100, 100);
            MyFunctions<int>.PrintArr(arr);

            // Min and max searching
            int[] minIndex = { 0, 0 };
            int[] maxIndex = { 0, 0 };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < arr[minIndex[0], minIndex[1]]) (minIndex[0], minIndex[1]) = (i, j);
                    if (arr[i, j] >= arr[maxIndex[0], maxIndex[1]]) (maxIndex[0], maxIndex[1]) = (i, j);
                }
            }

            if (minIndex[0] > maxIndex[0]) (minIndex, maxIndex) = (maxIndex, minIndex);
            else if (minIndex[0] == maxIndex[0] && minIndex[1] > maxIndex[1]) (minIndex, maxIndex) = (maxIndex, minIndex);

            // Sum searching
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i > minIndex[0] || j > minIndex[1] && i < maxIndex[0] || j < maxIndex[1])
                    {
                        sum += arr[i, j];
                    }
                }
            }

            // Outputting result
            Console.WriteLine("Sum of elements between min and max: " + sum);
        }
        public static void N3()
        {
            Console.WriteLine("\nN3:");
            Console.WriteLine("Press eny key to clear the console");
            Console.ReadKey();
            Console.Clear();
            int option = -1;

            while (option != 3)
            {
                Console.WriteLine(
                            "1 - encrypt line\n" +
                            "2 - decrypt line\n" +
                            "3 - end");
                Console.Write("Enter the number of option: ");
                string str = Console.ReadLine();
                Int32.TryParse(str, out option);
                switch (option)
                {
                    case 1:
                        MyFunctions<int>.Encrypt();
                        Console.WriteLine("Press eny key to clear the console");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        MyFunctions<int>.decrypt();
                        Console.WriteLine("Press eny key to clear the console");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Press eny key to clear the console");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("You entered an invalid value");
                        Console.WriteLine("Press eny key to clear the console");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public static void N4()
        {
            Console.WriteLine("\nN4:");

            Matrix<double> A = new Matrix<double>(3, 3); // нужно использовать new для того, что-бы вызвать конструктор!!!
            Matrix<double> B = new Matrix<double>(3, 3);
            for (int i = 0; i < A.Columns; i++)
                for (int j = 0; j < A.Rows; j++)
                {
                    A[i, j] = i + j;
                    B[i, j] = j;
                }
            A = A * 2;
            A.Print();
            Console.WriteLine();
            B.Print();
            B = B + A;
            Console.WriteLine();
            B.Print();
            Matrix<double> C = B * A;
            Console.WriteLine();
            C.Print();
        }
        public static void N5()
        {
            Console.WriteLine("\nN5:");

            Console.WriteLine("Enter an arithmetic expression:");
            string expression = Console.ReadLine();

            int result = 0;
            string[] substrings = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string substring in substrings)
            {
                int value = int.Parse(substring);

                if (expression.IndexOf(substring) > 0)
                {
                    char operatorChar = expression[expression.IndexOf(substring) - 1];
                    if (operatorChar == '+')
                    {
                        result += value;
                    }
                    else if (operatorChar == '-')
                    {
                        result -= value;
                    }
                }
                else
                {
                    result += value;
                }
            }

            Console.WriteLine("Result: " + result);
        }
        public static void N6()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();

            string[] sentences = input.Split(new char[] { '.', '!', '?' });

            for (int i = 0; i < sentences.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(sentences[i]))
                {
                    sentences[i] = sentences[i].TrimStart();
                    sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
                }
            }

            string output = null;
            int count = 0;
            for(int i = 0; count < sentences.Length - 1; i++)
            {
                if (input[i] == '.')
                {
                    output += sentences[count++] + ". ";
                }
                if (input[i] == '!')
                {
                    output += sentences[count++] + "! ";
                }
                if (input[i] == '?')
                {
                    output += sentences[count++] + "? ";
                }
            }
            Console.WriteLine("Result:");
            Console.WriteLine(output);
        }
        public static void N7()
        {
            Console.WriteLine("\nN7:");
            Console.WriteLine("Enter a text: ");
            string input = Console.ReadLine();

            List<string> invalidWords = new List<string> { "bad", "evil", "nasty" };
            int count = 0;

            foreach (string word in invalidWords)
            {
                if (input.Contains(word))
                {
                    count++;
                    input = input.Replace(word, new string('*', word.Length));
                }
            }

            Console.WriteLine("Input after invalid words are replaced: " + input);
            Console.WriteLine("Number of invalid words replaced: " + count);
        }
    }
}
