using RotaViagem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RotaViagem.Domain.Services
{
    public interface IRotaService
    {
        /// <summary>
        /// Realiza a pesquisa das origens possíveis.
        /// </summary>
        /// <returns>
        /// Melhor rota.
        /// </returns>
        Task<Result<IEnumerable<string>>> GetOrigens();

        /// <summary>
        /// Realiza a pesquisa dos destinos possíveis.
        /// </summary>
        /// <returns>
        /// Melhor rota.
        /// </returns>
        Task<Result<IEnumerable<string>>> GetDestinos();

        /// <summary>
        /// Realiza a pesquisa da melhor rota.
        /// </summary>
        /// <returns>
        /// Melhor rota.
        /// </returns>
        Task<Result<string>> GetRota(string origemSolicitada, string destinoSolicitado);

        /// <summary>
        /// Realiza a pesquisa da melhor rota.
        /// </summary>
        /// <returns>
        /// Melhor rota.
        /// </returns>
        Task<Result<IEnumerable<Rota>>> GetAllRotas();

        /// <summary>
        /// Insere uma nova rota.
        /// </summary>
        /// <returns>
        /// Sucesso da operacao.
        /// </returns>
        Task<Result<bool>> AddRota(Rota rota);

        /// <summary>
        /// Atualiza dados da rota.
        /// </summary>
        /// <returns>
        /// Sucesso da operacao.
        /// </returns>
        Task<Result<bool>> UpdateRota(Rota rota);

        /// <summary>
        /// Remove rota.
        /// </summary>
        /// <returns>
        /// Sucesso da operacao.
        /// </returns>
        Task<Result<bool>> DeleteRota(int id);
    }
}
