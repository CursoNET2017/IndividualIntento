using IndividualIntento.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualIntento.Service
{
    public class PeliculaService : IPeliculaService
    {
        //[ThreadStatic] public static ApplicationDbContext applicationDbContext;// Para poder usarlo en el repository

        private IPeliculaRepository peliculaRepository;
        public PeliculaService(IPeliculaRepository _peliculaRepository)
        {
            this.peliculaRepository = _peliculaRepository;
        }

        public Pelicula Get(long id)
        {
            return peliculaRepository.Get(id);
        }

        public Pelicula Create(Pelicula pelicula)
        {
            return peliculaRepository.Create(pelicula);
        }


        public IQueryable<Pelicula> GetPeliculas()
        {
            return peliculaRepository.GetPeliculas();
        }

        public Pelicula Delete(long id)
        {

            return peliculaRepository.Delete(id);
        }

        public void Put(Pelicula pelicula)
        {
            peliculaRepository.Put(pelicula);
        }
    }
}