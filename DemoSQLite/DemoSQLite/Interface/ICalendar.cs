using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using DemoSQLite.Database;

namespace DemoSQLite.Interface
{
    public interface ICalendar
    {
        bool AddToCalendar(CalendarModel calendarModel);
    }
}