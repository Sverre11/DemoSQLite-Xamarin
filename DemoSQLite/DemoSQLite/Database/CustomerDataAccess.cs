using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoSQLite.Interface;
using SQLite;
using Xamarin.Forms;

namespace DemoSQLite.Database
{
    public class CustomerDataAccess
    {
        private readonly SQLiteConnection _database;
        private static readonly object CollisionLock = new object();
        public ObservableCollection<Customers> Customers { get; set; }


        public CustomerDataAccess()
        {
            _database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _database.CreateTable<Customers>();

            this.Customers = new ObservableCollection<Customers>(_database.Table<Customers>());

            if (!_database.Table<Customers>().Any())
            {
                AddNewCustomers();
            }
        }

        private void AddNewCustomers()
        {            
            List<Customers> list = new List<Customers>()
            {
                new Customers(){CompanyName = "Company Name 1",Address = "Address 1",Country = "Country 1",},
                new Customers(){CompanyName = "Company Name 2",Address = "Address 2",Country = "Country 2",},
                new Customers(){CompanyName = "Company Name 3",Address = "Address 3",Country = "Country 3",},
                new Customers(){CompanyName = "Company Name 4",Address = "Address 4",Country = "Country 4",},
                new Customers(){CompanyName = "Company Name 5",Address = "Address 5",Country = "Country 5",}
            };

            foreach (var customer in list)
            {
                //this.Customers.Add(customer);
                _database.Insert(customer);
            }
           
        }

        public IEnumerable<Customers> GetAll()
        {
            lock (CollisionLock)
            {
                var query = (from cust in _database.Table<Customers>()
                            select cust).ToList();
                return query;
            }
        }



        //USING LINQ
        public IEnumerable<Customers> GetFilteredCustomers(string countryName)
        {
            lock (CollisionLock)//Lock Collision to avoid Database Collision??
            {
                var query = (from cust in _database.Table<Customers>()
                            where cust.Country == countryName
                            select cust);
                return query.AsEnumerable();
            }
        }

        //USING SQL QUERIES
        public IEnumerable<Customers> GetFilteredCustomers2()
        {
            lock (CollisionLock)
            {
                return _database.Query<Customers>("SELECT * FROM Item WHERE Country = 'Country 5'").AsEnumerable();
            }
        }


    }
}