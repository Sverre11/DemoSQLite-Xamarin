using DemoSQLite.Droid;
using DemoSQLite.Interface;
using SQLite;
using Environment = System.Environment;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace DemoSQLite.Droid
{
    public class DatabaseConnectionAndroid:IDatabaseConnection
    {
        
        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            var conn = new SQLiteConnection(path);
            
            return conn;
        }
    }
}