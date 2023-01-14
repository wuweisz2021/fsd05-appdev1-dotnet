using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01TextFile11
{
    internal class Program
    {
        static void Main(string[] args)
        {


            try 
            { 
            const string fileName = @"..\..\data.txt";
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();




                // approach 1: one-step write all
                try { 

                string[] nameArray = {name,name,name};
                File.WriteAllLines(fileName, nameArray);
                }
                catch (SystemException ex) 
                {
                    Console.WriteLine("Error writing to file:" + ex.Message);
                }

                //StreamWriter sw = null;

                //try { 
                //sw = new StreamWriter(fileName);
                //sw.WriteLine(name);
                //}
                //finally                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                //{
                //    //if(sw != null) 

                //    { sw.Close(); }

                //}
                //    try { 
                ////{ 
                ////    Console.WriteLine("Exception:" + ex.Message);
                ////}
                //using (StreamWriter sw = new StreamWriter(fileName))
                //{
                //    sw.WriteLine(name);
                //}

                //}
                //catch (SystemException ex) { Console.WriteLine("File writing exception:" + ex.Message); }


                // read it // approach 1
                try {
                string[] lineArray = File.ReadAllLines(fileName);
                foreach (string line in lineArray)
                {
                    Console.WriteLine(line);
                }

                // read it // approach 2

                string allcontent = File.ReadAllText(fileName);
                Console.WriteLine(allcontent);

                }
                catch (SystemException ex)// (IO exception ex)
                {
                    Console.WriteLine("Error writing exception:" + ex.Message);
                }

            }

            finally { Console.ReadKey(); }
            
        }
    }
}
