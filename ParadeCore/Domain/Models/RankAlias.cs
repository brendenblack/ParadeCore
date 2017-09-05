using ParadeCore.Domain.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class RankAlias : IEntity 
    {
        private RankAlias() { }
        
        public RankAlias(RankEquivalence standardRank, String name, String abbr)
        {
            this.StandardRank = standardRank;
            this.Name = name;
            this.Abbreviation = abbr;

            this.IsStandard = abbr.Equals(RankDictionary.Lookup(standardRank).abbreviation, StringComparison.InvariantCultureIgnoreCase);
        }

        public int Id { get; private set; }

        // public virtual Discriminator Discriminator { get; private set; }

        public RankEquivalence StandardRank { get; private set; }

        public string Name { get; private set; }

        public string Abbreviation { get; private set; }

        public bool IsStandard { get; private set; }
    }
}
