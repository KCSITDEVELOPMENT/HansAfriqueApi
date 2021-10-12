using AutoMapper;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() 
        {
            CreateMap<Part, ProductDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Supplier, o => o.MapFrom(s => s.Supplier.Name))
                .ForMember(d => d.PartNumber, o => o.MapFrom(s => s.PartNumber.Name))
                .ForMember(d => d.Vehicle, o => o.MapFrom(s => s.Vehicle.Vehicle_Model))
                .ForMember(d => d.PartCategory, o => o.MapFrom(s => s.PartCategory.Name));


        }
    }
}
