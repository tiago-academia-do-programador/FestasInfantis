using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioTema repositorioTema;

        public TelaAluguelForm(IRepositorioAluguel repositorioAluguel, IRepositorioCliente repositorioCliente, IRepositorioTema repositorioTema)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.repositorioAluguel = repositorioAluguel;
            this.repositorioCliente = repositorioCliente;
            this.repositorioTema = repositorioTema;

            ConfigurarDependencias();
        }

        public Aluguel ObterAluguel()
        {
            int id = Convert.ToInt32(txtId.Text);

            DateTime data = txtDataFesta.Value;

            TimeSpan horarioInicio = txtHorarioInicio.Value.TimeOfDay;
            TimeSpan horarioTermino = txtHorarioTermino.Value.TimeOfDay;

            Festa festa = new Festa(ObterDadosEndereco(), data, horarioInicio, horarioTermino);

            Cliente cliente = (Cliente)cmbClientes.SelectedValue;

            Tema tema = (Tema)cmbTemas.SelectedValue;

            decimal porcentagemEntrada = Convert.ToDecimal(txtPorcentagemEntrada.Text);
            decimal porcentagemDesconto = Convert.ToDecimal(txtPorcentagemDesconto.Text);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemEntrada, porcentagemDesconto);

            if (id > 0)
                aluguel.id = id;

            return aluguel;
        }


        public void ConfigurarTela(Aluguel aluguel)
        {
            //txtId.Text = cliente.id.ToString();

            //txtNome.Text = cliente.nome;

            //txtTelefone.Text = cliente.telefone;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
        
        private void ConfigurarDependencias()
        {
            cmbClientes.Items.Clear();

            foreach (Cliente cliente in repositorioCliente.SelecionarTodos())
                cmbClientes.Items.Add(cliente);

            cmbTemas.Items.Clear();

            foreach (Tema tema in repositorioTema.SelecionarTodos())
                cmbTemas.Items.Add(tema);
        }

        private Endereco ObterDadosEndereco()
        {
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string rua = txtRua.Text;
            string bairro = txtBairro.Text;
            string numero = txtNumero.Text;

            return new Endereco(rua, bairro, cidade, estado, numero);
        }
    }
}
