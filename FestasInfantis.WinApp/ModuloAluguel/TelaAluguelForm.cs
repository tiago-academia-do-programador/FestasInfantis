﻿using FestasInfantis.Dominio.ModuloAluguel;
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

            ConfigurarComboBoxes();

            cmbEntrada.Items.Add(40m);
            cmbEntrada.Items.Add(50m);
            cmbEntrada.SelectedIndex = 0;
        }

        public Aluguel ObterAluguel()
        {
            int id = Convert.ToInt32(txtId.Text);

            DateTime data = txtDataFesta.Value;

            TimeSpan horarioInicio = TimeSpan.Parse(txtHorarioInicio.Text);
            TimeSpan horarioTermino = TimeSpan.Parse(txtHorarioTermino.Text);

            Festa festa = new Festa(ObterDadosEndereco(), data, horarioInicio, horarioTermino);

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;

            Tema tema = (Tema)cmbTemas.SelectedItem;

            decimal porcentagemEntrada = Convert.ToDecimal(cmbEntrada.SelectedItem);

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

            cmbEntrada.SelectedItem = aluguel.PorcentagemSinal;
        }

        private void ConfigurarComboBoxes()
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

        private void AtualizarTabelaValores()
        {
            txtValorPendente.Text = ObterAluguel().CalcularValorPendente().ToString();
            txtValorSinal.Text = ObterAluguel().CalcularValorSinal().ToString();
            txtValorDesconto.Text = ObterAluguel().CalcularValorDesconto().ToString();
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

        private void AtualizarPorcentagemDesconto(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)cmbClientes.SelectedItem;

            decimal porcentagemDesconto = clienteSelecionado.CalcularDesconto(configuracaoDesconto);

            txtPorcentagemDesconto.Text = porcentagemDesconto.ToString();

            if (clienteSelecionado != null)
                pnlTema.Enabled = true;
            else
                pnlTema.Enabled = false;
        }

        private void AtualizarValorTotal(object sender, EventArgs e)
        {
            Tema temaSelecionado = (Tema)cmbTemas.SelectedItem;

            decimal valorTotal = temaSelecionado.CalcularValor();

            txtValorTema.Text = valorTotal.ToString();

            if (temaSelecionado != null)
                pnlDadosAluguel.Enabled = true;
            else
                pnlDadosAluguel.Enabled = false;

            AtualizarTabelaValores();
        }

        private void AtualizarPorcentagemEntrada(object sender, EventArgs e)
        {
            Tema temaSelecionado = (Tema)cmbTemas.SelectedItem;

            if (temaSelecionado != null)
                AtualizarTabelaValores();
        }
    }
}
