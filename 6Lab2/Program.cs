using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace _6Lab2
{
    interface Inter
    {
        void AverageAmountSpam(List<spam> Mes);
        void MaxSpam(List<spam> Mes);
    }
    public class emailacc
    {
        private string name;
        private string email;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public void AverageAmountSpam(List<spam> Mes)
        {
            Console.Clear();
            var Group = from AVspam in Mes
                        group AVspam by AVspam.Spam into g
                        select new
                        {
                            Name = g.Key,
                            Count = g.Count(),
                            Spams = from p in g select p
                        };
            foreach (var group in Group)
            {
                float spm = 0;
                foreach (var gr in group.Spams)
                {
                    spm += Convert.ToInt32(gr.Spam);
                }
                Console.WriteLine($"{group.Name} : {spm / group.Count} Spam messages");
                Console.WriteLine();
            }
        }
        public float MaxSpam(List<spam> Mes)
        {
            float spm = 0;
            Console.Clear();
            var Group = from MSpam in Mes
                        group MSpam by MSpam.Date into g
                        select new
                        {
                            Name = g.Key,
                            Count = g.Count(),
                            Spams = from p in g select p
                        };
            foreach (var group in Group)
            {
                spm = 0;
                foreach (var gr in group.Spams)
                {
                    spm += Convert.ToInt32(gr.amountofspam);
                }
                Console.WriteLine($"{group.Name} : {spm} spam messages");
                Console.WriteLine();
            }
            return spm;
        }
    }
    public class spam : emailacc
    {
        public string date;
        public string amountofspam;
        public string messages;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Spam
        {
            get { return amountofspam; }
            set { amountofspam = value; }
        }
        public string Messages
        {
            get { return messages; }
            set { messages = value; }
        }
    }

    public class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("╔════════════╤══════════════════════════════╗");
                Console.WriteLine("   Hot key   │            Function       ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      A      │          Add new message  ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      C      │          Change message  ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      D      │          Delete message ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      T      │        Show all messages  ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      H      │Average amount of spam per day ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      P      │    Minimal amount of spam  ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("      M      │       Days with more spam   ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("    Space    │         Clear console  ");
                Console.WriteLine("╠════════════╪══════════════════════════════╣");
                Console.WriteLine("     Esc     │          Exit program  ");
                Console.WriteLine("╚════════════╧══════════════════════════════╝");
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                var Mes = JsonConvert.DeserializeObject<List<spam>>(File.ReadAllText(FilePath));

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        if (Mes == null)
                        {
                            Mes = new List<spam>();
                            Mes.Add(CreateNewMes());
                        }
                        else
                        {
                            Mes.Add(CreateNewMes());
                        }
                        break;
                    case ConsoleKey.C:
                        ChangeData(Mes);
                        break;
                    case ConsoleKey.D:
                        DeleteMes(Mes);
                        break;
                    case ConsoleKey.T:
                        ShowAll(Mes);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.H:
                        (new emailacc()).AverageAmountSpam(Mes);
                        break;

                    case ConsoleKey.M:
                        (new emailacc()).MaxSpam(Mes);
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        break;
                }
                string serialize = JsonConvert.SerializeObject(Mes, Formatting.Indented);
                if (serialize.Count() > 1)
                {
                    if (!File.Exists(FileName))
                    {
                        File.Create(FileName).Close();
                    }
                    File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                }
            }
        }
        public static spam CreateNewMes()
        {
            Console.Clear();
            spam Mes = new spam();
            Console.WriteLine("Enter Your name");
            Mes.Name = Console.ReadLine();
            Console.WriteLine("Enter Your email");
            Mes.Email = Console.ReadLine();
            Console.WriteLine("Enter date of day like 01.02.2000");
            Mes.Date = Console.ReadLine();
            Console.WriteLine("Enter Your message");
            Mes.Messages = Console.ReadLine();

            return Mes;
        }
        public static void ChangeData(List<spam> Mes)
        {
            Console.WriteLine("Enter date of day that`s you want to change");
            var s = Console.ReadLine();
            spam day = Mes.Find(x => x.Date == s);
            if (day != null)
            {
                Console.WriteLine("Enter value of day that`s you want to change \n1)Name\n2)Position\n3)Date like 01.02.2000\n4)Hours count\n5)Project Name");
                char a = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                switch (a)
                {
                    case '1':
                        day.Name = Console.ReadLine();
                        break;
                    case '2':
                        day.Email = Console.ReadLine();
                        break;
                    case '3':
                        day.Date = Console.ReadLine();
                        break;
                }
            }
        }
        public static void DeleteMes(List<spam> Mes)
        {
            if (Mes != null)
            {
                Console.WriteLine("Enter date of day that`s you want to delete");
                var s = Console.ReadLine();
                Mes.RemoveAll(x => x.Date == s);

            }
        }
        public static void ShowAll(List<spam> Mes)
        {
            Console.Clear();
            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
            Console.WriteLine("     Name    │    Email   │   Date   │  Messages   │     Spam      ");
            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
            for (int i = 0; i < Mes.Count; i++)
            {
                Console.WriteLine("{0,10} {1, 10} {2, 15} {3, 10} {4, 13}", Mes[i].Name, Mes[i].Email, Mes[i].Date, Mes[i].Messages, Mes[i].Spam);
                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
            }
            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
        }


    }
}
