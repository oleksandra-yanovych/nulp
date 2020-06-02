using System;
using System.IO;

namespace _3Lab2
{
    class Program
    {
        static void Main()
        {
            StreamReader file = new StreamReader("file.txt");

            int n = int.Parse(file.ReadLine());

            double[] marks = new double[n];

            for (int i = 0; i < n; ++i)
            {
                marks[i] = double.Parse(file.ReadLine());
            }

            double sum = 0;

            for (int i = 0; i < n; ++i)
            {
                sum += marks[i];
            }

            Console.WriteLine("Загальний середнiй бал групи: {0:f4}", (double)(sum / n));
        }
    }
}
