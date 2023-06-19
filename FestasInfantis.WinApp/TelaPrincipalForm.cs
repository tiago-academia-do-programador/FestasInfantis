using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Memoria.ModuleTema;
using FestasInfantis.Infra.Dados.Memoria.ModuloCliente;
using FestasInfantis.Infra.Dados.Memoria.ModuloItem;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloItem;
using FestasInfantis.WinApp.ModuloTema;

namespace FestasInfantis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private IRepositorioCliente repositorioCliente =
            new RepositorioClienteEmMemoria(ConfigurarRegistrosClientes());

        private IRepositorioTema repositorioTema =
            new RepositorioTemaEmMemoria(ConfigurarRegistrosTemas());

        private IRepositorioItem repositorioItem =
            new RepositorioItemEmMemoria(ConfigurarRegistrosItens());

        private static TelaPrincipalForm telaPrincipal;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            telaPrincipal = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();

                return telaPrincipal;
            }
        }

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorCliente(repositorioCliente);

            ConfigurarTelaPrincipal(controlador);
        }

        private void itensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorItem(repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void temasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTema(repositorioTema, repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void tarefasMenuItem_Click(object sender, EventArgs e)
        {
            //controlador = new ControladorTarefa(repositorioTarefa);

            ConfigurarTelaPrincipal(controlador);
        }

        private void categoriasMenuItem_Click(object sender, EventArgs e)
        {
            //controlador = new ControladorCategoria(repositorioCategoria);

            ConfigurarTelaPrincipal(controlador);
        }

        private void despesasMenuItem_Click(object sender, EventArgs e)
        {
            //controlador = new ControladorDespesa(repositorioDespesa);

            ConfigurarTelaPrincipal(controlador);
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarBarraFerramentas(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarBarraFerramentas(ControladorBase controlador)
        {
            barraFerramentas.Enabled = true;

            ConfigurarToolTips(controlador);

            ConfigurarEstados(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
            btnAdicionarItens.ToolTipText = controlador.ToolTipAdicionarItens;
            btnConcluirItens.ToolTipText = controlador.ToolTipConcluirItens;
            btnVisualizarAlugueis.ToolTipText = controlador.ToolTipVisualizarAlugueis;
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnFiltrar.Enabled = controlador.FiltrarHabilitado;
            btnAdicionarItens.Enabled = controlador.AdicionarItensHabilitado;
            btnConcluirItens.Enabled = controlador.ConcluirItensHabilitado;
            btnVisualizarAlugueis.Enabled = controlador.VisualizarAlugueisHabilitado;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnConcluirItens_Click(object sender, EventArgs e)
        {
            controlador.ConcluirItens();
        }

        private void btnVisualizarAlugueis_Click(object sender, EventArgs e)
        {
            (controlador as ControladorCliente)!.VisualizarAlugueis();
        }

        private static List<Cliente> ConfigurarRegistrosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            List<Aluguel> alugueis = new List<Aluguel>();

            Festa festa1 = new Festa(new Endereco("Clube Princesa", "Lages", 25), DateTime.Now, new TimeSpan(), new TimeSpan());
            Festa festa2 = new Festa(new Endereco("Clube Caça e Tiro", "Lages", 110), DateTime.Now, new TimeSpan(), new TimeSpan());
            Tema tema1 = new Tema("Homem-Aranha", new List<Item>());
            Tema tema2 = new Tema("Branca de Neve", new List<Item>());

            Cliente cliente = new Cliente(1, "Tiago Santini", "49 98505-6251");

            alugueis.Add(new Aluguel(1, cliente, festa1, tema1, 50, 500, 200));
            alugueis.Add(new Aluguel(2, cliente, festa2, tema2, 40, 900, 100));

            cliente.AdicionarAluguel(alugueis[0]);
            cliente.AdicionarAluguel(alugueis[1]);

            clientes.Add(cliente);

            return clientes;
        }

        private static List<Item> ConfigurarRegistrosItens()
        {
            List<Item> itens = new List<Item>();

            Item item1 = new Item(1, "Mesa Grande", 80);
            Item item2 = new Item(2, "Balões de Festa", 50);

            itens.Add(item1);
            itens.Add(item2);

            return itens;
        }

        private static List<Tema> ConfigurarRegistrosTemas()
        {
            List<Tema> temas = new List<Tema>();

            List<Item> itens = new List<Item>();

            Item item1 = new Item(1, "Mesa Grande", 80);
            itens.Add(item1);

            Tema tema1 = new Tema(1, "Festa de Casamento", itens);
            temas.Add(tema1);

            return temas;
        }

    }
}