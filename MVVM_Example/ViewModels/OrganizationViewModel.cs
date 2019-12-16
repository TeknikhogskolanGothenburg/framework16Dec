using MVVM_Example.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.ViewModels
{
    public class OrganizationViewModel : NotificationBase
    {
        Organization organization;

        public OrganizationViewModel()
        {
            organization = new Organization();
            _selectedIndex = -1;
            foreach(var person in organization.People)
            {
                var np = new PersonViewModel(person);
                np.PropertyChanged += Person_OnNotifyPropertyChanged;
                _people.Add(np);
            }

        }

        ObservableCollection<PersonViewModel> _people =
            new ObservableCollection<PersonViewModel>();
       
        public ObservableCollection<PersonViewModel> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (SetProperty(ref _selectedIndex, value))
                {
                    RaisePropertyChanged(nameof(SelectedPerson));
                }
            }
        }

        public PersonViewModel SelectedPerson 
        {
            get { return (_selectedIndex >= 0 && _selectedIndex < _people.Count) ? _people[_selectedIndex] : null; }  
        }

        public void Add()
        {
            var person = new PersonViewModel();
            person.PropertyChanged += Person_OnNotifyPropertyChanged;
            People.Add(person);
            organization.Add(person);
            SelectedIndex = People.IndexOf(person);
        }

        public void Delete()
        {
            if(SelectedIndex != -1)
            {
                var person = People[SelectedIndex];
                People.RemoveAt(SelectedIndex);
                organization.Delete(person);
            }
        }

        void Person_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs _)
        {
            organization.Update((PersonViewModel)sender);
        }



    }
}
