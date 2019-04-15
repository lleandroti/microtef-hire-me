using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Stone.Api.Acquirer.Extension;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;
using Stone.Domain.Models.Adapters;
using Stone.Framework.Resources;

namespace Stone.Api.Acquirer.Controllers
{
    [RoutePrefix("services/bandeira")]
    public class BandeiraController : ApiController
    {
        private readonly IDomainServiceBandeira _domainServiceBandeira;

        public BandeiraController(IDomainServiceBandeira domainServiceBandeira)
        {
            _domainServiceBandeira = domainServiceBandeira;
        }

        [HttpGet]
        [Route("listar")]
        [ResponseType(typeof(IEnumerable<BandeiraConsultaModel>))]
        public HttpResponseMessage Get()
        {
            try
            {
                var listagem = _domainServiceBandeira.ObterTodos();

                var registros = listagem.Select(x => Mapper.Map<BandeiraConsultaModel>(x));

                return Request.CreateResponse(HttpStatusCode.OK, registros);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post([FromBody] BandeiraCadastroModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var registro = Mapper.Map<BandeiraCadastroModel, Bandeira>(value);

                    _domainServiceBandeira.Cadastrar(registro);

                    return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroCadastradoComSucesso);
                }

                return Request.ReturnAllErrorsInModelState(ModelState);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
