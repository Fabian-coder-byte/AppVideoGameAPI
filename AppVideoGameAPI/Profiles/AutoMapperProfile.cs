using AppVideoGameAPI.DTO.Stocks;
using AutoMapper;

namespace AppVideoGameAPI.Profile
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            //Stock
            CreateMap<Models.Stock, VideoGameMenu>().ReverseMap();
            CreateMap<VideoGameMenu, Models.Stock>().ReverseMap();
            //CasaProduttrice
            CreateMap<Models.CasaProduttrice, DTO.CasaProduttrice>().ReverseMap();
            CreateMap<DTO.CasaProduttrice, Models.CasaProduttrice>().ReverseMap();
            //Recensione
            CreateMap<Models.Recensione, DTO.Recensione.RecensioneCreate>().ReverseMap();
            CreateMap<DTO.Recensione.RecensioneCreate, Models.Recensione>().ReverseMap();
        }
    }
}
