using ConsoleApp.Helpers;
using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public enum Menu { CreateGroup=1,CreateStudent,StudentList,SearchByName}
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            bool isNumber;
            while (true)
            {
                Helper.Print(ConsoleColor.Green, "Qrup yarat - 1; Telebe yarat - 2; Telebe siyahisi - 3;" +
                    "Ada gore axtarish - 4; Chixish - 5") ;
                string result = Console.ReadLine();
                int menu;
                isNumber = int.TryParse(result, out menu);
                if (isNumber)
                {
                    if (menu >= 5)
                    {
                        Helper.Print(ConsoleColor.Cyan,"Bizi shechdiyiniz uchun teshekkurler");
                        break;
                    }
                    switch (menu)
                    {
                        case (int)Menu.CreateGroup:
                            //Qrup adinin bosh olub olmamasini yoxlamaq
                            Helper.Print(ConsoleColor.Green, "Qrup adi daxil edin:");
                            string name = Console.ReadLine().Trim();
                            if (String.IsNullOrEmpty(name))
                            {
                                Helper.Print(ConsoleColor.Red, "Qrup adi daxil etmelisiniz!!!");
                                goto case (int)Menu.CreateGroup;
                            }
                            //eyni adli ikinci qrup yaratmagin qarshisini almaq
                            foreach (Group gr in groups)
                            {
                                if (gr.Name.ToLower() == name.ToLower())
                                {
                                    Helper.Print(ConsoleColor.Red, $"{name} adli qrup movcuddur");
                                    goto case (int)Menu.CreateGroup;
                                }
                            }
                            //MaxCount reqem daxil edib etmemesini yoxlamaq
                            MaxCount:
                            Helper.Print(ConsoleColor.Green, "Maksimum telebe sayini daxil edin:");
                            string res = Console.ReadLine();
                            int maxCount;
                            isNumber = int.TryParse(res, out maxCount);
                            if (!isNumber)
                            {
                                Helper.Print(ConsoleColor.Red, "Eded daxil edin!!!");
                                goto MaxCount;
                            }
                            //her shey qaydasindadir,qrup yaradilir
                            Group group = new Group(name, maxCount);
                            Array.Resize(ref groups, groups.Length + 1);
                            groups[groups.Length - 1] = group;
                            Helper.Print(ConsoleColor.Green, $"{name} adli qrup yaradildi");
                            break;
                        case (int)Menu.CreateStudent:
                            //Telebe adini yoxlamaq
                            Helper.Print(ConsoleColor.Green, "Telebe adini daxil edin:");
                            string stuName = Console.ReadLine().Trim();
                            if (String.IsNullOrEmpty(stuName))
                            {
                                Helper.Print(ConsoleColor.Red, "Telebe adi daxil etmelisiniz!!!");
                                goto case (int)Menu.CreateStudent;
                            }

                            //Telebe soyadini yoxlamaq
                            stuSurname:
                            Helper.Print(ConsoleColor.Green, "Telebe adini daxil edin:");
                            string stuSurname = Console.ReadLine().Trim();
                            if (String.IsNullOrEmpty(stuSurname))
                            {
                                Helper.Print(ConsoleColor.Red, "Telebe soyadini daxil etmelisiniz!!!");
                                goto stuSurname;
                            }

                            //Telebe yaratmaq
                            Student student = new Student(stuName,stuSurname);

                            //Elave olunacagi qrup
                            grName:
                            Helper.Print(ConsoleColor.Green, "Movcud qruplardan birini sechin:");
                            foreach (Group gr in groups)
                            {
                                Helper.Print(ConsoleColor.Blue, gr.Name);
                            }
                            string grName = Console.ReadLine().Trim();
                            bool isExist = false;
                            foreach (Group gr in groups)
                            {
                                if (gr.Name.ToLower() == grName.ToLower())
                                {
                                    isExist = true;
                                    gr.AddStudent(student);
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                Helper.Print(ConsoleColor.Red, "Qrup adini duzgun daxil edin!!!");
                                goto grName;
                            }
                            break;
                        case (int)Menu.StudentList:
                            foreach (Group gr in groups)
                            {
                                gr.ShowAllStudents();
                            }
                            break;
                        case (int)Menu.SearchByName:
                            //axtarish etdiyimiz ad
                            Helper.Print(ConsoleColor.Green, "Axtardiginiz telebe adini daxil edin:");
                            string searchName = Console.ReadLine();
                            if (String.IsNullOrEmpty(searchName))
                            {
                                Helper.Print(ConsoleColor.Red, "Duzgun daxil edin!!!");
                                goto case (int)Menu.SearchByName;
                            }
                            //qruplarin hamisinda axtarish
                            foreach (Group gr in groups)
                            {
                                foreach (Student stu in gr.Search(searchName))
                                {
                                    Helper.Print(ConsoleColor.Yellow, $"{gr.Name} - {stu}");
                                }
                            }
                            break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Zehmet olmasa gosterilen ededlerden sechin!");
                }
            }
        }
    }
}
