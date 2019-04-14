using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Stone.Api.Acquirer.Extension;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;
using Stone.Framework.Resources;
using AutoMapper;
using Stone.Domain.Models.Adapters;

namespace Stone.Api.Acquirer.Controllers
{
    [RoutePrefix("services/cliente")]
    public class ClienteController : ApiController
    {
        private readonly IDomainServiceCliente _domainServiceCliente;

        public ClienteController(IDomainServiceCliente domainServiceCliente)
        {
            _domainServiceCliente = domainServiceCliente;
        }

        [HttpGet]
        [Route("listar")]
        [ResponseType(typeof(IEnumerable<ClienteConsultaModel>))]
        public HttpResponseMessage Get()
        {
            try
            {
                var listagem = _domainServiceCliente.ObterTodos();

                var registros = listagem.Select(x => Mapper.Map<ClienteConsultaModel>(x));

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
                    var registro = _domainServiceCliente.ObterPorId(id);

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

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post([FromBody] ClienteCadastroModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cliente = Mapper.Map<ClienteCadastroModel, Cliente>(value);

                    _domainServiceCliente.Cadastrar(cliente);

                    return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroCadastradoComSucesso);
                }

                return Request.ReturnAllErrorsInModelState(ModelState);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(int id, [FromBody]ClienteAlteraModel value)
        {
            if (ModelState.IsValid)
            {
                var registro = _domainServiceCliente.ObterPorId(id);

                if (registro == null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroNaoLocalizado);

                registro = Mapper.Map<ClienteAlteraModel, Cliente>(value, registro);

                _domainServiceCliente.Atualizar(registro);

                return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroAtualizadoComSucesso);
            }

            return Request.ReturnAllErrorsInModelState(ModelState);
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var registro = _domainServiceCliente.ObterPorId(id);

                if (registro == null)
                    return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroNaoLocalizado);

                _domainServiceCliente.Excluir(registro);

                return Request.CreateResponse(HttpStatusCode.OK, Mensagens.RegistroExcluidoComSucesso);
            }

            return Request.ReturnAllErrorsInModelState(ModelState);
        }

        [HttpPost]
        [Route("validar")]
        [ResponseType(typeof(bool))]
        public HttpResponseMessage Valid([FromBody]ClienteValidaModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resultado = _domainServiceCliente.ValidarCliente(cliente.Nome, cliente.Password);

                    return Request.CreateResponse(HttpStatusCode.OK, resultado);
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
