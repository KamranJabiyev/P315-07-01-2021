using ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    partial class Group
    {
        public override string ToString()
        {
            return Name;
        }

        public void AddStudent(Student student)
        {
            if (students.Length == MaxStuCount)
            {
                Helper.Print(ConsoleColor.Red, $"{Name} qrupu doludur,zehmet olmasa bashqa qrup sechin!");
                return;
            }
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = student;
            Helper.Print(ConsoleColor.Green, $"{student.Name} adli telebe {Name} qrupuna elave olundu.");
        }

        public void ShowAllStudents()
        {
            Helper.Print(ConsoleColor.Blue, $"{Name} qrupunun siyahisi:");
            foreach (Student stu in students)
            {
                Console.WriteLine(stu);
            }
        }

        public Student[] Search(string name)
        {
            Student[] result = new Student[0];
            foreach (Student item in students)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = item;
                }
            }
            return result;
        }
    }
}
