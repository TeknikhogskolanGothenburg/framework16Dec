﻿using MVVM_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.ViewModels
{
    public class PersonViewModel: NotificationBase<Person>
    {
        public PersonViewModel(Person person = null) : base(person) { }

        public String Name
        {
            get { return This.Name; }
            set { SetProperty(This.Name, value, () => This.Name = value); }
        }
        public int Age
        {
            get { return This.Age; }
            set { SetProperty(This.Age, value, () => This.Age = value); }
        }
    }
}
