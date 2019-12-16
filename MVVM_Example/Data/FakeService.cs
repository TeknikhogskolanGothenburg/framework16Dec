using MVVM_Example.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.Data
{
    public class FakeService
    {
        public static string Name = "Fake Data Service";
        public static List<Person> GetPeople()
        {
            Debug.WriteLine("GET for people");
            return new List<Person>()
            {
                new Person(){Name="Anna Panna", Age=45},
                new Person(){Name="Billy Bob", Age=34},
                new Person(){Name="Calle Karlsson", Age=65}
            };
        }

        public static void Write(Person person)
        {
            Debug.WriteLine("INSERT person with name " + person.Name);
        }

        public static void Delete(Person person)
        {
            Debug.WriteLine("DELETE person with name " + person.Name);
        }
    }
}
