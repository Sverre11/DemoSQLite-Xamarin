using System.ComponentModel;
using Prism.Mvvm;
using SQLite;

namespace DemoSQLite.Database
{
    [Table("Customers")]
    public class Customers : BindableBase

    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _companyName;
        [NotNull]
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }

        private string _address;
        [MaxLength(50)]
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
    }
}