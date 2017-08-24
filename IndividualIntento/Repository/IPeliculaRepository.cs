using System.Linq;

namespace IndividualIntento.Repository
{
    public interface IPeliculaRepository
    {
        Pelicula Create(Pelicula pelicula);
        Pelicula Delete(long id);
        Pelicula Get(long id);
        IQueryable<Pelicula> GetPeliculas();
        void Put(Pelicula pelicula);
    }
}