using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WpOrcamento.Dominio;
using WPOrcamento.Entidade;

namespace WpOrcamentoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AgendaController : Controller
    {

        [HttpPost("{token}")]
        [ActionName("SalvarAgenda")]
        public async Task<JsonResult> SalvarAgenda([FromBody]Agenda agenda, string token)
        {

            if (await AgendaBO.SaveAsync(agenda, token))
                return Json("Configuracao salva com sucesso");
            else
                return Json("Encontramos algum problema ao salvar a Configuracao. Entre em contato com o suporte");
        }

        [ActionName("GetAllAgenda")]
        [HttpGet("{idCliente}/{token}")]
        public async Task<IEnumerable<Agenda>> GetAllAgenda(string idCliente, string token)
        {

            return await AgendaBO.GetListAsync(int.Parse(idCliente), token);
        }

    }
}