using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class TrainingCalendar : IEntity
    {
        private TrainingCalendar() { }

        public TrainingCalendar(DateTime standTo, DateTime standDown, DayOfWeek paradeDay)
        {
            this.StandDown = standDown;
            this.StandTo = standTo;
            this.ParadeDayOfWeek = paradeDay;
        }


        public int Id { get; private set; }

        public DateTime StandTo { get; private set; }

        public DateTime StandDown { get; private set; }

        public DayOfWeek ParadeDayOfWeek { get; set; }

        public virtual ICollection<TrainingCalendarEvent> Events { get; private set; } = new List<TrainingCalendarEvent>();

        


    }
}