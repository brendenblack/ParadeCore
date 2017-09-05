using ParadeCore.Domain;
using ParadeCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Infrastructure
{
    public class ParadeContextInitializer
    {
        public static void DropCreateAlwaysInitialize(ParadeContext context)
        {
            var initializer = new ParadeContextInitializer();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();



            initializer.SeedUnitAndSubunits(context);
            initializer.SeedMembers(context);

            
        }

        private void SeedUnitAndSubunits(ParadeContext db)
        {
            var unit = new Unit(1234)
            {
                Name = "My Unit",
                Abbreviation = "MyU",
                Website = "www.example.org"
            };

            db.Units.Add(unit);
            

            db.SaveChanges();
        }

        private void SeedMembers(ParadeContext db)
        {
            var members = new Member[]
            {
                new Member("A12345678"),
                new Member("B87654321")
            };

            foreach (Member m in members)
            {
                db.Members.Add(m);
            }

            db.SaveChanges();
        }
    }
}
