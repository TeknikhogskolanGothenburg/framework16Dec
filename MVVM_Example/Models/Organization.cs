using MVVM_Example.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.Models
{
    public class Organization
    {
        public List<Person> People { get; set; }

        public Organization()
        {
            People = FakeService.GetPeople();
        }

        public void Add(Person person)
        {
            if(!People.Contains(person))
            {
                People.Add(person);
                FakeService.Write(person);
            }
        }

        public void Delete(Person person)
        {
            if(People.Contains(person))
            {
                People.Remove(person);
                FakeService.Delete(person);
            }
        }

        public void Update(Person person)
        {
            FakeService.Write(person);
        }
    }
}
