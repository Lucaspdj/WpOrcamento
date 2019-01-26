using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WpOrcamento.Dominio;
using WPOrcamento.Entidade;

namespace WpOrcamentoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrcamentoController : Controller
    {

        [HttpPost("{token}")]
        [ActionName("SalvarOrcamento")]
        public async Task<JsonResult> SalvarOrcamento([FromBody]Orcamento Orcamento, string token)
        {

            if (await OrcamentoBO.SaveAsync(Orcamento, token))
                return Json("Configuracao salva com sucesso");
            else
                return Json("Encontramos algum problema ao salvar a Configuracao. Entre em contato com o suporte");
        }

        [ActionName("GetAllOrcamento")]
        [HttpGet("{idCliente}/{token}")]
        public async Task<IEnumerable<Orcamento>> GetAllOrcamento(string idCliente, string token)
        {

            return await OrcamentoBO.GetListAsync(int.Parse(idCliente), token);
        }
    }
}