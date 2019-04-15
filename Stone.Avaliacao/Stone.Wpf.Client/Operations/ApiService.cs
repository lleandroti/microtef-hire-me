using Stone.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stone.Domain.Models.Adapters;
using Stone.Framework.Security;

namespace Stone.Wpf.Client.Operations
{
    public class ApiService
    {
        private static readonly string baseURI = "http://localhost:7013/services"; 

        public static IList<TransacaoConsultaModel> ListarTransacoesPorPeriodo(DateTime inicioPeriodo, DateTime terminoPeriodo)
        {
            var requestUri = string.Format("{0}/transacao/listar", baseURI);

            IList<TransacaoConsultaModel> registros = null;

            using (var client = new HttpClient())
            {
                var responseMessage = client.GetAsync(new Uri(requestUri)).Result;

                responseMessage.EnsureSuccessStatusCode();

                var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;

                registros = JsonConvert.DeserializeObject<IList<TransacaoConsultaModel>>(jsonResult);
            }

            return registros;
        }

        public static bool AutenticarCliente(string nomeCliente, string password)
        {
            var cliente = new ClienteValidaModel
            {
                Nome = nomeCliente,
                Password = CriptografiaAESHelper.Criptografar(password)
            };

            var requestUri =
                string.Format("{0}/cliente/validar", baseURI);

            bool ehValido;

            using (var client = new HttpClient())
            {
                string postBody = JsonConvert.SerializeObject(cliente);

                var content = new StringContent(postBody, Encoding.UTF8, "application/json");

                var responseMessage = client.PostAsync(new Uri(requestUri), content).Result;

                responseMessage.EnsureSuccessStatusCode();

                var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;

                ehValido = JsonConvert.DeserializeObject<bool>(jsonResult);
            }

            return ehValido;
        }

        public static IList<BandeiraConsultaModel> ListarBandeiras()
        {
            var requestUri = string.Format("{0}/bandeira/listar", baseURI);

            IList<BandeiraConsultaModel> registros = null;

            using (var client = new HttpClient())
            {
                var responseMessage = client.GetAsync(new Uri(requestUri)).Result;

                responseMessage.EnsureSuccessStatusCode();

                var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;

                registros = JsonConvert.DeserializeObject<IList<BandeiraConsultaModel>>(jsonResult);
            }

            return registros;
        }

        public static string CadastrarNovaTRansacao(TransacaoCadastroModel transacao)
        {
            var requestUri =
                string.Format("{0}/transacao/cadastrar", baseURI);

            transacao.Password = CriptografiaAESHelper.Criptografar(transacao.Password);

            string retorno;

            using (var client = new HttpClient())
            {
                string postBody = JsonConvert.SerializeObject(transacao);

                var content = new StringContent(postBody, Encoding.UTF8, "application/json");

                var responseMessage = client.PostAsync(new Uri(requestUri), content).Result;

                responseMessage.EnsureSuccessStatusCode();

                var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;

                retorno = JsonConvert.DeserializeObject<string>(jsonResult);
            }

            return retorno;
        }
    }
}
