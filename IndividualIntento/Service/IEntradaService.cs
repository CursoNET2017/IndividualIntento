using System.Linq;

namespace IndividualIntento.Service
{
    public interface IEntradaService
    {
        Entrada Create(Entrada entrada);
        Entrada Delete(long id);
        Entrada Get(long id);
        IQueryable<Entrada> GetEntradas();
        void Put(Entrada entrada);
    }
}