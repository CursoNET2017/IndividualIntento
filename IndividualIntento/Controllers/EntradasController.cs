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

    public class EntradasController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IEntradaService entradaService;

        public EntradasController(IEntradaService _entradaService)
        {
            this.entradaService = _entradaService;
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return entradaService.GetEntradas();
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = entradaService.Get(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.Id)
            {
                return BadRequest();
            }

            try
            {
                entradaService.Put(entrada);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entrada = entradaService.Create(entrada);

            return CreatedAtRoute("DefaultApi", new { id = entrada.Id }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada;
            try
            {
                entrada = entradaService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(entrada);
        }
    }
}