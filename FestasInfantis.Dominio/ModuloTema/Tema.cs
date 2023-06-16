namespace FestasInfantis.Dominio.ModuloTema
{
    public class Tema : EntidadeBase<Tema>
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public List<object> Itens { get; set; }

        public Tema(string descricao, decimal valor, List<object> itens)
        {
            Descricao = descricao;
            Valor = valor;
            Itens = itens;
        }

        public override void AtualizarInformacoes(Tema registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
