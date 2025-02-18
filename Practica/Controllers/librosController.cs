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

        /// <summary>
        /// EndPoint para crear un registro de libro
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult crearLibro([FromBody] libros libro)
        {
            try
            {
                _librosContexto.libros.Add(libro);
                _librosContexto.SaveChanges();
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// EndPoint para actualizar un registro por ID
        /// </summary>
        /// <param name="id"></param>
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarLibro(int id, [FromBody] libros libroModificar)
        {
            // Obtener registro original
            libros? libroActual = (from l in _librosContexto.libros
                                   where l.id == id
                                   select l).FirstOrDefault();

            // Verificar que el registro original exista
            if (libroActual == null) return NotFound();

            // Si se encuentra el registro, modificarlo
            libroActual.titulo = libroModificar.titulo;
            libroActual.anioPublicacion = libroModificar.anioPublicacion;
            libroActual.autorId = libroModificar.autorId;
            libroActual.categoriaId = libroModificar.categoriaId;
            libroActual.resumen = libroModificar.resumen;

            // Notificar y enviar la modificacion
            _librosContexto.Entry(libroActual).State = EntityState.Modified;
            _librosContexto.SaveChanges();

            return Ok(libroModificar);
        }

        /// <summary>
        /// EndPoint para eliminar un registro 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarLibro(int id) 
        {
            // Obtener el registro a eliminar
            libros? libro = (from l in _librosContexto.libros
                             where l.id == id
                             select l).FirstOrDefault();

            // Verificar si el registro existe
            if (libro == null) return NotFound();

            // Ejecutar la eliminacion 
            _librosContexto.libros.Attach(libro);
            _librosContexto.libros.Remove(libro);
            _librosContexto.SaveChanges();

            return Ok(libro);
        }
    }
}
