using RotaViagem.Domain.Models;
using RotaViagem.Domain.Repositories;
using RotaViagem.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotaViagem.Infra
{
    public class RotaRepository : IRotaRepository
    {
        private readonly RotaContext _context;

        public RotaRepository(RotaContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Rota>> GetAllRotas()
        {
            IEnumerable<Rota> rotas = _context.Rota.ToList();

            return rotas;
        }

        public async Task AddRota(Rota rota)
        {
            await _context.AddAsync(rota);
            _context.SaveChanges();
        }

        public async Task UpdateRota(Rota rota)
        {

            _context.Update(rota);
            _context.SaveChanges();
        }

        public async Task DeleteRota(int id)
        {
            var rota = _context.Rota.Find(id);
            _context.Remove(rota);
            _context.SaveChanges();
        }
    }
}
