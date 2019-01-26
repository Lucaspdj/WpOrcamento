using System;

namespace WPOrcamento.Entidade
{
    public class Orcamento : Base
    {
        public DateTime DataEvento{ get; set; }
        public string Local { get; set; }
        public TimeSpan InicioEvento { get; set; }
        public TimeSpan FimEvento { get; set; }
        public string Mensagem { get; set; }
        public string Email { get; set; }
        public Interacao Interacoes { get; set; }
        public Status estado { get; set; }
    }
}
