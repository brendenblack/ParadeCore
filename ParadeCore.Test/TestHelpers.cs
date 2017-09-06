using Microsoft.EntityFrameworkCore;
using ParadeCore.Domain.Models;
using ParadeCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParadeCore.Tests
{
    public class TestHelpers
    {
        public static string ValidServiceNumber
        {
            get
            {
                return "A12345678";
            }
        }

        public static ParadeContext GenerateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ParadeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ParadeContext(options);

            return context;
        }


        public static IEnumerable<Member> GenerateMembers(int count)
        {
            var members = new List<Member>();

            for (int i = 0; i < count; i++)
            {
                var serviceNumber = "A" + i.ToString("00000000");
                var name = Path.GetRandomFileName().Replace(".", "");

                members.Add(new Member(serviceNumber, name));
            }

            return members;
        }

    }
}
