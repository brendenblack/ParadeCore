using MediatR;
using Microsoft.EntityFrameworkCore;
using ParadeCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Features.Members
{
    public class DeleteMember
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Command>
        {
            private readonly ParadeContext db;

            public Handler(ParadeContext db)
            {
                this.db = db;
            }

            public async Task Handle(Command message)
            {
                var member = await db.Members.FirstOrDefaultAsync(m => m.Id == message.Id);
                db.Members.Remove(member);
                await db.SaveChangesAsync();
            }
        }
    }
}