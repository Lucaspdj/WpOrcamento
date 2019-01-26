using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpOrcamento.Repositorio;
using WpOrcamento.Servico;
using WPOrcamento.Entidade;

namespace WpOrcamento.Dominio
{
    public class InteracaoBO
    {
        public static async Task<bool> SaveAsync(Interacao interacao, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                if (interacao.idCliente != 0)
                {
                    if (interacao.ID == 0)
                    {
                        InteracaoRep rep = new InteracaoRep();
                        try { rep.Add(interacao); return true; } catch (Exception e) { return false; }
                    }
                    else
                    {
                        InteracaoRep rep = new InteracaoRep();
                        try { rep.Update(interacao); return true; } catch (Exception e) { return false; }
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static async Task<List<Interacao>> GetListAsync(int idCliente, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                InteracaoRep rep = new InteracaoRep();
                return rep.GetAll().Where(x => x.idCliente == idCliente).ToList();
            }
            else
                return new List<Interacao>();
        }
    }
}
