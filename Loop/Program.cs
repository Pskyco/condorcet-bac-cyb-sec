using System;
using System.Collections.Generic;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = new List<int>()
            {
                1,
                2,
                3,
                4
            };

            for (int i = 0; i < integers.Count; i++)
            {
                Console.WriteLine(integers[i]);
            }

            int y = 0;
            foreach (var integer in integers)
            {
                if (integer == 2)
                    continue; // skip "2" => print 1,3,4 (T2)

                if (integer >= 3)
                    break; // skip all numbers above 3 => print 1 (T3)
                
                Console.WriteLine(integer); // print 1,2,3,4 (T1)
                y++;
            }

            char userChar = 'y';
            while(userChar != 'n')
            {
                userChar = Console.ReadKey().KeyChar;
                Console.WriteLine($"Vous avez entré: {userChar}");
            }
            
            while(true)
            {
                userChar = Console.ReadKey().KeyChar;

                if (userChar == 'n')
                    break;
                    
                Console.WriteLine($"Vous avez entré: {userChar}");
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}