using System;

namespace _2Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" Please, choose the task (from 1 to 4)... ");
            double n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                FirstTask();
            }
            if (n == 2)
            {
                SecondTask();
            }
            if (n == 3)
            {
                ThirdTask();
            }
            if (n == 4)
            {
                FourthTask();
            }
        }
        static int FirstTask()
        {
            Console.WriteLine(" Please, enter the number of month:");
            int i = Convert.ToInt32(Console.ReadLine());
            bool k = true;
            switch (i)
            {
                case 1: Console.WriteLine(" The month number " + i + " is January"); break;
                case 2: Console.WriteLine("The month number " + i + " is February"); break;
                case 3: Console.WriteLine("The month number " + i + " is March"); break;
                case 4: Console.WriteLine("The month number " + i + " is April"); break;
                case 5: Console.WriteLine("The month number " + i + " is May"); break;
                case 6: Console.WriteLine("The month number " + i + " is June"); break;
                case 7: Console.WriteLine("The month number " + i + " is July"); break;
                case 8: Console.WriteLine("The month number " + i + " is August"); break;
                case 9: Console.WriteLine("The month number " + i + " is September"); break;
                case 10: Console.WriteLine("The month number " + i + " is October"); break;
                case 11: Console.WriteLine("The month number " + i + " is November"); break;
                case 12: Console.WriteLine("The month number " + i + " is December"); break;
                default: Console.WriteLine("Error: there is no month number " + i); k = false; break;

            }
            return 0;
        }
        static int SecondTask()
        {
            double a = -1, b = 25, dx = 1.25, y;

            Console.WriteLine("|\tx\t|\ty\t|");
            double x = a;
            while (x <= b && x != 4)
            {
                y = (Math.Exp(x)) / (3 * x - 12);


                Console.WriteLine($"|\t{x}\t|\t{y}\t|");
                x += dx;
                if (x == 4)
                {
                    Console.WriteLine("\t\terror, division by zero \t");
                }
            }
            x = 4 + dx;
            while (x <= b)
            {
                y = (Math.Exp(x)) / (3 * x - 12);

                Console.WriteLine($"|\t{x}\t|\t{y}\t |");
                x += dx;
            }
            return 0;
        }
        public static int ThirdTask()
        {
            Console.WriteLine(" Please, enter the size of array: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(" Press 1 for manual input or 2 for random filling... ");
            double n = Convert.ToInt32(Console.ReadLine());
            int[] M = new int[N];
            int i = 0, max = 0, min = 0, nmax = 0, nmin = 0;
            double dob = 1, sum = 0;
            if (n == 1)
            {
                for (i = 0; i < N; i++)
                {
                    Console.Write("|\t{0}\t|", i);
                    Console.Write("\t  ");
                    M[i] = int.Parse(Console.ReadLine());
                }
            }
            if (n == 2)
            {
                Random r = new Random();
                for (i = 0; i < N; i++)
                {
                    int Mm = r.Next(-100, 100);
                    M[i] = Mm;
                    Console.WriteLine("[{0}] = {1,1}", i, Mm);
                }
            }
            sum = Negative(N, M);
            for (i = 0; i < N; i++)
            {
                if (M[i] > max)
                {
                    max = M[i];
                    nmax = i;
                }
                if (M[i] < min)
                {
                    min = M[i];
                    nmin = i;
                }
            }
            if (nmax - nmin < -1)
            {
                for (i = nmax; i <= nmin; i++)
                {
                    dob *= M[i];
                }
                Console.WriteLine("Product of elements between minimal and maximal is  = " + dob);
            }
            else if (nmax - nmin > 1)
            {
                for (i = nmin; i <= nmax; i++)
                {
                    dob *= M[i];
                }
                Console.WriteLine("Product of elements between minimal and maximal is  = " + dob);
            }
            else
            {
                Console.WriteLine("\nThere are no elements between");
                dob = max * min;
                Console.WriteLine("Product of minimal and maximal elements is  = " + dob);
            }
            Console.WriteLine("Maximal number is " + nmax + " = " + max);
            Console.WriteLine("Minimal number is " + nmin + " = " + min);
            Console.WriteLine("Sum of negative numbers =" + sum);
            return 0;
        }
        static int FourthTask()
        {
            Console.WriteLine("Amount of rows :");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Amount of columns :");
            int m = int.Parse(Console.ReadLine());
            int[,] A = new int[n, m];
            int i = 0, j = 0, imin = 0, imax = 0, nimax = 0, nimin = 0, dob = 1;
            Console.WriteLine(" Press 1 for manual input or 2 for random filling... ");
            double f = Convert.ToInt32(Console.ReadLine());
            if (f == 1)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        Console.Write("[{0}][{1}] = ", i, j);
                        A[i, j] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Your matrix is :");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        Console.Write("|\t{0}\t|", A[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            if (f == 2)
            {
                Random r = new Random();
                Console.WriteLine("Your matrix is :");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        A[i, j] = r.Next(-100, 100);
                        Console.Write("|\t{0}\t|", A[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (A[i, j] > imax)
                    {
                        imax = A[i, j];
                        nimax = j;
                    }
                    if (A[i, j] < imin)
                    {
                        imin = A[i, j];
                        nimin = j; 
                    }
                }
            }
            Console.WriteLine("\nMaximal and minimal numbers are {0} and {1}", imax, imin);
            Console.WriteLine("\nNew array is :");
            int[] b = new int[n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    dob = A[i, nimax] * A[i, nimin];    
                }
                b[i] = dob;
                Console.WriteLine("[{0}] = {1,2}", i, b[i]);
            }
            return 0;
        }
        public static int Negative(int N,int[] M)
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                if (M[i] < 0)
                {
                    sum += M[i];
                }
            }
            return sum;
        }
    }
}
