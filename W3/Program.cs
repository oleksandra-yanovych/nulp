using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace _8Lab1
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void ServiceData()
        {
            while(true)
            {
                try 
                {
                    Console.WriteLine("╔════════════╤══════════════════════════════╗");
                    Console.WriteLine("   Hot key   │            Function       ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      A      │       Add new service  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      S      │    Search service by number  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      D      │   Delete service by number ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("      T      │   Show all services in base  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("    Space    │         Clear console  ");
                    Console.WriteLine("╠════════════╪══════════════════════════════╣");
                    Console.WriteLine("     Esc     │          Exit program  ");
                    Console.WriteLine("╚════════════╧══════════════════════════════╝");

                    var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));

                    int menuselect = 0;
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            menuselect = 1;
                            break;
                        case ConsoleKey.S:
                            menuselect = 2;
                            break;
                        case ConsoleKey.T:
                            menuselect = 3;
                            break;
                        case ConsoleKey.Escape:
                            menuselect = 4;
                            break;
                        case ConsoleKey.D:
                            menuselect = 5;
                            break;
                    }

                    if (menuselect == 1)
                    {
                        Console.Clear();

                        Console.WriteLine("Enter Service Data\n");
                        Console.WriteLine("Number: ");
                        string nuM = Console.ReadLine();
                        Console.WriteLine("City: ");
                        string city = Console.ReadLine();
                        Console.WriteLine("Street: ");
                        string street = Console.ReadLine();
                        Console.WriteLine("Rating: ");
                        string point = Console.ReadLine();
                        Console.WriteLine("Phone munber: ");
                        string phone = Console.ReadLine();

                        if (nuM != null && city != null && street != null && point != null && phone != null)
                        {
                            data.Add(new Service_Data { Num = nuM, Сity = city, Street = street, Rating = point, PhNumber = phone });
                        }
                        else
                        {
                            Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                        }
                        Console.Clear();
                    }

                    if (menuselect == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter search number: ");
                        string num = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Service_Data FoundData = data.Find(found => found.Num == num);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", FoundData.Num, FoundData.Сity, FoundData.Street, FoundData.Rating, FoundData.PhNumber);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");


                                Console.WriteLine("\nTo edit press 'E'");
                                Console.WriteLine("\n\nTo edit press 'D'");
                                if (Console.ReadKey().Key == ConsoleKey.E)
                                {
                                    Console.WriteLine("\nEdit service Data\n");
                                    Console.WriteLine("Number: ");
                                    string nuM = Console.ReadLine();
                                    Console.WriteLine("City: ");
                                    string city = Console.ReadLine();
                                    Console.WriteLine("Street: ");
                                    string street = Console.ReadLine();
                                    Console.WriteLine("Rating: ");
                                    string point = Console.ReadLine();
                                    Console.WriteLine("Phone number: ");
                                    string phone = Console.ReadLine();

                                    if (nuM == null || city == null || street == null || point == null || phone == null)
                                    {
                                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                                    }
                                    FoundData.Num = nuM;
                                    FoundData.Сity = city;
                                    FoundData.Street = street;
                                    FoundData.Rating = point;
                                    FoundData.PhNumber = phone;
                                    Console.Clear();
                                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                    Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                    Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", FoundData.Num, FoundData.Сity, FoundData.Street, FoundData.Rating, FoundData.PhNumber);
                                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                }
                                if (Console.ReadKey().Key == ConsoleKey.D)
                                {
                                    data.RemoveAll(x => x.Num == num);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "Service not found");
                            }
                             
                            
                        }
                    }

                    if (menuselect == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                        Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");

                        for (int i = 0; i < data.Count; i++)
                        {
                            Console.WriteLine("{0,10}   {1, 10}  {2, 10}  {3, 12}  {4, 13}", data[i].Num, data[i].Сity, data[i].Street, data[i].Rating, data[i].PhNumber);
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        }
                        Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        Console.WriteLine("\nTo sort by rating press 'P'");
                        Console.WriteLine("\nTo sort by number press 'N'");
                        Console.WriteLine("\nTo sort by phone number 'G'");
                        if (Console.ReadKey().Key == ConsoleKey.P)
                        {

                            Console.Clear();
                            List<Service_Data> SortData = data.OrderBy(o => o.Rating).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", SortData[i].Num, SortData[i].Сity, SortData[i].Street, SortData[i].Rating, SortData[i].PhNumber);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.N)
                        {

                            Console.Clear();
                            List<Service_Data> SortData = data.OrderBy(o => o.Num).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", SortData[i].Num, SortData[i].Сity, SortData[i].Street, SortData[i].Rating, SortData[i].PhNumber);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.G)
                        {

                            Console.Clear();
                            List<Service_Data> SortData = data.OrderBy(o => o.PhNumber).ToList();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", SortData[i].Num, SortData[i].Сity, SortData[i].Street, SortData[i].Rating, SortData[i].PhNumber);
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            }
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                        }
                    }

                    if (menuselect == 4)
                        
                    {
                        Environment.Exit(0);
                    }

                    if (menuselect == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter number to delete: ");
                        string number = Console.ReadLine();
                        if (Console.ReadLine() != null)
                        {
                            Console.Clear();
                            Service_Data FoundData = data.Find(found => found.Num == number);
                            if (FoundData != null)
                            {
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                                Console.WriteLine("    Number   │    City    │  Street  │    Point    │ Phone number");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,10} {1, 10} {2, 10} {3, 12} {4, 13}", FoundData.Num, FoundData.Сity, FoundData.Street, FoundData.Rating, FoundData.PhNumber);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                                data.RemoveAll(x => x.Num == number);
                                Console.WriteLine("This information has been deleted");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error\n\n" +
                            "City not found");
                            }


                        }
                    }

                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }

                    string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                    if (serialize.Count() > 1)
                    {
                        if (!File.Exists(FileName))
                        {
                            File.Create(FileName).Close();
                        }
                        File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                
            } 
        }
        static void Main(string[] args)
        {
            ServiceData();
        }
    }

    public class Service_Data
    {
        private string number;
        private string city;
        private string point;
        private string street;
        private string phone;

        public string Num
        {
            get { return number; }
            set { number = value; }
        }
        public string Сity
        {
            get { return city; }
            set { city = value; }
        }
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string Rating
        {
            get { return point; }
            set { point = value; }
        }
        public string PhNumber
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}
