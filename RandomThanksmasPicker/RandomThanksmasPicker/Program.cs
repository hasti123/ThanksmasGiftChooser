using System;
using System.Collections.Generic;

namespace RandomThanksmasPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = true;

            var ann = new Person("Ann");
            var davidH = new Person("DavidH");
            var charlie = new Person("Charlie");
            var emily = new Person("Emily");
            var davidK = new Person("DavidK");
            var kelly = new Person("Kelly");
            var dan = new Person("Dan");

            ann.SignificantOther = davidH;
            davidH.SignificantOther = ann;
            charlie.SignificantOther = emily;
            emily.SignificantOther = charlie;
            davidK.SignificantOther = kelly;
            kelly.SignificantOther = davidK;

            var personList = new List<Person> {ann, davidH, davidK, charlie, emily, kelly, dan};
            var pickedList = new List<Person> {ann, davidH, davidK, charlie, emily, kelly, dan};

            while (run)
            {
                Console.WriteLine("");
                Run(personList, pickedList);
                PrintResults(personList);
                Console.WriteLine();
                Console.WriteLine("Again? Y/N");
                var input = Console.ReadKey();

                if (input.Key.ToString().Equals("N"))
                {
                    run = false;
                }
                else
                {
                    pickedList = new List<Person> { ann, davidH, davidK, charlie, emily, kelly, dan };
                }
            }
        }

        private static void PrintResults(IEnumerable<Person> personList)
        {
            foreach (var person in personList)
            {
                Console.WriteLine("{0} - {1}", person.Name, person.Assignment.Name);
            }
        }

        private static void Run(IEnumerable<Person> personList, IList<Person> pickedList )
        {
            var random = new Random();
            foreach (var person in personList)
            {
                var randomNumber = random.Next(0, pickedList.Count);
                var person2 = pickedList[randomNumber];

                while (person2.Name.Equals(person.Name) && pickedList.Count > 1 && !person.IsInARelationshipWith(person2))
                {
                    randomNumber = random.Next(0, pickedList.Count);
                    person2 = pickedList[randomNumber];
                }

                person.Assignment = person2;

                pickedList.Remove(person2);
            }
        }
    }
}
