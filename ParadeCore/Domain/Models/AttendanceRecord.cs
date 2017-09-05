using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class AttendanceRecord : IEntity
    {
        public int Id { get; private set; }

        public virtual Member Member { get; set; }

        public virtual Event Event { get; set; }

        public bool DidAttend { get; set; }

        public string Notes { get; set; }

        // public virtual Member ReportedBy { get; set; }
    }
}