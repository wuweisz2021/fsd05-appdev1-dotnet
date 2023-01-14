using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworkday0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to do");
            Console.WriteLine("1.Add person info");
            Console.WriteLine("2.List persons info");
            Console.WriteLine("3.Find a person by name");
            Console.WriteLine("4.Find all persons younger than age");
            Console.WriteLine("0.exit");
            string inputStr = Console.ReadLine();
            try 
            {
                int input = int.Parse(inputStr);
                if(input>=0&&input<=4)
                { 
                    Console.WriteLine("choice: {0}", input);
                    switch (input)
                    {
                        case 1:

                            Person.AddPersonInfo();
                            break;
                        case 2:
                            Person.ListAllPersonInfo();
                            break;
                        case 3:
                            Person.FindPersonByName();
                            break;
                        case 4:
                            Person.FindPersonByYoungerThan();
                            break;
                        case 0:
                            Console.WriteLine("Good Bye"); 
                            break;
                    }


                    }
                    else
                    {
                        Console.WriteLine("Invalid choice try again");
                    }


            } catch (FormatException ex) 
            {
                Console.WriteLine("Error,you must input a integer number");
            }
           
            Console.ReadKey();
        }
    }
}
