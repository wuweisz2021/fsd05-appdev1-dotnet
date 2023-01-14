using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopListInFile11
{
   

    internal class Program
    {
        static List<Person> People = new List<Person>();
        const string DataFileName = @"..\..\people.txt";
        private static int getMenuChoice()
        {
            Console.WriteLine("What do you want to do?\n" +
                "1.Add person info\n" +
                "2.List persons info\n" +
                "3.Find and List a person by name\n" +
                "4.Find and list persons younger than\n" +
                "0.Exit\n" +
                "Choice: ");
            return (int.TryParse(Console.ReadLine(),out int choice))?choice: -1;
        }

     
            
        private static void AddPersonInfo()
        {

            try { 
            Console.WriteLine("Adding a person:");
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city:");
            string city = Console.ReadLine();
            Person person = new Person(name,age,city);
            People.Add(person);
                Console.WriteLine("Person added");
        } catch(ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        catch (Exception ex) when (ex is FormatException|| ex is OverflowException)
         
            {
                Console.WriteLine("Error: invalid numerical input");
            }


        }

        private static void ListAllPersonInfo()

        {
            Console.WriteLine("List All persons");
            foreach (Person person in People)
            {
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
                Console.WriteLine(person.City);
                Console.WriteLine(person.ToString());

            }
        
        }


        public static void FindPersonByName() 
        {
            Console.WriteLine("Enter partical person name:");
            string searchStr = Console.ReadLine();
            //select from people where the name contain  serachStr  
            // signle query run query in memory as no database

            //var add compulation type to figture out  what type of this expresion, and type can
            // not be changed 
            //VAR可代替任何类型，编译器会根据上下文来判断你到底是想用什么类型，类似 OBJECT，但是效率比OBJECT高点。
            //var b =“2”;

//            因为给b的值是"2"这样一个字符串,所以,b就是string类型…

//Ps.当你无法确定自己将用的是什么类型,就可以使用VAR

//使用var定义变量时有以下四个特点：

//1.必须在定义时初始化。也就是必须是var s = “abcd”形式，而不能是如下形式：
//　　 var s;
//            s = “abcd”;
//            2.一但初始化完成，就不能再给变量赋与初始化值类型不同的值了。
//　　3.var要求是局部变量。
//4.使用var定义变量和object不同，它在效率上和使用强类型方式定义变量完全一样。


            var matchesList = People.Where(p => p.Name.Contains(searchStr)).ToList();//Link
            //List<Person> matchesList2 = People.Where(p => p.Name.Contains(searchStr)).ToList();
            if (matchesList.Count > 0)
            {
                Console.WriteLine("Matches found:");
                foreach(Person person in matchesList)
                {
                    Console.WriteLine(person);
                }
                
            }
            else 
            {
                Console.WriteLine("No mathche found");
            }


        }


        private static void FindPersonYoungerThan()
        {
            Console.WriteLine("Enter maximum age:");
            if(!int.TryParse(Console.ReadLine(),out int MaxAge))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            //using a foreach loop with a condition
            Console.WriteLine("People is at that age or younger:");

            foreach(Person person in People) 
            {
                if (person.Age <= MaxAge) 
                {
                    Console.WriteLine(person);
                }
                
            }

            //using LinQ
            Console.WriteLine("Peopler is at that age or younger:");

            var youngerList = People.Where(p=>p.Age <=MaxAge).ToList();
            //var youngerLinst2 = from p in People where p.Age <= MaxAge select p; 

            foreach(Person person in youngerList)
            {
                Console.WriteLine(person);
            }

        }



        private static void SaveAllPeopleToFile() 
        {
            try {
            List<string> list = new List<string>();
            foreach(Person person in People)
            {
                list.Add($"{person.Name},{person.Age},{person.City}");
                File.WriteAllLines(DataFileName,list);
            }
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            { Console.WriteLine("Error writing file: " + ex.Message); }


        }


        private static void ReadAllPeopleFormFile()
        {
            try {
                if (!File.Exists(DataFileName))
                {
                    return;// it's OK if the file does not exsit yet
                }


               
                string[] lineArray = File.ReadAllLines(DataFileName);
                    foreach (string line in lineArray)
                    {

                    try { 
                    string[] data = line.Split(',');
                        if (data.Length != 3)
                        {
                            throw new Exception("Invalid number of items");
                            //Console.WriteLine("Error...");continue;
                        }

                        string name = data[0];
                        int age = int.Parse(data[1]);
                        string city = data[2];
                        Person person = new Person(name, age, city);
                        People.Add(person);

                    }
                    catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
                    {
                        Console.WriteLine($"Error (skpping line):{ex.Message} in : \n {line}");
                    }
                }
               
            }
            catch (Exception ex) when(ex is IOException || ex is SystemException)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            //ReadAllPeopleFormFile();
            while(true)
            {
                //field
                //static List<Person> People = new List<Person>();

                int choice = getMenuChoice();
                switch (choice)
                {
                    case 1:
                        AddPersonInfo();
                        break;
                    case 2:
                        ListAllPersonInfo();
                        break;
                    case 3:

                        FindPersonByName();
                        break;
                    case 4:

                        FindPersonYoungerThan();
                        break;
                    case 0:
                        SaveAllPeopleToFile();
                        return;// exit the program

                    default:
                        Console.WriteLine("No such option, try again");
                        break;
                }




            }

        }
    }
}
