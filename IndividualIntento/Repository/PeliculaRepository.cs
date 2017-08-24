using IndividualIntento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IndividualIntento.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        public Pelicula Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Peliculas.Find(id);
        }

        public Pelicula Create(Pelicula pelicula)
        {
            return ApplicationDbContext.applicationDbContext.Peliculas.Add(pelicula);
        }

        public IQueryable<Pelicula> GetPeliculas()
        {
            IList<Pelicula> lista = new List<Pelicula>(ApplicationDbContext.applicationDbContext.Peliculas);
            return lista.AsQueryable();//Si devuelves el IQueryable casca en el lado del cliente.
        }

        public Pelicula Delete(long id)
        {
            Pelicula pelicula = ApplicationDbContext.applicationDbContext.Peliculas.Find(id);
            if (pelicula == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Peliculas.Remove(pelicula);
            return pelicula;
        }

        public void Put(Pelicula pelicula)
        {
            if (ApplicationDbContext.applicationDbContext.Peliculas.Count(e => e.Id == pelicula.Id) == 0)// El private bool PersonaExists(long id) del anterior controlador
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(pelicula).State = EntityState.Modified;
        }
    }
}