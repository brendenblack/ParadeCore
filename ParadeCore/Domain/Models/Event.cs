using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class Event : IEntity
    {

        private Event() { }

        public Event(DateTime start, DateTime end)
        {

        }

        public int Id { get; private set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TrainingCalendarEvent> TrainingCalendars { get; set; } = new List<TrainingCalendarEvent>();

        public virtual ICollection<AttendanceRecord> Attendance { get; set; } = new HashSet<AttendanceRecord>();

        

    }
}
