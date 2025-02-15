using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class librosController : ControllerBase
    {
        private readonly librosContext _librosContexto;

        public librosController(librosContext librosContexto) 
        {
            _librosContexto = librosContexto;
        }

        ///<summary>
        ///Endpoint que devuelve todos los libros 
        ///</summary>
        ///<returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get() 
        {
            List<libros> listadoLibros = (from e in _librosContexto.libros
                                          select e).ToList();

            if (listadoLibros.Count == 0) 
            {
                return NotFound();
            }

            return Ok(listadoLibros);
        }

    }
}
