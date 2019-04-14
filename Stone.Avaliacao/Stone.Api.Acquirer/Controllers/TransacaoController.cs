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
    [RoutePrefix("services/transacao")]
    public class TransacaoController : ApiController
    {
        private readonly IDomainServiceTransacao _domainService;

        public TransacaoController(IDomainServiceTransacao domainServiceCliente)
        {
            _domainService = domainServiceCliente;
        }

        [HttpGet]
        [Route("listar")]
        [ResponseType(typeof(IEnumerable<TransacaoConsultaModel>))]
        public HttpResponseMessage Get()
        {
            try
            {
                var listagem = _domainService.ObterTodos();

                var registros = listagem.Select(x => Mapper.Map<TransacaoConsultaModel>(x));

                return Request.CreateResponse(HttpStatusCode.OK, registros);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("obter")]
        [ResponseType(typeof(ClienteConsultaModel))]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var registro = _domainService.ObterPorId(id);

                    if (registro == null)
                        return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroNaoLocalizado);

                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<ClienteConsultaModel>(registro));
                }

                return Request.ReturnAllErrorsInModelState(ModelState);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        //[HttpPost]
        //[Route("cadastrar")]
        //public HttpResponseMessage Post([FromBody] ClienteCadastroModel value)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var cliente = Mapper.Map<ClienteCadastroModel, Cliente>(value);

        //            _domainService.Cadastrar(cliente);

        //            return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroCadastradoComSucesso);
        //        }

        //        return Request.ReturnAllErrorsInModelState(ModelState);
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
        //    }
        //}
    }
}
