﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03ListGridPeople
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static bool IsNameValid(string name, out string error)
        {
            if (name.Length < 2 || name.Length>50 || name.Contains(";")) 
            {
                error = " Name must be 2-50 charactors";
                return false;
            
            }
            error = null;
            return true; // FIXME: Name must be 2-50 characters long, no semicolons
        }

        public static bool IsAgeValid(string strAge, out string error)
        {
            if(!int.TryParse(strAge,out int age))
            {
                error = "Age must be an integer number";
                return false;
            }

            if(age <0 || age > 150)
            {
                error = "Age must be 0-150";
                return false;
            }
            error = null;
            return true; // FIXME: Age must be 0-150
        }

        public override string ToString()
        {
            return $"{Name},{Age}";
        }

    }
}
