using System;
using System.Collections.Generic;
using System.Linq;
using Array.Classes;

namespace Array
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
                4,
                5
            };
            Console.WriteLine(integers.Count); // 5
            integers.Add(6);
            integers.Add(7);
            Console.WriteLine(integers.Count); // 7

            Console.WriteLine(integers[0]); // print "1"
            Console.WriteLine(integers[6]); // print "7"
            //Console.WriteLine(listInt[156]); // print "Index out of bounds (exception)"

            var listObject = new List<object>();
            listObject.Add(1);
            listObject.Add(true);
            listObject.Add("string");
            listObject.Add('a');

            var person1 = new Person()
            {
                FirstName = "Ludwig",
                LastName = "Lebrun",
                NationalNumber = "00000011122"
            };

            var person2 = new Person()
            {
                FirstName = "Ludwig 2",
                LastName = "Lebrun",
                NationalNumber = "00000011133"
            };

            var person3 = new Person()
            {
                FirstName = "Ludwig 3",
                LastName = "Lebrun",
                NationalNumber = "00000011144"
            };

            var persons = new List<Person>()
            {
                person1,
                person2,
                person3
            };
            Console.WriteLine(persons[1].NationalNumber);

            var searchedNationalNumber = "00000011144";
            foreach (var person in persons)
            {
                if (person.NationalNumber == searchedNationalNumber)
                {
                    Console.WriteLine("Found!");
                    break;
                }
            }
            //var searchedPerson = persons.FirstOrDefault(x => x.NationalNumber == searchedNationalNumber);
            
            // quick access to person with NN "00000011144"
            var dico = new Dictionary<string, Person>();
            dico.Add(person1.NationalNumber, person1);
            dico.Add(person2.NationalNumber, person2);
            dico.Add(person3.NationalNumber, person3);

            var dico2 = new Dictionary<int, List<Person>>();
            dico2.Add(1, new List<Person>()
            {
                person1,
                person2,
                person3
            });

            var dico3 = new Dictionary<int, Dictionary<string, Person>>();
            dico3.Add(7000, dico);
            dico3.Add(7021, dico);
            //dico3[7024]["00000011144"]; // throws exception "dictionary does not contains key '7024'"

            //dico3[7021]["00000011144"];
            if (dico3.ContainsKey(7021))
            {
                if(dico3[7021].ContainsKey("00000011144"))
                    Console.WriteLine(dico3[7021]["00000011144"]);
            }
            
            // dico3.Add(7000, dico); // throws exception "dictionary already contains keys '7000'"
            if (dico3.TryAdd(7000, dico))
            {
                // ... happy flow
            }
            else
            {
                Console.WriteLine("Cette clé n'a pas été ajoutée car elle existait déjà");
            }
            
            // same as upper
            if(!dico3.ContainsKey(7000))
                dico3.Add(7000, dico);

            dico3.Remove(7021);
            
            Console.WriteLine($"Requested person is : {dico[searchedNationalNumber]}");
            
            // var test = persons.Select(x => new
            // {
            //     id = 1,
            //     prop1 = "",
            //     prop2 = ""
            // }).ToList();
            
            // var t = (Sum: 4.5, Count: 3);
            // Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");
            
            Console.WriteLine("Hello World!");
        }
    }
}