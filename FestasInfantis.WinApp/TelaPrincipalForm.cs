using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Memoria.ModuloCliente;
using FestasInfantis.WinApp.ModuloCliente;

namespace FestasInfantis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private IRepositorioCliente repositorioCliente =
            new RepositorioClienteEmMemoria(ConfigurarRegistrosClientes());

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

        private void compromissosMenuItem_Click(object sender, EventArgs e)
        {
            //controlador = new ControladorCompromisso(repositorioContato, repositorioCompromisso);

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
            (controlador as ControladorCliente)!.VisualizarAlugueis ();
        }

        private static List<Cliente> ConfigurarRegistrosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            List<Aluguel> alugueis = new List<Aluguel>();

            Festa festa1 = new Festa(new Endereco("Clube Princesa", "Lages", 25), DateTime.Now, new TimeSpan(), new TimeSpan());
            Festa festa2 = new Festa(new Endereco("Clube Caça e Tiro", "Lages", 110), DateTime.Now, new TimeSpan(), new TimeSpan());
            Tema tema1 = new Tema("Homem-Aranha", 500, new List<object>());
            Tema tema2 = new Tema("Branca de Neve", 650, new List<object>());

            Cliente cliente = new Cliente(1, "Tiago Santini", "49 98505-6251");

            alugueis.Add(new Aluguel(1, cliente, festa1, tema1, 50, 500, 200));
            alugueis.Add(new Aluguel(2, cliente, festa2, tema2, 40, 900, 100));

            cliente.AdicionarAluguel(alugueis[0]);
            cliente.AdicionarAluguel(alugueis[1]);

            clientes.Add(cliente);

            return clientes;
        }
    }
}