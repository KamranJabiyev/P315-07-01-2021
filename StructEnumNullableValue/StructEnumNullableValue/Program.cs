using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructEnumNullableValue
{
    class Program
    {
        public enum Weekday { Monday=1, Tuesday, Wednesday,Thursday,Friday,Saturday,Sunday};
        static void Main(string[] args)
        {
            #region Nullable value type
            //int? a = 5;
            //bool? test = false;
            //Print(a);
            #endregion

            #region Enum
            //int day = 2;
            //switch (day)
            //{
            //    case (int)Weekday.Monday:
            //        Console.WriteLine("Monday");
            //        break;
            //    case (int)Weekday.Tuesday:
            //        Console.WriteLine("Tuesday");
            //        break;
            //    case (int)Weekday.Wednesday:
            //        Console.WriteLine("Wednesday");
            //        break;
            //    default:
            //        Console.WriteLine("Other day");
            //        break;
            //}
            //foreach (var item in Enum.GetValues(typeof(Weekday)))
            //{
            //    Console.WriteLine((int)item);
            //}
            #endregion

            #region Struct - value
            Volume v1 = new Volume();
            Volume v2 = new Volume(10, 20, 30);
            Volume.GetVolume();
            Volume v3;
            v3.Z = 10;
            Console.WriteLine(v3.Z);
            int a = 10;
            #endregion
        }

        #region Nullable value type
        //public static void Print(int? n)
        //{
        //    if (n != null)
        //    {
        //        Console.WriteLine($"{n} id-li mehsul");
        //        return;
        //    }
        //    Console.WriteLine("Butun mehsullar");
        //}
        #endregion
    }

    #region Struct - value
    interface Test
    {
    }
    struct Volume:Test
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Z;

        public Volume(int x,int y,int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static void GetVolume()
        {
            Console.WriteLine($"I am static");
        }
    }
    #endregion
}
