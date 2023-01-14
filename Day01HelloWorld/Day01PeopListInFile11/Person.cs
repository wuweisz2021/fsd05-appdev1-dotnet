using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day01PeopListInFile11
{

    internal class Person
    {

        public string _name;
        public string Name 
        {
            get { return _name; }
            set {
                if(value.Length < 2 || value.Length>100||value.Contains(";"))
                {
                    throw new ArgumentException("Name Must be 2-100 charaters,no semicolons");

                }
                
                _name = value; }
        }

        public int _age;

        public int Age 
        {
            get { return _age; }
            set { if(value <0||value>150)
                        
                {
                    throw new ArgumentException("Age must be 0-150");
                }
                
                _age = value; }
        }
       

        private string _city;
        public string City
        {
            get { return _city; }
            set {
                if (!Regex.IsMatch(value, @"^[^;]{2,100}$")) 
                {
                    throw new ArgumentException("City must be 2-100 characters, no semicolons");
                } 
                
                _city= value; }
        }

        public Person(string name, int age, string city)
        {
            this.Name = name;
            Age = age;
            City = city;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Name} is {Age} from {City}";
        }
    }



}


