using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Globalization;
using _6Lab1;

namespace _6Lab1
{
    interface Lab4    {
        void Adds(List<Data_Base> d_b);
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            List<Data_Base> d_b = new List<Data_Base>();

            int yearFrom, monthFrom, dayFrom;
            int yearTo, monthTo, dayTo;
            double граничнеЗначенняСуми;


            Console.WriteLine("Введіть дату(з): ");
            Console.WriteLine("Рік: ");
            yearFrom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Місяць: ");
            monthFrom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("День: ");
            dayFrom = Convert.ToInt32(Console.ReadLine());
            DateTime periodFrom = new DateTime(yearFrom, monthFrom, dayFrom);

            Console.WriteLine("Введіть дату(до): ");
            Console.WriteLine("Рік: ");
            yearTo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Місяць: ");
            monthTo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("День: ");
            dayTo = Convert.ToInt32(Console.ReadLine());
            DateTime periodTo = new DateTime(yearTo, monthTo, dayTo);

            Console.WriteLine("Введіть граничне значення суми: ");
            граничнеЗначенняСуми = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ви вказали період з " + periodFrom.ToShortDateString() + " до " + periodTo.ToShortDateString() + " і граничне значення суми " + граничнеЗначенняСуми);


            Data_Base bank = new Data_Base();

            bank.Adds(d_b);
            Dictionary<Data_Base, int> Count = new Dictionary<Data_Base, int>();
            foreach (Data_Base x in d_b)
            {

                if (граничнеЗначенняСуми < x.noneCash_minus)
                {
                    if (periodFrom < x.DateRecieved && x.DateRecieved < periodTo)
                    {
                        Console.WriteLine("Прізвище та імя: " + x.Name + " Номер рахунку: " + x.Number + " Залишок Вкладу: " + x.remainder);
                    }
                }
            }

        }

    }
    class Data_Base : Lab4
    {
        private string ACCOUNT_NUMBER;
        private string Name_LastName;
        private float NoneCash_plus;
        private float NoneCash_minus;
        private float Cash_plus;
        private float Cash_minus;
        private float Remainder;

        public List<string> Dates = new List<string>();
        public void Adds(List<Data_Base> d_b)
        {
            Data_Base bank = new Data_Base();
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 1995"), Name = "name_1", Number = "1", noneCash_plus = 500, noneCash_minus = 2000, cash_plus = 500, cash_minus = 200, remainder = bank.remainder }); ;
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 1996"), Name = "name_2", Number = "2", noneCash_plus = 600, noneCash_minus = 20000, cash_plus = 600, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 1997"), Name = "name_3", Number = "3", noneCash_plus = 700, noneCash_minus = 5000, cash_plus = 500, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 1998"), Name = "name_4", Number = "4", noneCash_plus = 800, noneCash_minus = 4000, cash_plus = 500, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 1999"), Name = "name_5", Number = "5", noneCash_plus = 900, noneCash_minus = 2000, cash_plus = 700, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 2000"), Name = "name_6", Number = "6", noneCash_plus = 1000, noneCash_minus = 3000, cash_plus = 500, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 2001"), Name = "name_7", Number = "7", noneCash_plus = 1100, noneCash_minus = 23000, cash_plus = 400, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 2002"), Name = "name_8", Number = "8", noneCash_plus = 1200, noneCash_minus = 15000, cash_plus = 900, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 2003"), Name = "name_9", Number = "9", noneCash_plus = 1300, noneCash_minus = 200, cash_plus = 500, cash_minus = 200, remainder = bank.remainder });
            d_b.Add(new Data_Base { DateRecieved = DateTime.Parse("Jan 1, 2004"), Name = "name_10", Number = "10", noneCash_plus = 1400, noneCash_minus = 1000, cash_plus = 500, cash_minus = 200, remainder = bank.remainder });
        }



        public string Name
        {
            get { return Name_LastName; }
            set { Name_LastName = value; }
        }
        public string Number
        {
            get
            {
                return ACCOUNT_NUMBER;
            }
            set
            {
                ACCOUNT_NUMBER = value;
            }
        }
        public float noneCash_plus
        {
            get
            {
                return NoneCash_plus;
            }
            set
            {
                NoneCash_plus = value;
            }
        }
        public float noneCash_minus
        {
            get
            {
                return NoneCash_minus;
            }
            set
            {
                NoneCash_minus = value;
            }
        }

        public float cash_plus
        {
            get
            {
                return Cash_plus;
            }
            set
            {
                Cash_plus = value;
            }
        }
        public float cash_minus
        {
            get
            {
                return Cash_minus;
            }
            set
            {
                Cash_minus = value;
            }
        }

        public DateTime DateRecieved { get; set; }

        public float remainder
        {
            get
            {
                return (noneCash_plus + cash_plus) - (noneCash_minus + cash_minus);
            }
            set
            {
                Remainder = value;
            }
        }

    }

}
