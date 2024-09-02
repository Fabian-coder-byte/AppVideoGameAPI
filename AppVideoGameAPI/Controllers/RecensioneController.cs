using AppVideoGameAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecensioneController : BaseController
    {
        public RecensioneController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
