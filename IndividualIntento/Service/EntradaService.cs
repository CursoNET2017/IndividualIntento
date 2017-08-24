using IndividualIntento.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividualIntento.Service
{
    public class EntradaService : IEntradaService
    {
        //[ThreadStatic] public static ApplicationDbContext applicationDbContext;// Para poder usarlo en el repository

        private IEntradaRepository entradaRepository;
        public EntradaService(IEntradaRepository _entradaRepository)
        {
            this.entradaRepository = _entradaRepository;
        }

        public Entrada Get(long id)
        {
            return entradaRepository.Get(id);
        }

        public Entrada Create(Entrada entrada)
        {
            return entradaRepository.Create(entrada);
        }


        public IQueryable<Entrada> GetEntradas()
        {
            return entradaRepository.GetEntradas();
        }

        public Entrada Delete(long id)
        {

            return entradaRepository.Delete(id);
        }

        public void Put(Entrada entrada)
        {
            entradaRepository.Put(entrada);
        }
    }
}