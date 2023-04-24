using AutoMapper;
using Models.CoinCapApiModels;
using Models.ViewModels;

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
