﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using OctoHipster.Services;

namespace OctoHipster.ViewModels
{
    public interface IShellViewModel
    {
        bool IsLoading { get; }
        string SearchText { get; set; }
        ObservableCollection<CustomerViewModel> MatchingCustomers { get; }
    }

    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        readonly CustomerService _customerService;

        public ShellViewModel(CustomerService customerService, OrderService orderService)
        {
            _customerService = customerService;

            MatchingCustomers = new ObservableCollection<CustomerViewModel>();
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            private set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        string _searchText;
        private bool _isLoading;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                // hahahaha this is just horrible
                // do not try this at home
                // use proper commanding
                UpdateSearchResults(value);
            }
        }

        // TPL nerd notes - with .NET 4.5, exceptions
        // raised by awaitable tasks are handled if you
        // the method signature is "async Task" - so they'll
        // be swallowed here and not bring down the app

        // for the purposes of evil, I'm going to use
        // "async void" here because I want to demo
        // how commands *should* handle exceptions
        async void UpdateSearchResults(string value)
        {
            MatchingCustomers.Clear();

            if (String.IsNullOrWhiteSpace(value)) return;

            IsLoading = true;

            var customers = await _customerService.GetByName(value);

            foreach (var c in customers)
            {
                MatchingCustomers.Add(new CustomerViewModel
                {
                    Name = c.Name,
                    Company = c.Company,
                    Contact = c.Contact,
                    DateOfBirth = c.DateOfBirth
                });
            }

            IsLoading = false;
        }

        public ObservableCollection<CustomerViewModel> MatchingCustomers { get; private set; }
    }
}
