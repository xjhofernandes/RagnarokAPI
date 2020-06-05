using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RagnarokAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet]
        public ContentResult Get()
        {
            return base.Content("<h1>Hello, Ragnarok API3.0!</h1>", "text/html");
        }
    }
}
