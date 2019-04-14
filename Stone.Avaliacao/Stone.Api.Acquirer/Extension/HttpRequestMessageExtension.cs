using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace Stone.Api.Acquirer.Extension
{
    public static class HttpRequestMessageExtension
    {
        public static HttpResponseMessage ReturnAllErrorsInModelState(this HttpRequestMessage request, ModelStateDictionary modelState)
        {
            var listagemErros = new List<string>();

            foreach (var state in modelState)
            {
                listagemErros.AddRange(state.Value.Errors.Select(e => e.ErrorMessage));
            }

            return request.CreateResponse(HttpStatusCode.Forbidden, listagemErros);
        }
    }
}