using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private List<Cliente> clientes;
        private List<Tema> temas;
        private ConfiguracaoDesconto configuracaoDesconto;

        public TelaAluguelForm(ConfiguracaoDesconto configuracaoDesconto, List<Cliente> repositorioCliente, List<Tema> repositorioTema)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.configuracaoDesconto = configuracaoDesconto;

            clientes = repositorioCliente;
            temas = repositorioTema;

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

            // definir desconto
            decimal porcentagemDesconto = Convert.ToDecimal(txtPorcentagemDesconto.Text);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemEntrada, porcentagemDesconto);

            if (id > 0)
                aluguel.id = id;

            return aluguel;
        }

        public void ConfigurarTela(Aluguel aluguel)
        {
            txtId.Text = aluguel.id.ToString();

            txtDataFesta.Text = aluguel.Festa.Data.ToString();

            txtHorarioInicio.Text = aluguel.Festa.HorarioInicio.ToString();
            txtHorarioTermino.Text = aluguel.Festa.HorarioTermino.ToString();

            txtCidade.Text = aluguel.Festa.Endereco.Cidade;
            txtEstado.Text = aluguel.Festa.Endereco.Estado;
            txtRua.Text = aluguel.Festa.Endereco.Rua;
            txtBairro.Text = aluguel.Festa.Endereco.Bairro;
            txtNumero.Text = aluguel.Festa.Endereco.Numero;

            cmbClientes.SelectedItem = aluguel.Cliente;

            cmbTemas.SelectedItem = aluguel.Tema;
        }

        private void ConfigurarDependencias()
        {
            cmbClientes.Items.Clear();

            foreach (Cliente cliente in clientes)
                cmbClientes.Items.Add(cliente);

            cmbTemas.Items.Clear();

            foreach (Tema tema in temas)
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            string[] erros = aluguel.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void AtualizarPorcentualDesconto(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)cmbClientes.SelectedItem;

            decimal porcentagemDesconto = clienteSelecionado.CalcularDesconto(configuracaoDesconto);

            txtPorcentagemDesconto.Text = porcentagemDesconto.ToString();
        }
    }
}
