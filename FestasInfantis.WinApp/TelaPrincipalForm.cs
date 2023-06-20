using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Arquivo;
using FestasInfantis.Infra.Dados.Arquivo.Compartilhado;
using FestasInfantis.Infra.Dados.Memoria.ModuleTema;
using FestasInfantis.Infra.Dados.Memoria.ModuloAluguel;
using FestasInfantis.Infra.Dados.Memoria.ModuloCliente;
using FestasInfantis.Infra.Dados.Memoria.ModuloItem;
using FestasInfantis.WinApp.ModuloAluguel;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloItem;
using FestasInfantis.WinApp.ModuloTema;

namespace FestasInfantis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private static ContextoDados contextoDados = new ContextoDados(carregarDados: true);

        private IRepositorioConfiguracaoDesconto repositorioDesconto =
            new RepositorioConfiguracaoDesconto(contextoDados);

        private IRepositorioCliente repositorioCliente =
            new RepositorioClienteEmMemoria(new List<Cliente>());

        private IRepositorioTema repositorioTema =
            new RepositorioTemaEmMemoria(new List<Tema>());

        private IRepositorioItem repositorioItem =
            new RepositorioItemEmMemoria(new List<Item>());


        private IRepositorioAluguel repositorioAluguel =
            new RepositorioAluguelEmMemoria(new List<Aluguel>());

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

        private void alugueisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorAluguel(
                repositorioAluguel,
                repositorioCliente,
                repositorioTema,
                repositorioDesconto);

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
            btnConfigurarDescontos.ToolTipText = controlador.ToolTipConfigurarDescontos;
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
            btnConfigurarDescontos.Enabled = controlador.ConfigurarDescontosHabilitado;
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

        private void btnConfigurarDescontos_Click(object sender, EventArgs e)
        {
            (controlador as ControladorAluguel)!.ConfigurarDescontos();
        }
    }
}