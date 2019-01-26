using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpOrcamento.Repositorio;
using WpOrcamento.Servico;
using WPOrcamento.Entidade;

namespace WpOrcamento.Dominio
{
    public class AgendaBO
    {
        public static async Task<bool> SaveAsync(Agenda agenda, string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                if (agenda.idCliente != 0)
                {
                    if (agenda.ID == 0)
                    {
                        AgendaRep rep = new AgendaRep();
                        try { rep.Add(agenda); return true; } catch (Exception e) { return false; }
                    }
                    else
                    {
                        AgendaRep rep = new AgendaRep();
                        try { rep.Update(agenda); return true; } catch (Exception e) { return false; }
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static async Task<List<Agenda>> GetListAsync(int idCliente,string token)
        {
            if (await SegurancaServ.validaTokenAsync(token))
            {
                AgendaRep rep = new AgendaRep();
                return rep.GetAll().Where(x => x.idCliente == idCliente).ToList();
            }
            else
                return new List<Agenda>();
        }
    }
}
