using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Domain.Mappers
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToModelMapping>();
                cfg.AddProfile<ModelToEntityMapping>();
            });
        }
    }
}
