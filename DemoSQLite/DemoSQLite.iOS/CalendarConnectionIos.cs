using System.Diagnostics;
using AudioToolbox;
using DemoSQLite.Database;
using DemoSQLite.Interface;
using EventKit;
using Foundation;
using UIKit;

namespace DemoSQLite.iOS
{
    public class CalendarConnectionIos:ICalendar
    {
        protected EKEventStore EventStore;
        
        public CalendarConnectionIos()
        {
            EventStore = new EKEventStore(); 
        }
        public bool AddToCalendar(CalendarModel calendarModel)
        {            
            //var granted = EventStore.RequestAccessAsync(EKEntityType.Event);
            EventStore.RequestAccess(EKEntityType.Event, (bool granted, NSError e) =>
            {
                if (granted)
                {
                    EKEvent newEvent = EKEvent.FromStore(EventStore);
                    newEvent.Title = calendarModel.Title;
                    newEvent.Notes = calendarModel.Description;
                    newEvent.StartDate = (NSDate) calendarModel.Start;
                    newEvent.EndDate = (NSDate) calendarModel.End;
                    newEvent.Location = calendarModel.Location;
                    newEvent.Calendar = EventStore.DefaultCalendarForNewEvents;                    
                    EventStore.SaveEvent(newEvent, EKSpan.ThisEvent, out e);
                    return;

                }
                new UIAlertView("Access Denied,", "User Denied Access to Calendar Data", null, "ok",null).Show();
                Debug.WriteLine(e);
            });
            return true;
        }
    }
}