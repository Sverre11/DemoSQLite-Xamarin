using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using DemoSQLite.Database;

namespace DemoSQLite.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Customers> _cCollection = new ObservableCollection<Customers>();
        public ObservableCollection<Customers> CCollection   
        {
            get { return _cCollection; }
            set { SetProperty(ref _cCollection, value); }
        }

        public MainPageViewModel()
        {
            TestDatabase();
        }

        private void TestDatabase()
        {
            CustomerDataAccess db = new CustomerDataAccess();
            var x = db.GetAll();

            
            


            foreach (var c in x)
            {
                Debug.WriteLine($"Company: {c.CompanyName}, Address: {c.Address}, Country {c.Country} ");
                CCollection.Add(c);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
