using SQLite;

namespace DemoSQLite.Interface
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}