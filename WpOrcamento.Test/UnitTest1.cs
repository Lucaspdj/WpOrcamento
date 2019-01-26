using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpOrcamento.Dominio;
using WPOrcamento.Entidade;

namespace WpOrcamento.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod1Async()
        {
            Agenda agenda = new Agenda
            {
                Ativo = true,
                DataCriacao = DateTime.Now,
                DateAlteracao = DateTime.Now,
                Descricao = "teste",
                idCliente = 1,
                Nome = "Agenda",
                Orcamento = 1,
                Status = 1,
                UsuarioCriacao = 1,
                UsuarioEdicao = 1
            };

            var a = await AgendaBO.SaveAsync(agenda,"testetete");
        }
    }
}
