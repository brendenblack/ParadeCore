using AutoMapper;
using FluentValidation.TestHelper;
using ParadeCore.Domain.Models;
using ParadeCore.Infrastructure;
using System.Threading.Tasks;
using Xunit;
using static ParadeCore.Features.Members.GetMemberById;

namespace ParadeCore.Test.Features.Members
{
    public class GetMemberById
    {

        public class Validator_Should
        {
            private Validator validator;

            public Validator_Should()
            {
                this.validator = new Validator();

            }

            [Theory]
            [InlineData(-1)]
            [InlineData(0)]
            public void HaveErrorWhenIdIsLessThanOrEqualToZero(int id)
            {
                validator.ShouldHaveValidationErrorFor(m => m.Id, id);
            }

            [Fact]
            public void NotHaveErrorWhenIdIsGreaterThanZero()
            {
                validator.ShouldNotHaveValidationErrorFor(m => m.Id, 1);
            }
        }


        public class Handler_Should
        {
            private ParadeContext db;
            private Handler handler;
            private Query message;

            private readonly Member member;
            
            public Handler_Should()
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile(new ParadeCore.Features.Members.MappingProfile());
                });

                this.db = TestHelpers.GenerateInMemoryContext();

                var member = new Member("A12345678");
                db.Members.Add(member);
                db.SaveChanges();
                this.member = member;

                this.handler = new Handler(db);

            }

            [Theory]
            [InlineData(3)]
            [InlineData(40123)]
            public async Task ReturnQueryId(int id)
            {
                var message = new Query { Id = id };

                var result = await this.handler.Handle(message);

                Assert.Equal(result.Id, id);
            }

            [Fact]
            public async Task ReturnMemberWhenExists()
            {
                var message = new Query { Id = this.member.Id };

                var result = await this.handler.Handle(message);

                Assert.Equal(result.Member.Id, this.member.Id);
            }

            [Fact]
            public async Task ReturnsNullWhenNotExists()
            {
                var message = new Query { Id = 500 };
                var result = await this.handler.Handle(message);

                Assert.Null(result.Member);
            }

        }
    }
}
