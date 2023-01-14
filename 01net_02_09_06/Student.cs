using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01net_02_09_06
{
    public class Student
    {

        public Student(string name, int age, char gender, int chinese, int math, int english)
        {
            this.Name= name;
            this.Age= age;
            this.Gender= gender;
            this.Chinese= chinese;
            this.English= english;
            this.Math= math;

        }

        public Student(string name, int chinese, int math, int english):this(name,0,'c',chinese,math,english)
        { 
        
        }
      

        private string _name;
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _age;
        public int Age { get { return _age; } set {
                if (value < 0||value>100) { value = 0; }
                _age = value; } }

        private char _gender;
        public char Gender { 
            get { if(_gender != 'm' && _gender != 'f') { return _gender = 'f';}
                
                return _gender;}
            set{_gender = value;} }

        private int _chinese;
        public int Chinese { get { return _chinese; }
            set{ _chinese = value;}
        }

        private int _math;
        public int Math { get { return _math;}
            set
            { _math = value; } }
        private int _english;
        public int English { get { return _english;}
            set
            {_english = value; } }

        public void SayHello()
        {
            Console.WriteLine("my name is {0}, I am {1} year old, 我是 ", this.Name, this.Age,this.Gender);
        }

        public void ShowScore()
        {
            Console.WriteLine("my name is {0},my total score is {1},the average score is {2}", this.Name, this.English + this.Math + this.Chinese, (this.English + this.Math + this.Chinese)/3);
        }
    }
}
