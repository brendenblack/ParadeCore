﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class Discriminator : IEntity
    {
        private Discriminator() { }

        public Discriminator(String name, String description = "", List<RankAlias> ranks = null)
        {
            this.Name = name;
            this.Description = (string.IsNullOrEmpty(description)) ? $"Discriminator for {name}" : description;
            this.Ranks = ranks ?? new List<RankAlias>();
        }

        public int Id { get; private set; }

        /// <summary>
        /// Signifies whether this discriminator is an official, system-created discriminator or a custom one generated by users
        /// </summary>
        public Boolean IsCustom { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RankAlias> Ranks { get; private set; }       
    }
}