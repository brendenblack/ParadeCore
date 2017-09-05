using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class Company : IEntity
    {
        private Company() { }

        public Company(int uic, string identifier)
        {
            this.UIC = uic;
            this.Identifier = identifier;
        }

        public int Id { get; private set; }

        public string Identifier { get; private set; }

        public int UIC { get; private set; }

        public string Name
        {
            get
            {
                return $"{Identifier} Company";
            }
        }

        public string Abbreviation
        {
            get
            {
                return $"{Identifier} Coy";
            }
        }

        public virtual ICollection<Platoon> Platoons { get; private set; } = new HashSet<Platoon>();

        public ICollection<TrainingCalendar> TrainingCalendars { get; private set; } = new HashSet<TrainingCalendar>();

        public ICollection<Member> Members { get; private set; } = new HashSet<Member>();
    }
}