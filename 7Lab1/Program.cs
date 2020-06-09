using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7Lab1
{
    public class Country : IComparable
    {
        public string Name;       
        public int Widht;             
        public string GetName() { return Name; }
        public int GetWidht() { return Widht; }
        public Country(string N, int W)
        {
            this.Name = N;
            this.Widht = W;
        }
        public int CompareTo(object pers)
        {
            Country p = (Country)pers;
            if (this.Widht > p.Widht) return 1;
            if (this.Widht < p.Widht) return -1; return 0;
        }
        public void Countryy()
        {
            Console.WriteLine("Name = {0} Widht = {1}", Name, Widht);
        }

        class Program
        {
            static void Main(string[] args)
            {
                Country prep1 = new Country("China", 9596960);
                Country prep2 = new Country("USA", 9372610);
                Country prep3 = new Country("Ukraine", 603700);
                Country prep4 = new Country("Russia", 17075400);
                Country prep5 = new Country("Brazil", 8547000);
                Country prep6 = new Country("Japan", 377835);
                Country prep7 = new Country("Australia", 7686850);
                Country prep8 = new Country("Poland", 312685);
                Country prep9 = new Country("Monaco", 2);
                Country prep10 = new Country("Italy", 301230);
                Country[] group = new Country[10];
                group[0] = prep1;
                group[1] = prep2;
                group[2] = prep3;
                group[3] = prep4;
                group[4] = prep5;
                group[5] = prep6;
                group[6] = prep7;
                group[7] = prep8;
                group[8] = prep9;
                group[9] = prep10;
                Array.Sort(group);
                foreach (Country elem in group) elem.Countryy();
                Console.ReadLine();
            }
        }
    }
}
