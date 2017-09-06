using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ParadeCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Features.Members
{
    public class GetMemberById
    {
        public class Result
        {
            public int Id { get; set; }
            public Model Member { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Query : IRequest<Result>
        {
            public int Id { get; set; }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(m => m.Id).GreaterThan(0).WithMessage("A member id must be greater than 0");
            }
        }




        public class Handler : IAsyncRequestHandler<Query, Result>
        {
            private readonly ParadeContext db;

            public Handler(ParadeContext db)
            {
                this.db = db;
            }


            public async Task<Result> Handle(Query message)
            {
                var entity = await db.Members.FirstOrDefaultAsync(m => m.Id == message.Id);
                var model = Mapper.Map<Model>(entity);
                return new Result { Id = message.Id, Member = model };
            }
        }
    }
}
