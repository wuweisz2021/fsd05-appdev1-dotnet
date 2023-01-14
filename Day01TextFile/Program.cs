using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "..\\..\\data.txt";
            Console.WriteLine("What is your name");
            string name = Console.ReadLine();
             StreamWriter sw = new StreamWriter(fileName);
            //write a line of text
            sw.WriteLine(name);
            sw.WriteLine(name);
            sw.WriteLine(name);
            sw.Close();


        }
    }
}
