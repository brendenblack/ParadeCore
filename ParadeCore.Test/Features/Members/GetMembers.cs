using AutoMapper;
using ParadeCore.Domain.Models;
using ParadeCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static ParadeCore.Features.Members.GetMembers;

namespace ParadeCore.Test.Features.Members
{
    public class GetMembers
    {
        public class Handler_Should
        {
            private readonly Handler handler;
            private readonly ParadeContext db;
            private readonly IEnumerable<Member> AllMembers; 

            public Handler_Should()
            {

                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile(new ParadeCore.Features.Members.MappingProfile());
                });

                var db = TestHelpers.GenerateInMemoryContext();
                this.AllMembers = TestHelpers.GenerateMembers(10);
                db.AddRange(this.AllMembers);
                db.SaveChanges();
                
                this.handler = new Handler(db);
            }

            [Fact]
            public async Task ReturnAllUsersWithNoQuery()
            {
                var message = new Query();
                var result = await this.handler.Handle(message);

                var expectedIds = this.AllMembers.Select(m => m.Id).ToHashSet();
                var returnedIds = result.Results.Select(r => r.Id).ToHashSet();

                Assert.True(expectedIds.SetEquals(returnedIds));
            }
        }
    }
}
