using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TelaTemaForm : Form
    {
        public TelaTemaForm()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridItens.ConfigurarGridZebrado();

            gridItens.ConfigurarGridSomenteLeitura();
        }

        public Tema ObterTema()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            decimal valor = txtValor.Value;

            List<Item> itens = new List<Item>();

            foreach (DataGridViewRow linha in gridItens.Rows)
            {
                Item itemSelecionado = (Item)linha.DataBoundItem;
                itens.Add(itemSelecionado);
            }

            Tema tema = new Tema(nome, valor, itens);

            if (id > 0)
                tema.id = id;

            return tema;
        }

        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "descricao",
                    HeaderText = "Descrição"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valor",
                    HeaderText = "Valor"
                }
            };

            gridItens.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Item> itens)
        {
            gridItens.Rows.Clear();

            foreach (Item item in itens)
            {
                gridItens.Rows.Add(item.id, item.descricao, item.valor);
            }
        }

        private void btnSelecionarItens_Click(object sender, EventArgs e)
        {
            TelaSelecaoItensForm telaItens = new TelaSelecaoItensForm();

            telaItens.ShowDialog();
        }

        public void ConfigurarTela(Tema tema)
        {
            txtId.Text = tema.id.ToString();

            txtNome.Text = tema.Nome;

            txtValor.Value = tema.Valor;

            gridItens.Rows.Clear();

            foreach (Item item in tema.Itens)
            {
                gridItens.Rows.Add(item.id, item.descricao, item.valor);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Tema tema = ObterTema();

            string[] erros = tema.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
