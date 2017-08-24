using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IndividualIntento;
using IndividualIntento.Models;
using System.Web.Http.Cors;
using IndividualIntento.Service;

namespace IndividualIntento.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class PeliculasController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IPeliculaService peliculaService;

        public PeliculasController(IPeliculaService _peliculaService)
        {
            this.peliculaService = _peliculaService;
        }

        // GET: api/Peliculas
        public IQueryable<Pelicula> GetPeliculas()
        {
            return peliculaService.GetPeliculas();
        }

        // GET: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult GetPelicula(long id)
        {
            Pelicula pelicula = peliculaService.Get(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // PUT: api/Peliculas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPelicula(long id, Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pelicula.Id)
            {
                return BadRequest();
            }

            try
            {
                peliculaService.Put(pelicula);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Peliculas
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult PostPelicula(Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pelicula = peliculaService.Create(pelicula);

            return CreatedAtRoute("DefaultApi", new { id = pelicula.Id }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult DeletePelicula(long id)
        {
            Pelicula pelicula;
            try
            {
                pelicula = peliculaService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }       
    }
}