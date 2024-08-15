using AppVideoGameAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppVideoGameAPI.Controllers
{
    public class BaseController:ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public BaseController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
