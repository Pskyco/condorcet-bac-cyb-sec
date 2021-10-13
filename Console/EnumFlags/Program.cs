using System;
using EnumFlags.Enums;

namespace EnumFlags
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int val = 0; val <= 15; val++)
                Console.WriteLine("{0} - {1:G}", val, (ColorEnum) val);

            var enumProp = ColorEnum.Black | ColorEnum.Blue;
            Console.WriteLine($"{((int) enumProp)} {enumProp}");

            Console.ReadKey();
        }
    }
}