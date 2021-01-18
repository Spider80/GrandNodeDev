﻿using AutoMapper;
using Grand.Domain.Shipping;
using Grand.Core.Infrastructure.Mapper;
using Grand.Admin.Models.Shipping;

namespace Grand.Admin.Infrastructure.Mapper.Profiles
{
    public class WarehouseProfile : Profile, IMapperProfile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseModel>()
                .ForMember(dest => dest.Address, mo => mo.MapFrom(y => y.Address));

            CreateMap<WarehouseModel, Warehouse>()
                .ForMember(dest => dest.Id, mo => mo.Ignore());
        }

        public int Order => 0;
    }
}