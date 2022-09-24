using AutoMapper;
using Car.Rental.Domain.Entities;
using Car.Rental.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.Mapper
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            ////Model to Entity           
            CreateMap<AddressModel, Address>()
                .ReverseMap();
            CreateMap<ClientModel, Client>()
                .ReverseMap()
                .ForMember(i => i.Password, j => j.Ignore());
            CreateMap<OperatorModel, Operator>()
                .ReverseMap()
                .ForMember(i => i.Password, j=> j.Ignore());
        }
    }
}
