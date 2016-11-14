using System;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Renderscripts;
using DemoSQLite.Database;
using DemoSQLite.Droid;
using DemoSQLite.Interface;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(CalendarConnectionAndroid))]
namespace DemoSQLite.Droid
{
    public class CalendarConnectionAndroid:ICalendar
    {
        public bool AddToCalendar(CalendarModel calendarModel)
        {
            Intent intent = new Intent(Intent.ActionInsert);
            intent.SetData(CalendarContract.Events.ContentUri);
            intent.PutExtra(CalendarContract.ExtraEventBeginTime, calendarModel.Start.ToLongTimeString());
            intent.PutExtra(CalendarContract.EventsColumns.AllDay, false);
            intent.PutExtra(CalendarContract.EventsColumns.EventLocation, calendarModel.Location);
            intent.PutExtra(CalendarContract.EventsColumns.Description, calendarModel.Description);
            //intent.PutExtra(CalendarContract.ExtraEventEndTime, Utils.Tools.CurrentTimeMillis(game.Date.AddHours(2)));
            intent.PutExtra(CalendarContract.EventsColumns.Title, calendarModel.Title);
            //StartActivity(intent);
            ((Activity)Forms.Context).StartActivity(intent);
            return true;
            
        }        
    }
}