using RestSharp;
using System;
using System.Threading.Tasks;

namespace WpOrcamento.Servico
{
    public class SegurancaServ
    {
        public static async Task<bool> validaTokenAsync(string token)
        {

            RestClient client = new RestClient("http://inapi.mundowebpix.com.br:5300/");
            var url = "/api/token/ValidaToken/" + token;
            RestRequest request = null;
            request = new RestRequest(url, Method.GET);
            var response = await client.ExecuteTaskAsync(request);

            return Convert.ToBoolean(response.Content);
        }
    }
}
