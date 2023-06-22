using FestasInfantis.Dominio.Compartilhado;
using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Arquivo.Compartilhado;
using FestasInfantis.Infra.Dados.Arquivo.ModuleTema;
using FestasInfantis.Infra.Dados.Arquivo.ModuloAluguel;
using FestasInfantis.Infra.Dados.Memoria.ModuloCliente;
using FestasInfantis.Infra.Dados.Memoria.ModuloItem;

namespace FestasInfantis.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ContextoDados ctx = new ContextoDados(carregarDados: true);

            IRepositorioConfiguracaoDesconto repositorioDesconto = new RepositorioConfiguracaoEmArquivo(carregarDados: true);
            IRepositorioCliente repositorioCliente = new RepositorioClienteEmArquivo(ctx);
            IRepositorioItem repositorioItem = new RepositorioItemEmArquivo(ctx);
            IRepositorioTema repositorioTema = new RepositorioTemaEmArquivo(ctx);
            IRepositorioAluguel repositorioAluguel = new RepositorioAluguelEmArquivo(ctx);

            Endereco endereco = new Endereco("Marechal Deodoro", "Centro", "Lages", "SC", "40");
            Festa festa = new Festa(endereco, DateTime.Now, TimeSpan.Parse("1200"), TimeSpan.Parse("1800"));

            Cliente cliente = new Cliente(1, "Tiago Santini", "(49) 98505-6251");

            List<Item> itens = new List<Item>();

            Item item = new Item(1, "Mesa Grande x50", 150m);

            itens.Add(item);

            Tema tema = new Tema(1, "Festa de Aniversário", itens);

            Aluguel aluguel = new Aluguel(1, cliente, festa, tema, 40, 0.0m);

            repositorioCliente.Inserir(cliente);
            repositorioItem.Inserir(item);
            repositorioTema.Inserir(tema);
            repositorioAluguel.Inserir(aluguel);
        }
    }
}