using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Please, enter the amount of seconds ");
            int i = Convert.ToInt32(Console.ReadLine());
            int h = converttohours(i);
            int min = converttomin(i - (h * 3600));
            int sec = i - (h * 3600) - (min * 60);
            Console.WriteLine("\n Result:");
            Console.WriteLine("It`s been " + h + " hours " + min + " minutes " + sec + " seconds since the beginning of the day");
        }
        public static int converttomin(int n)
        {
            return Convert.ToInt32(n / 60);
        }
        public static int converttohours(int n)
        {
            return Convert.ToInt32(n / 3600);
        }
    }
}
