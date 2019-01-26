using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WpOrcamento.Dominio;
using WPOrcamento.Entidade;

namespace WpOrcamentoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class InteracaoController : Controller
    {

        [HttpPost("{token}")]
        [ActionName("SalvarInteracao")]
        public async Task<JsonResult> SalvarInteracao([FromBody]Interacao interacao, string token)
        {

            if (await InteracaoBO.SaveAsync(interacao, token))
                return Json("Configuracao salva com sucesso");
            else
                return Json("Encontramos algum problema ao salvar a Configuracao. Entre em contato com o suporte");
        }

        [ActionName("GetAllInteracao")]
        [HttpGet("{idCliente}/{token}")]
        public async Task<IEnumerable<Interacao>> GetAllInteracao(string idCliente, string token)
        {

            return await InteracaoBO.GetListAsync(int.Parse(idCliente), token);
        }
    }
}