using AutoMapper;
using Stone.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Domain.Mappers
{
    public class ModelToEntityMapping : Profile
    {
        public ModelToEntityMapping()
        {
            CreateMap<ClienteCadastroModel, Cliente>();
            CreateMap<ClienteAlteraModel, Cliente>();

            //.ForMember(dest => dest.Ativo, opt => opt.MapFrom<CustomResolver>());
        }
    }
}
