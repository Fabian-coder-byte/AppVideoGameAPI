using AppVideoGameAPI.DTO.Stocks;
using AppVideoGameAPI.ViewModels;
using AppVideoGameAPI.ViewModels.VideoGiochi;
using AutoMapper;

namespace AppVideoGameAPI.Profile
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            //Stock
            CreateMap<Models.StockVideoGioco, VideoGameMenu>().ReverseMap();
            CreateMap<VideoGameMenu, Models.StockVideoGioco>().ReverseMap();
            //CasaProduttrice
            CreateMap<Models.CasaProduttrice, DTO.CasaProduttrice>().ReverseMap();
            CreateMap<DTO.CasaProduttrice, Models.CasaProduttrice>().ReverseMap();
            //Recensione
            CreateMap<Models.Recensione, DTO.Recensione.RecensioneCreate>().ReverseMap();
            CreateMap<DTO.Recensione.RecensioneCreate, Models.Recensione>().ReverseMap();
            //Consoles
            CreateMap<Models.Console, ConsolePostVM>().ReverseMap();
            CreateMap<ConsolePostVM, Models.Console>().ReverseMap();
            //Modelli Consoles
            CreateMap<Models.ModelloConsole, ConsolePostVM>().ReverseMap();
            CreateMap<ConsolePostVM, Models.ModelloConsole>().ReverseMap();
            //VideoGiochi
            CreateMap<Models.CaratteristichaTecnica, RequisitoGiocoVM>().ReverseMap();
            CreateMap<Models.VideoGioco, DataVideoGameVM>().ReverseMap();

        }
    }
}
