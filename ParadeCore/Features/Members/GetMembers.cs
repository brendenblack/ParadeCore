using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ParadeCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Features.Members
{
    public class GetMembers
    {
        public class Result
        {
            public string Sort { get; set; } = "";
            public string Filter { get; set; } = "";

            public List<String> SortOptions = new List<String>() { "name", "name_desc" };


            public IEnumerable<Model> Results { get; set; } = new List<Model>();
        }

        public class Query : IRequest<Result>
        {
            public string Search { get; set; }
            public string Sort { get; set; }

            public string Filter { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public string LastName { get; set; }
            public string Initials { get; set; }
            public string Rank { get; set; }
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
                var result = new Result
                {
                    Sort = message.Sort,
                    Filter = message.Search
                    //NameSortParm = String.IsNullOrEmpty(message.SortOrder) ? "name_desc" : "",
                    //DateSortParm = message.SortOrder == "Date" ? "date_desc" : "Date",
                };

                var members = (string.IsNullOrWhiteSpace(message.Search)) 
                    ? db.Members 
                    : db.Members.Where(m => m.LastName.Contains(message.Search) || m.FirstName.Contains(message.Search));

                //if (!string.IsNullOrWhiteSpace(message.OrgIdentifier))
                //{
                //    switch (message.OrgContext)
                //    {
                //        case OrganizationalContext.Subunit:
                //            members = members.Where(m => m.Position != null && m.Position.Company.Identifier == message.OrgIdentifier && m.Position.OrganizationalContext <= message.OrgContext);
                //            break;
                //        case OrganizationalContext.Subsubunit:
                //            break;
                //        case OrganizationalContext.Section:
                //            break;
                //        default: // individual
                //            break;
                //    }


                //}

                switch (message.Sort)
                {
                    case "name_desc":
                        members = members.OrderByDescending(m => m.LastName);
                        break;
                    default:
                        result.Sort = "name";
                        members = members.OrderBy(m => m.LastName);
                        break;
                }


                var domain = await members.ToListAsync();
                result.Results = Mapper.Map<IEnumerable<Model>>(domain);

                return result;
            }
        }

    }
}
