using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    partial class Group
    {
        public string Name { get; set; }
        public int MaxStuCount { get;}
        private Student[] students;
        private static int count = 0;
        public readonly int Id;
        public Group()
        {
            students = new Student[0];
            count++;
            Id = count;
        }

        public Group(string name,int maxStuCount) : this()
        {
            Name = name;
            MaxStuCount = maxStuCount;
        }
    }
}
