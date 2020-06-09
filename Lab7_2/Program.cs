using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_2
{
    public class Filee
    {
        public string Name = "";
        public string purpose = "";
        public float Weight = 0;
        public DateTime Date;
        public string Attributes = "";
        public Filee(string Name = "", string purpose = "", float Weight = 0, string Attributes = "")
        {
            this.Name = Name;
            this.purpose = purpose;
            this.Weight = Weight;
            this.Attributes = Attributes;
        }
        public int CompareTo(Filee o)
        {
            return this.Attributes.CompareTo(o.Attributes);
        }
        public class SortByWeight : IComparer<Filee>
        {

            public int Compare(Filee f1, Filee f2)
            {
                if (f1.Weight > f2.Weight)
                    return 1;
                else if (f1.Weight < f2.Weight)
                    return -1;
                else
                    return 0;
            }
        }
        public class SortByDateAndWeight : IComparer<Filee>
        {
            public int Compare(Filee f1, Filee f2)
            {
                if (f1.Date > f2.Date)
                {
                    return 1;
                }
                else if (f1.Date < f2.Date)
                {
                    return -1;
                }
                else if (f1.Weight > f2.Weight)
                {
                    return 1;
                }
                else if (f1.Weight < f2.Weight)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    class Program
    {
        static OpenFileDialog fl = new OpenFileDialog();
        static FolderBrowserDialog fol = new FolderBrowserDialog();
        [STAThread]
        static void Main(string[] args)
        {

            List<Filee> data = new List<Filee>();
            while (true)
            {
                Console.WriteLine("'C' - create new file/n any button - to open file");
                var d = Console.ReadKey().Key;
                if (d == ConsoleKey.C)
                {
                    if (fol.ShowDialog() == DialogResult.OK)
                    {
                        var file = File.Create(fol.SelectedPath + "/Data.txt");
                        file.Close();
                        fl.FileName = fol.SelectedPath + "/Data.txt";
                        data = ReadDate(fol.SelectedPath + "/Data.txt");
                        break;
                    }
                }
                else
                {
                    if (fl.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(fl.FileName) == ".txt")
                        {
                            data = ReadDate(fl.FileName);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No result");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No result");
                    }
                }
            }

while (true)
            {
                Console.Clear();
                Table(data);
                var k = Console.ReadKey().Key;
                if (k == ConsoleKey.A)
                {
                    Add(data);
                }
                if (k == ConsoleKey.R)
                {
                    Remove(data);
                }
                if (k == ConsoleKey.C)
                {
                    ChangeData(data);
                }
                if (k == ConsoleKey.D)
                {
                    data.Sort(new Filee.SortByWeight());
                }
                if (k == ConsoleKey.T)
                {
                    data.Sort(new Filee.SortByDateAndWeight());
                }
                SaveDate(data, fl.FileName);
            }
        }
        static void Table(List<Filee> v)
        {
            string[] Texts = new string[5];
            Texts[0] = "    Name    ";
            Texts[1] = " Purpose ";
            Texts[2] = "     Date     ";
            Texts[3] = " Weight ";
            Texts[4] = " Attributes ";
            Console.WriteLine($"{Texts[0]}|{Texts[1]}|{Texts[2]}|{Texts[3]}|{Texts[4]}|");
            foreach (Filee vg in v)
            {
                Console.WriteLine(vg.Name + s(Texts[0].Length - vg.Name.Length) + "|" +
                    vg.purpose + s(Texts[1].Length - vg.purpose.ToString().Length) + "|" +
                    vg.Weight + s(Texts[3].Length - vg.Weight.ToString().Length) + "|" +
                    vg.Attributes + s(Texts[4].Length - vg.Attributes.ToString().Length) + "|" +
                    vg.Date.Date.ToString("dd.MM.yyyy") + s(Texts[2].Length - vg.Date.Date.ToString("dd.MM.yyyy").Length) + "|"
                    );
            }
            Console.WriteLine("A) Add new\nR) Remove\nC) Change\nD) Sort By Weight\nT) Sort By Date And Weight");
        }
        static void Add(List<Filee> v)
        {
            Filee New = new Filee();
            try
            {
                Console.WriteLine("Enter Name");
                New.Name = Console.ReadLine();
                Console.WriteLine("Enter Extension");
                New.purpose = Console.ReadLine();
                Console.WriteLine("Enter Date");
                New.Date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Weight");
                New.Weight = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Attributes");
                New.Attributes = Console.ReadLine();
            }
            catch
            {

                
}
            v.Add(New);
        }
        static void Remove(List<Filee> v)
        {
            Console.WriteLine("Name to delete");
            string name = Console.ReadLine();
            v.RemoveAt(v.FindIndex(f => f.Name == name));
        }
        static void ChangeData(List<Filee> v)
        {
            Console.WriteLine("Name to change");
            string name = Console.ReadLine();
            if ((v.FindIndex(f => f.Name == name) != -1))
            {
                Filee Change = v[v.FindIndex(f => f.Name == name)];
                Console.WriteLine("1)Name\n2)Extension\n3)Date\n4)Weight\n5)Attributes ");
                var res = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                if (res == '1')
                {
                    Change.Name = Console.ReadLine();
                }
                if (res == '2')
                {
                    Change.purpose = Console.ReadLine();
                }
                if (res == '3')
                {
                    Change.Date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                }
                if (res == '4')
                {
                    Change.Weight = Convert.ToInt16(Console.ReadLine());
                }
                if (res == '5')
                {
                    Change.Attributes = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Name not found");
                Console.ReadKey();
            }

        }
        public static string s(int c)
        {
            try
            {
                return new String(' ', c);
            }
            catch
            {
                return "";
            }
        }
        public static void SaveDate(List<Filee> Date, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (Filee g in Date)
                {

                    sw.WriteLine(g.Name.Trim() + "|" + g.purpose + "|" + g.Date.Date.ToString("dd.MM.yyyy") + "|" + g.Weight + "|" + g.Attributes + "/");

                }
            }
        }
        public static List<Filee> ReadDate(string path)
        {
            List<Filee> r = new List<Filee>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string[] Dates = text.Split('/');
            foreach (string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length == 5)
                {
                    Filee d = new Filee
                    {
                        Name = MetaDete[0].Trim(),
                        purpose = MetaDete[1],
                        Date = DateTime.ParseExact(MetaDete[2], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        Weight = (float)Convert.ToDouble(MetaDete[3]),
                        Attributes = MetaDete[4]
                    };
                    r.Add(d);
                }
            }
            return r;
        }
    }
}
