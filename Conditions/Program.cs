using System;

namespace Conditions
{
    class Program
    {
        static void Main(string[] args)
        {
            var userChar = Console.ReadKey().KeyChar;

            if (userChar == '1')
            {
                // do something
            }
            else
            {
                if (userChar == '2')
                {
                    // do something
                }
                else
                {
                    if (userChar == '2')
                    {
                        // do something
                    }
                }
            }

            if (userChar == '1')
            {
                // do something
            }
            else if (userChar == '2')
            {
                // do something
            }
            else if (userChar == '3')
            {
                // do something
            }
            else
            {
            }

            switch (userChar)
            {
                case '1':
                {
                    // do something
                    break;
                }
                case '2':
                {
                    // do something
                    break;
                }
                case '3':
                {
                    // do something
                    break;
                }
                default:
                {
                    // do something
                    break;
                }
            }

            switch (userChar)
            {
                case '1':
                case '2':
                case '3':
                {
                    // do something
                    break;
                }
                default:
                {
                    // do something
                    break;
                }
            }

            var integer = 4;

            if (integer == 1)
                Console.WriteLine("Mon entier est 1");
            else if (integer == 2)
                Console.WriteLine("Mon entier est 2");
            else if (integer == 3)
                Console.WriteLine("Mon entier est 3");
            else
                Console.WriteLine("Je ne connais pas mon entier");

            // < condition > ? < cas si vrai > : < cas si faux >

            Console.WriteLine(integer == 1 ? "Mon entier est 1" :
                integer == 2 ? "Mon entier est 2" :
                integer == 3 ? "Mon entier est 3" : "Je ne connais pas mon entier");

            Console.WriteLine("Hello World!");
        }
    }
}