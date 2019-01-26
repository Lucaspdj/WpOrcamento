using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WpOrcamento.Dominio;
using WPOrcamento.Entidade;

namespace WpStatusAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class StatusController : Controller
    {


        [HttpPost("{token}")]
        [ActionName("SalvarStatus")]
        public async Task<JsonResult> SalvarStatus([FromBody]Status Status, string token)
        {

            if (await StatusBO.SaveAsync(Status, token))
                return Json("Configuracao salva com sucesso");
            else
                return Json("Encontramos algum problema ao salvar a Configuracao. Entre em contato com o suporte");
        }

        [ActionName("GetAllStatus")]
        [HttpGet("{idCliente}/{token}")]
        public async Task<IEnumerable<Status>> GetAllStatus(string idCliente, string token)
        {

            return await StatusBO.GetListAsync(int.Parse(idCliente), token);
        }
    }
}