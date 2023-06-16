using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.Dominio.ModuloTema
{
    public class Tema : EntidadeBase<Tema>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public List<Item> Itens { get; set; }

        public Tema(int id, string descricao, decimal valor, List<Item> itens)
        {
            this.id = id;
            Nome = descricao;
            Valor = valor;
            Itens = itens;
        }

        public Tema(string descricao, decimal valor, List<Item> itens)
        {
            Nome = descricao;
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
