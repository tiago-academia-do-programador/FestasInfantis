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
            return Tema.Valor - CalcularValorSinal() - CalcularValorDesconto();
        }

        public decimal CalcularValorSinal()
        {
            return Tema.Valor * PorcentagemSinal / 100;
        }

        public decimal CalcularValorDesconto()
        {
            return Tema.Valor * PorcentagemDesconto / 100;
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

            if (Cliente != null)
                erros.Add("O campo 'Cliente' é obrigatório");

            if (Tema != null)
                erros.Add("O campo 'Tema' é obrigatório");
                
            if (PorcentagemSinal <= 0)
                erros.Add("O campo '% do Sinal' é obrigatório");

            return erros.ToArray();
        }
    }
}
