using ParadeCore.Domain.Models;
using ParadeCore.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static ParadeCore.Features.Members.DeleteMember;

namespace ParadeCore.Tests.Features.Members
{
    public class DeleteMember
    {
        public class Handler_Should
        {
            private readonly Handler handler;
            private readonly ParadeContext db;
            private readonly Member member;

            public Handler_Should()
            {
                var db = TestHelpers.GenerateInMemoryContext();
                this.db = db;

                var member = new Member(TestHelpers.ValidServiceNumber);
                db.Members.Add(member);
                db.SaveChanges();
                this.member = member;

                this.handler = new Handler(db);
            }

            [Fact]
            public async Task DeleteMemberWhenIdExists()
            {
                var message = new Command() { Id = this.member.Id };

                var existsBeforeDelete = this.db.Members.Where(m => m.Id == message.Id).Any();
                await this.handler.Handle(message);
                var existsAfterDelete = this.db.Members.Where(m => m.Id == message.Id).Any();

                Assert.True(existsBeforeDelete);
                Assert.False(existsAfterDelete);



            }
        }
    }
}