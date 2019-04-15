using AutoMapper;
using Stone.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Domain.Model.Enumerables;
using Stone.Domain.Models.Adapters;

namespace Stone.Domain.Mappers
{
    public class ModelToEntityMapping : Profile
    {
        public ModelToEntityMapping()
        {
            CreateMap<ClienteCadastroModel, Cliente>();
            CreateMap<ClienteAlteraModel, Cliente>();

            CreateMap<TransacaoCadastroModel, Transacao>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TranscactionType)src.Tipo))
                .ForMember(dest => dest.Cartao, opt => opt.MapFrom(src => new Cartao
                {
                    NomeTitular = src.NomeTitular,
                    Numero = src.NumeroCartao,
                    Tipo = src.Chip == true ? CardType.Chip : CardType.TarjaMagnetica,
                    Password = src.Password,
                    DataExpiracao = new DateTime(src.ValidadeAno, src.ValidadeMes, 1),
                    SequencialBandeira = src.Bandeira
                }));

            CreateMap<BandeiraCadastroModel, Bandeira>();
        }
    }
}
