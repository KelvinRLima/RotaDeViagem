using RotaViagem.Domain.Helpers;
using RotaViagem.Domain.Models;
using RotaViagem.Domain.Repositories;
using RotaViagem.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RotaViagem.Application
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _rotaRepository;

        public RotaService(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository ??
                throw new ArgumentNullException(nameof(rotaRepository));
        }

        public async Task<Result<IEnumerable<string>>> GetOrigens()
        {
            var result = new Result<IEnumerable<string>>();

            try
            {
                IEnumerable<Rota> rotas = await _rotaRepository.GetAllRotas();

                result.Data = rotas.Select(x => x.Origem).Distinct();
            }
            catch (Exception ex)
            {
                result = new Result<IEnumerable<string>>()
                {
                    IsException = true,
                    Status = false,
                    Message = "Falha ao consultar lista de rotas: " + ex.Message
                };
            }
            return result;
        }

        public async Task<Result<IEnumerable<string>>> GetDestinos()
        {
            var result = new Result<IEnumerable<string>>();

            try
            {
                IEnumerable<Rota> rotas = await _rotaRepository.GetAllRotas();

                result.Data = rotas.Select(x => x.Destino).Distinct();
            }
            catch (Exception ex)
            {
                result = new Result<IEnumerable<string>>()
                {
                    IsException = true,
                    Status = false,
                    Message = "Falha ao consultar lista de rotas: " + ex.Message
                };
            }
            return result;
        }

        public async Task<Result<string>> GetRota(string origemSolicitada, string destinoSolicitado)
        {
            var result = new Result<string>();

            try
            {
                origemSolicitada = origemSolicitada.ToUpper();
                destinoSolicitado = destinoSolicitado.ToUpper();

                IEnumerable<Rota> rotasBase = await _rotaRepository.GetAllRotas();

                List<string> listCidadesOrigem = rotasBase.Select(x => x.Origem).ToList();
                List<string> listCidadesDestino = rotasBase.Select(x => x.Destino).ToList();
                List<string> listCidadesTotal = listCidadesOrigem.Concat(listCidadesDestino).ToList();
                listCidadesTotal = listCidadesTotal.Distinct().ToList();

                if (!listCidadesOrigem.Any(x => x == origemSolicitada))
                {
                    result.Message = "Origem não encontrada!";
                    result.Status = false;

                    return result;
                }
                if (!listCidadesDestino.Any(x => x == destinoSolicitado))
                {
                    result.Message = "Destino não encontrado!";
                    result.Status = false;

                    return result;
                }

                Grafo g = new Grafo(true);

                foreach (var item in listCidadesTotal)
                {
                    g.InserirVertice(item);
                }

                foreach (var item in rotasBase)
                {
                    g.InserirAresta(item.Origem, item.Destino, item.Valor);
                }

                ArrayList caminho = new ArrayList();
                Vertice origem = g.GetVertice(origemSolicitada);
                Vertice destino = g.GetVertice(destinoSolicitado);

                Algoritmo.Dijkstra(g, origem);

                Algoritmo.CalculaCaminho(destino, caminho);
                if (caminho.Count > 0)
                {
                    string ret = Algoritmo.StringCaminho(caminho, destino);
                    result.Data = ret;

                    var valor = Convert.ToInt32(ret.Split('$')[1]);
                    if (valor == int.MaxValue || valor-4 == int.MinValue)
                    {
                        result.Message = "Rota não encontrada!";
                        result.Status = false;
                    }
                }
                else
                {
                    result.Message = "Rota não encontrada!";
                    result.Status = false;
                }
            }
            catch (Exception ex)
            {
                result = new Result<string>()
                {
                    IsException = true,
                    Status = false,
                    Message = "Falha ao consultar rota: " + ex.Message
                };
            }
            return result;
        }

        public async Task<Result<IEnumerable<Rota>>> GetAllRotas()
        {
            var result = new Result<IEnumerable<Rota>>();

            try
            {
                IEnumerable<Rota> rotas = await _rotaRepository.GetAllRotas();

                result.Data = rotas;
            }
            catch (Exception ex)
            {
                result = new Result<IEnumerable<Rota>>()
                {
                    IsException = true,
                    Status = false,
                    Message = "Falha ao consultar lista de rotas: " + ex.Message
                };
            }
            return result;
        }

        public async Task<Result<bool>> AddRota(Rota rota)
        {
            var result = new Result<bool>();

            try
            {
                await _rotaRepository.AddRota(rota);

                result.Data = true;
                result.Message = "Rota cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                result = new Result<bool>()
                {
                    IsException = true,
                    Status = false,
                    Message = ex.Message
                };
            }

            return result;
        }

        public async Task<Result<bool>> UpdateRota(Rota rota)
        {
            var result = new Result<bool>();

            try
            {
                await _rotaRepository.UpdateRota(rota);

                result.Data = true;
                result.Message = "Rota atualizada com sucesso!";
            }
            catch (Exception ex)
            {
                result = new Result<bool>()
                {
                    IsException = true,
                    Status = false,
                    Message = ex.Message
                };
            }

            return result;
        }

        public async Task<Result<bool>> DeleteRota(int id)
        {
            var result = new Result<bool>();

            try
            {
                await _rotaRepository.DeleteRota(id);

                result.Data = true;
                result.Message = "Rota removida com sucesso!";
            }
            catch (Exception ex)
            {
                result = new Result<bool>()
                {
                    IsException = true,
                    Status = false,
                    Message = ex.Message
                };
            }

            return result;
        }
    }
}
