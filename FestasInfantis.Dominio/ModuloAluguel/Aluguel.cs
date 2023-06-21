using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Dominio.ModuloAluguel
{
    public class Endereco
    {
        public Endereco(string rua, string bairro, string cidade, string estado, string numero)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
        }

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Bairro}, {Numero}, {Cidade}, {Estado}";
        }
    }

    public class Festa
    {
        public Endereco Endereco { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }

        public Festa(Endereco endereco, DateTime data, TimeSpan horarioInicio, TimeSpan horarioTermino)
        {
            Endereco = endereco;
            Data = data;
            HorarioInicio = horarioInicio;
            HorarioTermino = horarioTermino;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (Data < DateTime.Today)
                erros.Add("A data da festa não pode ser no passado!");

            if (HorarioTermino < HorarioInicio)
                erros.Add("O horário de término não pode ser antes do início!");

            if (string.IsNullOrEmpty(Endereco.Cidade))
                erros.Add("O campo 'Cidade' é obrigatório!");

            if (string.IsNullOrEmpty(Endereco.Estado))
                erros.Add("O campo 'Estado' é obrigatório!");

            if (string.IsNullOrEmpty(Endereco.Rua))
                erros.Add("O campo 'Rua' é obrigatório!");
            
            if (string.IsNullOrEmpty(Endereco.Bairro))
                erros.Add("O campo 'Bairro' é obrigatório!");

            if (string.IsNullOrEmpty(Endereco.Numero))
                erros.Add("O campo 'Número' é obrigatório!");

            return erros.ToArray();
        }
    }

    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Cliente Cliente { get; private set; }
        public Festa Festa { get; private set; }
        public Tema Tema { get; private set; }
        public decimal PorcentagemSinal { get; private set; }
        public decimal PorcentagemDesconto { get; private set; }

        public Aluguel(Cliente cliente, Festa festa, Tema tema, decimal porcentagemSinal, decimal porcentagemDesconto)
        {
            Cliente = cliente;
            Festa = festa;
            Tema = tema;
            PorcentagemSinal = porcentagemSinal;
            PorcentagemDesconto = porcentagemDesconto;
        }

        public decimal CalcularValorPendente()
        {
            return CalcularValorDesconto() - CalcularValorSinal();
        }

        public decimal CalcularValorSinal()
        {
            return Tema.CalcularValor() * PorcentagemSinal / 100;
        }

        public decimal CalcularValorDesconto()
        {
            return Tema.CalcularValor() - Tema.CalcularValor() * PorcentagemDesconto / 100;
        }

        public override void AtualizarInformacoes(Aluguel registroAtualizado)
        {
            Cliente = registroAtualizado.Cliente;
            Festa = registroAtualizado.Festa;
            Tema = registroAtualizado.Tema;
            PorcentagemDesconto = registroAtualizado.PorcentagemDesconto;
            PorcentagemSinal = registroAtualizado.PorcentagemSinal;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            erros.AddRange(Festa.Validar());

            if (Cliente == null)
                erros.Add("O campo 'Cliente' é obrigatório");

            if (Tema == null)
                erros.Add("O campo 'Tema' é obrigatório");
                
            if (PorcentagemSinal <= 0)
                erros.Add("O campo '% do Sinal' é obrigatório");

            return erros.ToArray();
        }
    }
}
