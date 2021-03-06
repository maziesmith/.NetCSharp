﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseGenericList();
            //GenericStack();
            //UseGenericQueue();
            //UseSortedSet();
            UseGenericDictionoary();
            Console.ReadKey();
        }

        static void UseGenericList()
        {
            //Make a List of Person objects, filled with
            //collection/objectinit syntax
            List<Person> people = new List<Person>() {
                new Person{FirstName="Homer",LastName="Simpson",Age = 47 },
                new Person{FirstName="Marge",LastName="Simpson",Age = 45 },
                new Person{FirstName="Lisa",LastName="Simpson",Age = 9 },
                new Person{FirstName="Bart",LastName="Simpson",Age = 8 }
            };

            //Print out number of items in list
            Console.WriteLine($"Items in list {people.Count}");

            //Enumerate over list
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }

            //Insert a new Person.
            Console.WriteLine("\n-> Inserting new person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine($"Items in list {people.Count}");

            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++)
            {
                Console.WriteLine($"First Names: {arrayOfPeople[i].FirstName}");
            }
        }

        static void GenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person
            { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person
            { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person
            { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            //Now lok at the top item, pop it and look again
            Console.WriteLine($"First person is: {stackOfPeople.Peek()}");
            Console.WriteLine($"Popped of {stackOfPeople.Pop()}");
            Console.WriteLine($"\nFirst person is: {stackOfPeople.Peek()}");
            Console.WriteLine($"Popped of {stackOfPeople.Pop()}");
            Console.WriteLine($"\nFirst person is: {stackOfPeople.Peek()}");
            Console.WriteLine($"Popped of {stackOfPeople.Pop()}");

            try
            {
                stackOfPeople.Pop();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError! {0}", e.Message);
            }
        }

        static void UseGenericQueue()
        {
            //Make a Q with three people
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person
            {
                FirstName = "Homer",
                LastName = "Simpson",
                Age = 47
            });
            peopleQ.Enqueue(new Person
            {
                FirstName = "Marge",
                LastName = "Simpson",
                Age = 45
            });
            peopleQ.Enqueue(new Person
            {
                FirstName = "Lisa",
                LastName = "Simpson",
                Age = 9
            });

            //Peek at first person in Q
            Console.WriteLine($"{peopleQ.Peek()} is first in line");

            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
        }
        static void GetCoffee(Person p)
        {
            Console.WriteLine($"{p.FirstName} is next to get coffee");
        }
        static void UseSortedSet()
        {
            //Makes some people with different ages.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge()) {
        new Person{FirstName="Homer",LastName="Simpson",Age=47 },
        new Person{FirstName="Marge",LastName="Simpson",Age=45 },
        new Person{FirstName="Lisa",LastName="Simpson",Age=9 },
        new Person{FirstName="Bart",LastName="Simpson",Age=8 }
            };

            //Note the items are sorted by age
            Console.WriteLine("**** Fun with Generic Collection ****");
            foreach (Person p in setOfPeople)
                Console.WriteLine(p);

            //add a few people
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Miku", LastName = "Jones", Age = 32 });

            //still sorted
            Console.WriteLine("\nStill sorted");
            foreach (Person p in setOfPeople)
                Console.WriteLine(p);
        }

        static void UseGenericDictionoary()
        {

            //Populate using Add() method
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
            peopleA.Add("Homer",new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleA.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleA.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            //get Homer
            Person Homer = peopleA["Homer"];
            Console.WriteLine(Homer);

            //Populate with initialization syntax
            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
            {
                {"Homer", new Person{ FirstName= "Homer", LastName="Simpson",Age=47} },
                { "Marge", new Person{FirstName="Marge",LastName="Simpson",Age=45 } },
                { "Lisa", new Person{ FirstName="Lisa",LastName="Simpson",Age=9} }
            };

            //Get Lisa
            Person Marge = peopleB["Marge"];
            Console.WriteLine(Marge);

            //Populate using dictionary initialization
            Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }

            };

            Person Lisa = peopleC["Lisa"];
            Console.WriteLine(Lisa);
        }
    }

}

