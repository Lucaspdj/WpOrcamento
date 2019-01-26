using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpOrcamento.Repositorio;
using WpOrcamento.Servico;
using WPOrcamento.Entidade;

namespace WpOrcamento.Dominio
{
    public class StatusBO
    {
        public static async Task<bool> SaveAsync(Status Status, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                if (Status.idCliente != 0)
                {
                    if (Status.ID == 0)
                    {
                        StatusRep rep = new StatusRep();
                        try { rep.Add(Status); return true; } catch (Exception e) { return false; }
                    }
                    else
                    {
                        StatusRep rep = new StatusRep();
                        try { rep.Update(Status); return true; } catch (Exception e) { return false; }
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static async Task<List<Status>> GetListAsync(int idCliente, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                StatusRep rep = new StatusRep();
                return rep.GetAll().Where(x => x.idCliente == idCliente).ToList();
            }
            else
                return new List<Status>();
        }
    }
}
