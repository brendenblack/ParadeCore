using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class TrainingCalendarEvent
    {
        public int TrainingCalendarId { get; set; }
        public virtual TrainingCalendar TrainingCalendar { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
