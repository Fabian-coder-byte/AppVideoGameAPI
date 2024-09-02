using AppVideoGameAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitoController : BaseController
    {
        public RequisitoController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
