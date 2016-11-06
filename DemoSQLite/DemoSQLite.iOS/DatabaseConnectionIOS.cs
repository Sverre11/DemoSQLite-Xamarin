using System;
using System.IO;
using System.Reflection;
using DemoSQLite.iOS;
using DemoSQLite.Interface;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionIos))]
namespace DemoSQLite.iOS
{
    
    public class DatabaseConnectionIos:IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryfolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryfolder, dbName);

            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}