using System;

namespace _4Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {

            Student student = new Student();
            Console.WriteLine("Name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("LastName: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Group: ");
            student.Group = Console.ReadLine();
            Console.WriteLine("Year: ");
            student.Year = Console.ReadLine();
            Console.WriteLine("Adress: ");
            student.Adress = Console.ReadLine();
            Console.WriteLine("Passport: ");
            student.Passport = Console.ReadLine();
            Console.WriteLine("Age: ");
            student.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Telephone: ");
            student.Telephone = Console.ReadLine();
            Console.WriteLine("Rating: ");
            student.Rating = Convert.ToDouble(Console.ReadLine());
            student_rating(student.Rating);
        }


        public static int student_rating(double Rating)
        {
            if (Rating >= 90)
            {
                Console.WriteLine("Congratulations to an excellent student!");
                return 1;
            }
            else if (Rating > 75 && Rating < 90)
            {
                Console.WriteLine("You can study harder");
                return 2;
            }
            else
            {
                Console.WriteLine("You should study more!");

                return 3;
            }
        }
    }

    class Student
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }
        private string group;
        public string Group
        {
            get
            {
                return group;
            }

            set
            {
                group = value;
            }
        }
        private string year;

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }
        private string adress;
        public string Adress
        {
            get
            {
                return adress;
            }

            set
            {
                adress = value;
            }
        }
        private string passport;
        public string Passport
        {
            get
            {
                return passport;
            }

            set
            {
                passport = value;
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }
        private string telephon;
        public string Telephone
        {
            get
            {
                return telephon;
            }

            set
            {
                telephon = value;
            }
        }
        private double rating;
        public double Rating
        {
            get
            {
                return rating;
            }

            set
            {
                rating = value;
            }
        }
    }
}
