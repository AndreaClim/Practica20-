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
        private readonly Context _librosContexto;

        public librosController(Context librosContexto) 
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

        /// <summary>
        /// EndPoint para filtrar un libro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id) 
        {
            var equipo = (from l in _librosContexto.libros
                                join a in _librosContexto.autores
                                    on l.autorId equals a.autorId
                          select new 
                          {
                              l.id,
                              l.titulo,
                              l.anioPublicacion,
                              a.nombre,
                              l.resumen
                          }).FirstOrDefault();

            if (equipo == null) return NotFound();

            return Ok(equipo);
        }

    }
}
