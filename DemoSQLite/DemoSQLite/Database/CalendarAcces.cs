using System.Diagnostics;
using System.Threading.Tasks;
using DemoSQLite.Interface;
using Prism.Services;

namespace DemoSQLite.Database
{
    public class CalendarAccess
    {
        
        public CalendarAccess(CalendarModel calendarModel)
        {
            //var _calendar = new DependencyService().Get<ICalendar>().AddToCalendar(calendarModel);
            var calendar = new DependencyService().Get<ICalendar>().AddToCalendar(calendarModel);
            Debug.WriteLine(calendar);            
        }

        
    }
}