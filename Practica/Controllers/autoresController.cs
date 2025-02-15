using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class autoresController : ControllerBase
    {
        private readonly autoresContext _autoresContext;
        public autoresController(autoresContext context)
        {
            _autoresContext = context;
        }
        /// <summary>
        /// Endpoint para obtener todos los autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<autores> autoresContext = (from e in _autoresContext.autores select e).ToList();
            if (autoresContext.Count == 0)
            {
                return NotFound();
            }
            return Ok(autoresContext);
        }
    }
    }

}
