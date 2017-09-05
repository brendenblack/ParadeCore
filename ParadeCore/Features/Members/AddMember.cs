using FluentValidation;
using MediatR;
using ParadeCore.Constants;
using ParadeCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParadeCore.Domain;
using ParadeCore.Domain.Models;

namespace ParadeCore.Features.Members
{
    public class AddMember
    {
        public class Command : IRequest<Result>
        {
            public string ServiceNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            private readonly ParadeContext db;

            public Validator(ParadeContext db)
            {
                this.db = db;

                RuleFor(c => c.ServiceNumber)
                  .NotNull()
                  .Matches(ValidationConstants.ServiceNumberPattern)
                  .WithMessage("Service number must be in the format 'A123456789'")
                  .Must(NotAlreadyExist)
                  .WithMessage("There is already a record for a member with this service number");

                RuleFor(c => c.LastName)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("You must provide a last name");

            }

            private bool NotAlreadyExist(string serviceNumber)
            {
                return !db.Members
                    .Where(m => m.ServiceNumber.Equals(serviceNumber, StringComparison.InvariantCultureIgnoreCase))
                    .Any();
            }
        }


        public class Result
        {
            public int Id { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Command, Result>
        {
            private readonly ParadeContext db;

            public Handler(ParadeContext db)
            {
                this.db = db;
            }

            public async Task<Result> Handle(Command message)
            {
                var member = new Member(message.ServiceNumber)
                {
                    FirstName = message.FirstName,
                    LastName = message.LastName
                };


                await db.Members.AddAsync(member);
                await db.SaveChangesAsync();

                var result = new Result { Id = member.Id };
                return result;

            }
        }

    }
}
