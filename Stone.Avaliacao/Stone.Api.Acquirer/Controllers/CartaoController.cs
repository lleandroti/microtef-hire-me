using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Models.Adapters;

namespace Stone.Api.Acquirer.Controllers
{
    [RoutePrefix("services/cartao")]
    public class CartaoController : ApiController
    {
        private readonly IDomainServiceCartao _domainServiceCartao;

        public CartaoController(IDomainServiceCartao domainServiceCartao)
        {
            _domainServiceCartao = domainServiceCartao;
        }

        [HttpGet]
        [Route("listar")]
        [ResponseType(typeof(IEnumerable<CartaoConsultaModel>))]
        public HttpResponseMessage Get()
        {
            try
            {
                var listagem = _domainServiceCartao.ObterTodos();

                var registros = listagem.Select(x => Mapper.Map<CartaoConsultaModel>(x));

                return Request.CreateResponse(HttpStatusCode.OK, registros);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
