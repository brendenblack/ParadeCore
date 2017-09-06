using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using ParadeCore.Domain.Models;
using ParadeCore.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static ParadeCore.Features.Members.AddMember;

namespace ParadeCore.Tests.Features.Members
{
    public class AddMember
    {
        public class Validator_Should
        {
            private Validator validator;

            public Validator_Should()
            {
                var db = TestHelpers.GenerateInMemoryContext();
                db.Members.Add(new Member(TestHelpers.ValidServiceNumber) { FirstName = "My", LastName = "User" });
                db.SaveChanges();

                validator = new Validator(db);
            }

            [Fact]
            public void HaveErrorWhenLastNameIsNull()
            {
                validator.ShouldHaveValidationErrorFor(m => m.LastName, null as string);
            }

            [Fact]
            public void NotHaveErrorWhenLastNameIsProvided()
            {
                validator.ShouldNotHaveValidationErrorFor(m => m.LastName, "Myname");
            }


            #region Service number validation
            [Fact]
            public void NotHaveErrorWhenServiceNumberIsValidAndDoesNotExist()
            {
                validator.ShouldNotHaveValidationErrorFor(m => m.ServiceNumber, "B12345678");
            }

            [Fact]
            public void HaveErrorWhenServiceNumberIsNull()
            {
                validator.ShouldHaveValidationErrorFor(m => m.ServiceNumber, null as string);
            }

            [Theory]
            [InlineData("a1234567")]
            [InlineData("123456789")]
            [InlineData("1ABCDEFGH")]
            [InlineData("")]
            public void HaveErrorWhenServiceNumberIsInvalid(string serviceNumber)
            {
                validator.ShouldHaveValidationErrorFor(m => m.ServiceNumber, serviceNumber);
            }

            [Fact]
            public void HaveErrorWhenServiceNumberExists()
            {
                validator.ShouldHaveValidationErrorFor(m => m.ServiceNumber, "A12345678");
            }
            #endregion
        }

        public class Handler_Should
        {
            private ParadeContext db;
            private Handler handler;
            private readonly string _serviceNumber;
            private Command message;
            

            public Handler_Should()
            {
                this._serviceNumber = TestHelpers.ValidServiceNumber;
                this.db = TestHelpers.GenerateInMemoryContext();
                this.handler = new Handler(this.db);
                this.message = new Command { ServiceNumber = _serviceNumber, FirstName = "My", LastName = "Member" };
            }

            [Fact]
            public async Task ReturnIdWhenSuccessful()
            {
                var message = new Command { ServiceNumber = _serviceNumber, FirstName = "My", LastName = "Member" };
                var result = await handler.Handle(message);

                var expectedId = this.db.Members
                    .Where(m => m.ServiceNumber == _serviceNumber)
                    .Select(m => m.Id)
                    .FirstOrDefault();

                Assert.Equal(result.Id, expectedId);
            }

            [Fact]
            public async Task AddMemberToContext()
            {
                var result = await handler.Handle(message);

                var addedMember = await db.Members.Where(m => m.ServiceNumber == message.ServiceNumber).FirstOrDefaultAsync();
                Assert.NotNull(addedMember);
                Assert.Equal(message.FirstName, addedMember.FirstName);
                Assert.Equal(message.LastName, addedMember.LastName);
            }
            

        }
    }

}
