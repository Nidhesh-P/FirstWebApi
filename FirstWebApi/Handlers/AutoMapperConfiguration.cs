using AutoMapper;
using FirstWebApi.DataObject;
using FirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApi.Handlers
{
    public static class AutoMapperConfig
    {
        public static IMapper AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Provider, ProviderModel>().ReverseMap();
            });

            return config.CreateMapper();
        }

    }
}