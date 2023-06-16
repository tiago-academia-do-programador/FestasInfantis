using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.Dominio.ModuloTema
{
    public class Tema : EntidadeBase<Tema>
    {
        public string Nome { get; set; }

        public decimal Valor 
        { 
            get 
            { 
                return Itens.Aggregate(0m, (soma, item) => soma + item.valor);
            }
            set
            {
                
            }
        }
        public List<Item> Itens { get; set; }

        public Tema(int id, string descricao,List<Item> itens)
        {
            this.id = id;
            Nome = descricao;
            Itens = itens;
        }

        public Tema(string descricao, List<Item> itens)
        {
            Nome = descricao;
            Itens = itens;
        }

        public override void AtualizarInformacoes(Tema registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.Nome = registroAtualizado.Nome;
            this.Itens = registroAtualizado.Itens;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo 'Nome' é obrigatório");

            if (Nome.Length < 3)
                erros.Add("O campo 'Nome' deve conter no mínimo 3 caracteres");

            if (Valor < 1)
                erros.Add("O campo 'Valor' não pode receber o valor 0");

            return erros.ToArray();
        }
    }
}
