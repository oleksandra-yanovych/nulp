using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7Lab1b
{
    public class Country
    {
        public string Name;
        public int Widht;
        public int Naselenya;
        public string GetName() { return Name; }
        public int GetWidht() { return Widht; }
        public Country(string N, int W, int NL)
        {
            this.Name = N;
            this.Widht = W;
            this.Naselenya = NL;
        }
        virtual public void Passport()
        {
            Console.WriteLine("Name = {0} Widht = {1}  Population = {2}", Name, Widht, Naselenya);
        }


        public class SortByWidht : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Country p1 = (Country)ob1;
                Country p2 = (Country)ob2;
                if (p1.Widht > p2.Widht) return 1;
                if (p1.Widht < p2.Widht) return -1;
                return 0;
            }
        }

        public class SortByNaselenya : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Country p1 = (Country)ob1;
                Country p2 = (Country)ob2;
                if (p1.Naselenya > p2.Naselenya) return 1;
                if (p1.Naselenya < p2.Naselenya) return -1;
                return 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Country prep1 = new Country("China", 9596960, 1393612226);
            Country prep2 = new Country("USA", 9372610, 308745538);
            Country prep3 = new Country("Ukraine", 603700, 48457102);
            Country prep4 = new Country("Russia", 17075400, 146748590);
            Country prep5 = new Country("Brazil", 8547000, 206081432);
            Country prep6 = new Country("Japan", 377835, 127078679);
            Country prep7 = new Country("Australia", 7686850, 25612330);
            Country prep8 = new Country("Poland", 312685, 38411148);
            Country prep9 = new Country("Monaco", 2, 38682);
            Country prep10 = new Country("Italy", 301230, 62886254);
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
            Console.WriteLine("Sort by width:");
            Array.Sort(group, new Country.SortByWidht());
            foreach (Country elem in group) elem.Passport();
            Console.WriteLine("Sort by population:");
            Array.Sort(group, new Country.SortByNaselenya());
            foreach (Country elem in group) elem.Passport();
            Console.ReadLine();

        }
    }
}
