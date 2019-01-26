using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpOrcamento.Repositorio;
using WpOrcamento.Servico;
using WPOrcamento.Entidade;

namespace WpOrcamento.Dominio
{
    public class OrcamentoBO
    {
        public static async Task<bool> SaveAsync(Orcamento orcamento, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                if (orcamento.idCliente != 0)
                {
                    if (orcamento.ID == 0)
                    {
                        Orcamentorep rep = new Orcamentorep();
                        try { rep.Add(orcamento); return true; } catch (Exception e) { return false; }
                    }
                    else
                    {
                        Orcamentorep rep = new Orcamentorep();
                        try { rep.Update(orcamento); return true; } catch (Exception e) { return false; }
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static async Task<List<Orcamento>> GetListAsync(int idCliente, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                Orcamentorep rep = new Orcamentorep();
                return rep.GetAll().Where(x => x.idCliente == idCliente).ToList();
            }
            else
                return new List<Orcamento>();
        }
    }
}
