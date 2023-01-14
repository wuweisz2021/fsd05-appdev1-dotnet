using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworkday0
{
    public class Person
    {

        public Person(string name,int age,string city) 
        {
            Name = name;
            Age = age;
            City = City;
        }

        private string _name;
        public string Name 
        {
            get { return _name; }
            set {
                if (value.Length > 100 || value.Length < 2 || value.Contains(";"))
                {
                    throw new ArgumentException("must 2-100 characters long, now semicolons");
                }
                _name = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set {
                if (value > 0 && value < 150) 
                { _age = value; }
                else 

                { throw new ArgumentOutOfRangeException(nameof(value), "age must be 0-150"); }
                    }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (value.Length > 100 || value.Length < 2 || value.Contains(";"))

                { throw new ArgumentException("must 2-100 charters, no semico"); }
                _city = value;
            }
        }


        public static void AddPersonInfo(List<Person> list)
        {
            Console.WriteLine("please add person information");
            Console.WriteLine("Enter a name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            string ageStr = Console.ReadLine();

            int age = int.Parse(ageStr);

            Console.WriteLine("Enter a city:");
            string city = Console.ReadLine();
            //list.Add(new Person() { Name = name, Age = age, City = city });

        }

        public static void ListAllPersonInfo()
        {
            Console.WriteLine("List all person information");
        }

        public static void FindPersonByName()
        {
            Console.WriteLine("Find Person by Name");
        }

        public static void FindPersonByYoungerThan()
        {
            Console.WriteLine("Find Person by Younger Than");
        }

    }
}
