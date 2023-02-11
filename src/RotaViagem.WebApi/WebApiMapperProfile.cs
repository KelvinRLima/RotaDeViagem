using AutoMapper;
using RotaViagem.Domain.Models;
using RotaViagem.WebApi.Dtos;

namespace RotaViagem.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<RotaDto, Rota>();
        }
    }
}
