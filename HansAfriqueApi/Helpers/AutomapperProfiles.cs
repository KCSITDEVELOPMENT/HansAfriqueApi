using AutoMapper;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Entities.OrderAggregate;
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
                .ForMember(d => d.PartCategory, o => o.MapFrom(s => s.PartCategory.Name))
                .ForMember(d => d.Photos, o => o.MapFrom(s => s.Photo))
                 .ForMember(d => d.PictureULR, o => o.MapFrom(s => s.Photo.LastOrDefault().FilePath))
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name));

            CreateMap<FileData, FileRecordDto>();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressDto, AddressEnt>().ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
               .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
               .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
               .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
               .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
               .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));



        }
    }
}
