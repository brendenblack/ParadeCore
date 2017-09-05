using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class Unit : IEntity
    {
        private Unit() { }

        public Unit(int uic) : this(uic, "", "", "")
        { }

        public Unit(int uic, string name, string abbr, string website)
        {
            this.UIC = uic;
            this.Name = name;
            this.Abbreviation = abbr;
            this.Website = website;
        }

        public int Id { get; private set; }

        public int UIC { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Website { get; set; }

        public ICollection<Company> Companies { get; private set; } = new HashSet<Company>();
    }
}
