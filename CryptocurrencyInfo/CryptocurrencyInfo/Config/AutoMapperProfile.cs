using AutoMapper;
using CryptocurrencyInfo.ViewModels;
using Models.CoinCapApiModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CryptocurrencyApiModel, CryptocurrencyModel>();
            CreateMap<MarketApiModel, MarketModel>();
        }

        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }
    }
}
