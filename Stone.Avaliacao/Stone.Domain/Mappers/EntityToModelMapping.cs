using AutoMapper;
using Stone.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Domain.Models.Adapters;
using Stone.Framework.Extensao;

namespace Stone.Domain.Mappers
{
    public class EntityToModelMapping : Profile
    {
        public EntityToModelMapping()
        {
            CreateMap<Cliente, ClienteConsultaModel>();

            CreateMap<Transacao, TransacaoConsultaModel>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.GetDescription()))
                .ForMember(dest => dest.NomeTitular, opt => opt.MapFrom(src => src.Cartao.NomeTitular))
                .ForMember(dest => dest.Bandeira, opt => opt.MapFrom(src => src.Cartao.Bandeira.Nome));
        }
    }
}
