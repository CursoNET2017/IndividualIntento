using System.Linq;

namespace IndividualIntento.Repository
{
    public interface IEntradaRepository
    {
        Entrada Create(Entrada entrada);
        Entrada Delete(long id);
        Entrada Get(long id);
        IQueryable<Entrada> GetEntradas();
        void Put(Entrada entrada);
    }
}