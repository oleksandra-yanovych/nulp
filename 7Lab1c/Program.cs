using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Immutable;

namespace _7Lab1c
{
    public class Country : IComparable
    {
        public string Name;
        public int Widht;
        public int Naselenya;
        private string[] mas;

        public string GetName() { return Name; }
        public int GetWidht() { return Widht; }

        public Country(string N, int NL)
        {
            this.Name = N;
            this.Naselenya = NL;
        }

        public Country(string[] mas, int naselenya)
        {
            this.mas = mas;
            Naselenya = naselenya;
        }

        public int CompareTo(object pers)
        {
            Country p = (Country)pers;
            if (this.Naselenya > p.Naselenya) return 1;
            if (this.Naselenya < p.Naselenya) return -1; return 0;
        }
    }

    class Countryy : IEnumerable
    {

        protected int size;
        protected Country[] container;
        Random rnd = new Random();
        public Countryy()
        {
            size = 10;
            container = new Country[size];
            FillContainer();
        }

        public Countryy(int size)
        {
            this.size = size;
            container = new Country[size];
            FillContainer();
        }
        public Countryy(Country[] container)
        {
            this.container = container;
            size = container.Length;
        }
        void FillContainer()
        {
            int d = 0;
            for (int i = 0; i < size; i++)
            {
                string[] mas = new string[] { "China", "USA", "Ukraine", "Russia", "Brazil", "Japan", "Australia", "Poland", "Monaco", "Italy" };
                int naselenya = rnd.Next(600000, 2000000000);
                if (true)
                {
                    container[i] = new Country(mas[d], naselenya);
                }
                d += 1;
            }

        }
        public IEnumerator GetEnumerator()
        {
            Array.Sort(container);
            return container.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            Countryy agents = new Countryy(size);

            foreach (Country agent in agents)
            {
                Console.WriteLine("Country:  " + agent.Name.ToString() + "    Population:  " + agent.Naselenya.ToString());
            }
            Console.ReadLine();
        }
    }
}