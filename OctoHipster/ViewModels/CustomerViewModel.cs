﻿using System;
using Caliburn.Micro;


namespace OctoHipster.ViewModels
{
    public class CustomerViewModel : PropertyChangedBase
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth == value) return;
                _dateOfBirth = value;
                NotifyOfPropertyChange(() => DateOfBirth);
            }
        }

        string _company;
        public string Company
        {
            get { return _company; }
            set
            {
                if (_company == value) return;
                _company = value;
                NotifyOfPropertyChange(() => Company);
            }
        }

        string _contact;
        public string Contact
        {
            get { return _contact; }
            set
            {
                if (_contact == value) return;
                _contact = value;
                NotifyOfPropertyChange(() => Contact);
            }
        }
    }
}