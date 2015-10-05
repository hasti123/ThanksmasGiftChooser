using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomThanksmasPicker
{
    public class Person
    {
        public Person SignificantOther { get; set; }
        public string Name { get; set; }
        public Person Assignment { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public bool IsInARelationshipWith(Person person)
        {
            return person.Equals(SignificantOther);
        }
    }
}
