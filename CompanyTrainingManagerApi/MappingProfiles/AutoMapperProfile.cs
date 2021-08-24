using AutoMapper;
using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateWorkerDto, Worker>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address()
                {
                    Country = src.Country,
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                    HomeNumber = src.HomeNumber,
                    FlatNumber = src.FlatNumber
                }));
        }
    }
}
