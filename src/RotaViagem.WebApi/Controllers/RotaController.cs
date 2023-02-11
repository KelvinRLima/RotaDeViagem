
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RotaViagem.Domain.Models;
using RotaViagem.Domain.Services;
using RotaViagem.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RotaViagem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _rotaService;
        private readonly IMapper _mapper;

        public RotaController(IRotaService rotaService, IMapper mapper)
        {
            this._rotaService = rotaService ??
                throw new ArgumentNullException(nameof(rotaService));

            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<RotaController>
        [HttpGet("Get/{origem},{destino}")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        public async Task<IActionResult> Get(string origem, string destino)
        {
            try
            {
                Result<string> result = await _rotaService.GetRota(origem, destino);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/<RotaController>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Result<IEnumerable<Rota>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                Result<IEnumerable<Rota>> result = await _rotaService.GetAllRotas();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/<RotaController>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        public async Task<IActionResult> Add([FromBody] RotaDto rotaDto)
        {
            try
            {
                Rota rota = _mapper.Map<Rota>(rotaDto);

                Result<bool> result = await _rotaService.AddRota(rota);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/<RotaController>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        public async Task<IActionResult> Update([FromBody] RotaDto rotaDto)
        {
            try
            {
                Rota rota = _mapper.Map<Rota>(rotaDto);

                Result<bool> result = await _rotaService.UpdateRota(rota);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/<RotaController>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Result<bool> result = await _rotaService.DeleteRota(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
