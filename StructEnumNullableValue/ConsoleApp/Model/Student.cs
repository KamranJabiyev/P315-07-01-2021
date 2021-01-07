using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private static int count=0;
        public readonly int Id;
        public Student()
        {
            count++;
            Id = count;
        }

        public Student(string name,string surname):this()
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}";
        }
    }
}
