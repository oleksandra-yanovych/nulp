using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace _5Lab2
{
        public abstract class Account
        {
            public string Email { get; set; }
            public string PIB { get; set; }
            public abstract void DaysWithLowerSpam(List<Spam> spam);
            public abstract void DaysSpamIncreased(List<Spam> spam);
            public abstract void AverageSpamSpD(List<Spam> spam);
        }
        public class Spam : Account
        {
            public string Date { get; set; }
            public string AmountOfSpam { get; set; }
            public string AllEmails { get; set; }

            public override void DaysWithLowerSpam(List<Spam> spam)
            {
                Console.Clear();
                var Group = from sp in spam
                            group sp by sp.AmountOfSpam into g
                            select new
                            {
                                Name = g.Key,
                                Count = g.Count(),
                                Works = from p in g select p
                            };
                foreach (var group in Group)
                {
                    foreach (var phone in group.Works)
                    {
                        if (group.Count <= 10)
                            Console.WriteLine($"{group.Name} : {group.Count} letters");
                    }
                    Console.WriteLine();
                }
            }
            public override void DaysSpamIncreased(List<Spam> spam)
            {
                Console.Clear();
                var Group = from MALhours in spam
                            group MALhours by MALhours.Date into g
                            select new
                            {
                                Name = g.Key,
                                Count = g.Count(),
                                Works = from p in g select p
                            };
                foreach (var group in Group)
                {
                    float hrs = 0;
                    foreach (var gr in group.Works)
                    {
                        if (group.Count > 20)
                        {
                            Console.WriteLine($"{group.Name} : {group.Count} spam letters");
                        }
                    }
                    Console.WriteLine();
                }
            }
            public override void AverageSpamSpD(List<Spam> spam)
            {
                Console.Clear();
                var Group = from AVsp in spam
                            group AVsp by AVsp.AmountOfSpam into g
                            select new
                            {
                                Name = g.Key,
                                Count = g.Count(),
                                Works = from p in g select p
                            };
                foreach (var group in Group)
                {
                    float spm = 0;
                    foreach (var gr in group.Works)
                    {
                        spm += Convert.ToInt32(gr.AmountOfSpam);
                    }
                    Console.WriteLine($"{group.Name} : {spm / group.Count} spamm letters");
                    Console.WriteLine();
                }
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
                    Console.WriteLine("      A      │         Add new account  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      C      │         Change account  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      D      │         Delete account ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      T      │        Show all accounts  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      H      │      Average spam per day  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      P      │      Days with lower spam  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      M      │    Days when spam increased  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("    Space    │         Clear console  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("     Esc     │          Exit program  ");
                    Console.WriteLine("╚════════════╧══════════════════════════════╝");
                    if (!File.Exists(FileName))
                    {
                        File.Create(FileName).Close();
                    }
                    var spam = JsonConvert.DeserializeObject<List<Spam>>(File.ReadAllText(FilePath));
                    Spam sm = new Spam();
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            if (spam == null)
                            {
                                spam = new List<Spam>();
                                spam.Add(CreateNewDay());
                            }
                            else
                            {
                                spam.Add(CreateNewDay());
                            }
                            break;
                        case ConsoleKey.C:
                            ChangeData(spam);
                            break;
                        case ConsoleKey.D:
                            DelteDay(spam);
                            break;
                        case ConsoleKey.T:
                            ShowAll(spam);
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.H:
                            sm.AverageSpamSpD(spam);
                            break;
                        case ConsoleKey.P:
                            sm.DaysWithLowerSpam(spam);
                            break;
                        case ConsoleKey.M:
                            sm.DaysSpamIncreased(spam);
                            break;
                        case ConsoleKey.Spacebar:
                            Console.Clear();
                            break;
                    }
                    string serialize = JsonConvert.SerializeObject(spam, Formatting.Indented);
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
            public static Spam CreateNewDay()
            {
                Console.Clear();
                Spam spam = new Spam();
                Console.WriteLine("Enter Email");
                spam.Email = Console.ReadLine();
                Console.WriteLine("Enter Name, Surname, Middle name");
                spam.PIB = Console.ReadLine();
                Console.WriteLine("Enter date of day like 01.02.2000");
                spam.Date = Console.ReadLine();
                Console.WriteLine("Enter num of spam letters");
                spam.AmountOfSpam = Console.ReadLine();
                Console.WriteLine("Enter num of all letters");
                spam.AllEmails = Console.ReadLine();
                return spam;
            }
            public static void ChangeData(List<Spam> spaM)
            {
                Console.WriteLine("Enter date of day that`s you want to change");
                var s = Console.ReadLine();
                Spam spam = spaM.Find(x => x.Date == s);
                if (spam != null)
                {
                    Console.WriteLine("Enter value of day that`s you want to change \n1)Email\n2)Name, Surname, Middle name\n3)Date like 01.02.2000\n4)Num of spam letters\n5)Num of all letters");
                    char a = Console.ReadKey().KeyChar;
                    Console.WriteLine("Enter new value");
                    switch (a)
                    {
                        case '1':
                            spam.Email = Console.ReadLine();
                            break;
                        case '2':
                            spam.PIB = Console.ReadLine();
                            break;
                        case '3':
                            spam.Date = Console.ReadLine();
                            break;
                        case '4':
                            spam.AmountOfSpam = Console.ReadLine();
                            break;
                        case '5':
                            spam.AllEmails = Console.ReadLine();
                            break;
                    }
                }
            }
            public static void DelteDay(List<Spam> spam)
            {
                if (spam != null)
                {
                    Console.WriteLine("Enter date of day that`s you want to delete");
                    var s = Console.ReadLine();
                    spam.RemoveAll(x => x.Date == s);

                }
            }
            public static void ShowAll(List<Spam> spam)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════╤══════════════════════════════════════════════╤════════════╤════════════════╤══════════════╗");
                Console.WriteLine("               Email                 │                 Name, SName, MName           │    Date    │ Amount of spam │  All Email");
                Console.WriteLine("╠════════════════════════════════════╪══════════════════════════════════════════════╪════════════╪════════════════╪══════════════╣");
                for (int i = 0; i < spam.Count; i++)
                {
                    Console.WriteLine("  {0,10} \t\t\t {1, 10} {2, 15}  {3, 10} {4, 13}", spam[i].Email, spam[i].PIB, spam[i].Date, spam[i].AmountOfSpam, spam[i].AllEmails);
                    Console.WriteLine("╠════════════════════════════════════╪══════════════════════════════════════════════╪════════════╪════════════════╪══════════════╣");
                }
                Console.WriteLine("╚════════════════════════════════════╧══════════════════════════════════════════════╧════════════╧════════════════╧══════════════╝");
            }



        }
    }