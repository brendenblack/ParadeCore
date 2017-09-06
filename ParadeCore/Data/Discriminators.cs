using ParadeCore.Domain.Dictionaries;
using ParadeCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Data
{
    public class Discriminators
    {
        public static Discriminator CafStandardDiscriminator()
        {
            var ranks = new List<RankAlias>();
            foreach (RankEquivalence rank in Enum.GetValues(typeof(RankEquivalence)))
            {
                if (rank >= 0)
                {
                    var names = RankDictionary.Lookup(rank);
                    ranks.Add(new RankAlias(rank, names.name, names.abbreviation));
                }
            }

            return new Discriminator("Canadian Armed Forces standard", "Details for a standard CAF unit", ranks);
        }

        public static Discriminator RcnDiscriminator()
        {
            var ranks = new List<RankAlias>();
            foreach (RankEquivalence rank in Enum.GetValues(typeof(RankEquivalence)))
            {
                if (rank >= 0)
                {
                    var names = RankDictionary.Lookup(rank, RankModifier.Navy);
                    ranks.Add(new RankAlias(rank, names.name, names.abbreviation));
                }
            }

            return new Discriminator("Royal Canadian Navy", "Details for a standard RCN unit", ranks);
        }

        public static Discriminator RcafDiscriminator()
        {
            var ranks = new List<RankAlias>();
            foreach (RankEquivalence rank in Enum.GetValues(typeof(RankEquivalence)))
            {
                if (rank >= 0)
                {
                    var names = RankDictionary.Lookup(rank, RankModifier.Navy);
                    ranks.Add(new RankAlias(rank, names.name, names.abbreviation));
                }
            }

            return new Discriminator("Royal Canadian Air Force", "Details for a standard RCAF unit", ranks);
        }
    }
}
