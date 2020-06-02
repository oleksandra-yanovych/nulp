using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace _4Lab3
{

    public class moviecollection
    {
        public string title;
        public string surname;
        public string year;
        public string studio;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Sur
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        public string Studio
        {
            get { return studio; }
            set { studio = value; }
        }
    }

    class Program
    {

        private static string P = "collection.json";
        private static string N = "collection.json";
        static void collection()
        {
            while (true)
            {

                Console.WriteLine("To edit something press ");
                Console.WriteLine("'A' - for adding\n'S' = for search" + "\n'T' - to show the list\ngo to main menu'Enter'\nClear console   'F'\nExit 'Esc'");
                // enter -- назад , щоб редагувати або удаляти просто шукаєте по прізвищу кого там є можливість
                var data = JsonConvert.DeserializeObject<List<moviecollection>>(File.ReadAllText(P));

                var y = Console.ReadKey();
                var x = y.Key;
                switch (x)
                {
                    case ConsoleKey.A: // ДОДАТИ

                        {
                            Console.Clear();
                            Console.WriteLine("Enter the movie title : ");
                            string title = Console.ReadLine();
                            Console.Write("Surname of director: ");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Year of release: ");
                            string year = Console.ReadLine();
                            Console.WriteLine("Film studio: ");
                            string studio = Console.ReadLine();


                            if (surname != null && title != null && year != null && studio != null)
                            {
                                data.Add(new moviecollection { Sur = surname, Title = title, Year = year, Studio = studio });
                            }
                            else
                            {
                                Console.WriteLine("Please, fill all the gaps");
                            }
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.F://CLEAR
                        {
                            Console.Clear();
                            break;
                        }

                    case ConsoleKey.S://ПОШУК
                        {
                            Console.Clear();
                            string year;
                            Console.WriteLine("Enter the year of release for a research: ");
                            year = Console.ReadLine();
                            if (Console.ReadLine() != null)
                            {

                                Console.Clear();

                                moviecollection FoundData = data.Find(found => found.Year == year);
                                if (FoundData == null)
                                {
                                    Console.WriteLine("Error");
                                }
                                else
                                {

                                    Console.WriteLine("Title :" + FoundData.title + "\t");
                                    Console.WriteLine("Surname of director : " + FoundData.surname + "\t");
                                    Console.WriteLine("Year of the release : " + FoundData.year + "\t");
                                    Console.WriteLine("Studio :" + FoundData.studio + "\t");
                                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

                                    Console.WriteLine("\nTo edit press 'E'");
                                    Console.WriteLine("\n\nFor deleting press 'D'");
                                    if (Console.ReadKey().Key == ConsoleKey.E)
                                    {
                                        Console.WriteLine("Title : ");
                                        string title = Console.ReadLine();
                                        Console.Write("Surname of a director: ");
                                        string surname = Console.ReadLine();
                                        Console.WriteLine("Year of release: ");
                                        string yearr = Console.ReadLine();
                                        Console.WriteLine("Studio: ");
                                        string studio = Console.ReadLine();


                                        if (title != null && surname != null && yearr != null && studio != null)
                                        {
                                            FoundData.Sur = surname;
                                            FoundData.Title = title;
                                            FoundData.Year = year;
                                            FoundData.Studio = studio;
                                            Console.Clear();

                                            Console.WriteLine("Title :" + FoundData.Title + "\t");
                                            Console.WriteLine("Surname of director : " + FoundData.Sur + "\t");
                                            Console.WriteLine("Year of the release : " + FoundData.Year + "\t");
                                            Console.WriteLine("Studio :" + FoundData.Studio + "\t");
                                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                                        }

                                    }
                                    if (Console.ReadKey().Key == ConsoleKey.D)//DELETED
                                    {
                                        data.RemoveAll(x => x.Year == year);
                                    }
                                }


                            }
                            else

                            {
                                Console.WriteLine("Enter the title");

                            }
                            break;
                        }
                    case ConsoleKey.T://ВСІ ДАНІ
                        {
                            Console.Clear();
                            
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("Title :" + data[i].Title + "\t");
                                Console.WriteLine("Surname of director : " + data[i].Sur + "\t");
                                Console.WriteLine("Year of the release : " + data[i].Year + "\t");
                                Console.WriteLine("Studio :" + data[i].Studio + "\t");

                                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

                            }

                            Console.WriteLine("\nTo sort movies press 'S'");


                            if (Console.ReadKey().Key == ConsoleKey.S)//Сортувати дані за прізвищем нажми
                            {

                                Console.Clear();
                                List<moviecollection> SortData = data.OrderBy(o => o.Title).ToList();

                                for (int i = 0; i < data.Count; i++)
                                {

                                    Console.WriteLine("Title :" + SortData[i].Title + "\t");
                                    Console.WriteLine("Surname of director : " + SortData[i].Sur + "\t");
                                    Console.WriteLine("Year of the release : " + SortData[i].Year + "\t");
                                    Console.WriteLine("Studio :" + SortData[i].Studio + "\t");

                                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                                }
                               

                            }

                            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                            {
                                Console.Clear();
                            }
                        }
                        string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                        if (serialize.Count() > 1)
                        {
                            if (!File.Exists(N))
                            {
                                File.Create(N).Close();
                            }
                            File.WriteAllText(P, serialize, Encoding.UTF8);
                        }
                        break;
                }
            }
           
        }

        static void Main(string[] args) { collection(); }
    }
}