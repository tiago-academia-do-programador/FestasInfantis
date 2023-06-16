using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Dominio.ModuloAluguel
{

    public class Endereco
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }

        public Endereco(string rua, string cidade, int numero)
        {
            Rua = rua;
            Cidade = cidade;
            Numero = numero;
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
    }

    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Cliente cliente;
        public Festa festa;
        public Tema tema;

        public decimal Sinal { get; set; }
        public decimal Valor { get; private set; }
        public decimal ValorDesconto { get; private set; }

        public Aluguel(Cliente cliente, Festa festa, decimal sinal, decimal valor, decimal valorDesconto)
        {
            this.cliente = cliente;
            this.festa = festa;
            Sinal = sinal;
            Valor = valor;
            ValorDesconto = valorDesconto;
        }

        public Aluguel(int id, Cliente cliente, Festa festa, Tema tema, decimal sinal, decimal valor, decimal valorDesconto)
        {
            this.id = id;
            this.cliente = cliente;
            this.festa = festa;
            this.tema = tema;
            Sinal = sinal;
            Valor = valor;
            ValorDesconto = valorDesconto;
        }

        public override void AtualizarInformacoes(Aluguel registroAtualizado)
        {
            
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
