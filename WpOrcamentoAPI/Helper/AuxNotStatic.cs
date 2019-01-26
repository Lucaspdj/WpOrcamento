using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using WpOrcamentoAPI.Model;

namespace WpOrcamentoAPI.Helper
{
    public class AuxNotStatic
    {
        public static async Task<MotorAuxViewModel> GetInfoMotorAux(string aux, int idcliente)
        {
            try
            {
                RestClient client = new RestClient("http://inapi.mundowebpix.com.br:5400/");
                var url = "api/motoraux/acessarmotor/" + aux;
                RestRequest request = null;
                request = new RestRequest(url, Method.GET);
                var response = await client.ExecuteTaskAsync(request);
                var lstData = JsonConvert.DeserializeObject<MotorAuxViewModel>(response.Content);
                return lstData;
            }
            catch (Exception ex)
            {
                return new MotorAuxViewModel();
            }
        }
    }
}
