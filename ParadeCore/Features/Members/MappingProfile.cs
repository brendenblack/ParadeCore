using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParadeCore.Domain;
using ParadeCore.Domain.Models;

namespace ParadeCore.Features.Members
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, GetMembers.Model>();

            CreateMap<Member, GetMemberById.Model>();
        }
    }
}
