using RotaViagem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RotaViagem.Domain.Repositories
{
    public interface IRotaRepository
    {
        Task<IEnumerable<Rota>> GetAllRotas();
        Task AddRota(Rota rota);
        Task UpdateRota(Rota rota);
        Task DeleteRota(int id);
    }
}
