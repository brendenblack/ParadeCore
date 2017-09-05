using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class UnitPosting : IEntity
    {
        private UnitPosting() { }

        public UnitPosting(Unit unit, Member member, DateTime effectiveDate)
        {
            this.EffectiveDate = effectiveDate;
            this.Unit = unit;
            this.Member = member;
        }

        public int Id { get; private set; }

        public DateTime EffectiveDate { get; private set; }

        public virtual Unit Unit { get; private set; }

        public virtual Member Member { get; private set; }
    }
}
