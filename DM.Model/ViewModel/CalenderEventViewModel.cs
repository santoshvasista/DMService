using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
    public class CalenderEventViewModel
    {
        public int EventId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }


        public CalenderEventViewModel(int eventId, DateTime dateStart, DateTime dateEnd, string summary, string location, string description, string fileName)
        {
            this.EventId = eventId;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.Summary = summary;
            this.Location = location;
            this.Description = description;
            this.FileName = fileName;
        }



        public static List<CalenderEventViewModel> GetEventList()
        {
            List<CalenderEventViewModel> events = new List<CalenderEventViewModel>();
            events.Add(new CalenderEventViewModel(1, DateTime.Now, DateTime.Now.AddMinutes(30), "Test1", "BR7", "This appointment for PT", "1"));
            events.Add(new CalenderEventViewModel(2, DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(60), "Test2", "BR6", "This appointment for MRI", "2"));
            events.Add(new CalenderEventViewModel(3, DateTime.Now, DateTime.Now.AddMinutes(60), "Test3", "BR8", "This appointment for CT", "3"));
            events.Add(new CalenderEventViewModel(4, DateTime.Now, DateTime.Now.AddMinutes(20), "Test4", "BR5", "This appointment for MRI", "4"));
            return events;
        }
    }
}
