using AutoMapper;
using Data.Models;
using System;

namespace ReactDemo.Mappings
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<ContactMeRequest, ContactMe>()
                .AfterMap((from, to) => to.CreatedAt = DateTime.Now);
        }
    }
}
