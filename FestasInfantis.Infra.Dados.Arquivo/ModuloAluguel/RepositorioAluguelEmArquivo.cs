using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuloAluguel
{
    public class RepositorioAluguelEmArquivo : RepositorioEmArquivoBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        public override void Inserir(Aluguel novoRegistro)
        {
            Cliente cliente = novoRegistro.Cliente;

            cliente.RegistrarAluguel(novoRegistro);

            base.Inserir(novoRegistro);
        }

        public override void Editar(int id, Aluguel registroAtualizado)
        {
            Cliente cliente = registroAtualizado.Cliente;

            cliente.RegistrarAluguel(registroAtualizado);

            base.Editar(registroAtualizado.id, registroAtualizado);
        }

        public List<Aluguel> SelecionarConcluidas()
        {
            return ObterRegistros()
                .Where(x => x.PagamentoConcluido).ToList();
        }

        public List<Aluguel> SelecionarPendentes()
        {
            return ObterRegistros()
                .Where(x => x.PagamentoConcluido == false).ToList();
        }

        protected override List<Aluguel> ObterRegistros()
        {
            return contextoDados.alugueis;
        }
    }
}
