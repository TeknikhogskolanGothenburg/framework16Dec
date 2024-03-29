﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Example.ViewModels
{
    public class NotificationBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            RaisePropertyChanged(property);
            return true;
        }

        protected bool SetProperty<T>(T currentValue, T newValue, Action DoSet,
           [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue)) return false;
            DoSet.Invoke();
            RaisePropertyChanged(property);
            return true;
        }

        protected void RaisePropertyChanged(String property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    public class NotificationBase<T> : NotificationBase where T : class, new()
    {
        protected T This;
        public static implicit operator T(NotificationBase<T> value)
        {
            return value.This;
        }

        public NotificationBase(T value = null)
        {
            This = (value == null) ? new T() : value;
        }
    }

}
