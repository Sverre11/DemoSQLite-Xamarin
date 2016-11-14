using System;

namespace DemoSQLite.Database
{
    public class CalendarModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }    
        public DateTime Start { get; set; }
        public DateTime End { get; set; }   

    }
}