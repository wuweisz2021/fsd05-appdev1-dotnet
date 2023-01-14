

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01net_02_09_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student zs = new Student("Michael",18,'f',100,100,100);
            ////zs.Name = "A";
            ////zs.Age= 10;
            ////zs.Gender = 'a';
            ////zs.Math= 10;
            ////zs.Chinese= 10;
            ////zs.English= 10;
            //zs.SayHello();
            //zs.ShowScore();


            //Student xl = new Student("Wilson", 5, 'f', 5, 5, 5);
            ////zs.Name = "A";
            ////zs.Age= 10;
            ////zs.Gender = 'a';
            ////zs.Math= 10;
            ////zs.Chinese= 10;
            ////zs.English= 10;
            //xl.SayHello();
            //xl.ShowScore();
            //Console.ReadKey();

            Ticket t = new Ticket(300);

            t.showTicket();
            Console.ReadKey();
        }
    }
}
