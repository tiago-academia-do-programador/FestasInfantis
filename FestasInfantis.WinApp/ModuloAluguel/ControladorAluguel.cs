﻿using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.WinApp.ModuloCliente;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private TabelaAluguelControl tabelaAlugueis;
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioTema repositorioTema;
        private IRepositorioConfiguracaoDesconto repositorioDesconto;

        public ControladorAluguel(
            IRepositorioAluguel repositorioAluguel, 
            IRepositorioCliente repositorioCliente,
            IRepositorioTema repositorioTema,
            IRepositorioConfiguracaoDesconto repositorioDesconto
            )
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioCliente = repositorioCliente;
            this.repositorioTema = repositorioTema;
            this.repositorioDesconto = repositorioDesconto;
        }

        public override string ToolTipInserir { get { return "Inserir novo Aluguel"; } }

        public override string ToolTipEditar { get { return "Editar Aluguel existente"; } }
            
        public override string ToolTipExcluir { get { return "Excluir Aluguel existente"; } }
        
        public override string ToolTipConfigurarDescontos { get { return "Configurar Descontos de Aluguel"; } }

        public override bool ConfigurarDescontosHabilitado { get { return true; } }

        public override void Inserir()
        {
            TelaAluguelForm telaAluguel = 
                new TelaAluguelForm(
                    repositorioDesconto.ObterConfiguracao(),
                    repositorioAluguel.SelecionarTodos(),
                    repositorioCliente.SelecionarTodos(),
                    repositorioTema.SelecionarTodos());

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguel = telaAluguel.ObterAluguel();

                repositorioAluguel.Inserir(aluguel);
                
                CarregarAlugueis();
            }
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!",
                    "Exclusão de Alugueis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o aluguel {aluguel.id}?", "Exclusão de Aluguéis",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioAluguel.Excluir(aluguel);
                CarregarAlugueis();
            }

        }

        public void ConfigurarDescontos()
        {
            ConfiguracaoDesconto configuracao = repositorioDesconto.ObterConfiguracao();

            TelaConfiguracaoDesconto telaConfiguracao = new TelaConfiguracaoDesconto(configuracao);

            DialogResult opcaoEscolhida = telaConfiguracao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                ConfiguracaoDesconto novaConfiguracao = telaConfiguracao.ObterConfiguracaoDesconto();

                repositorioDesconto.GravarMudancas(novaConfiguracao);
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaAlugueis == null)
                tabelaAlugueis = new TabelaAluguelControl();

            CarregarAlugueis();

            return tabelaAlugueis;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Aluguéis";
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAlugueis.AtualizarRegistros(alugueis);
        }

        private Aluguel ObterAluguelSelecionado()
        {
            int id = tabelaAlugueis.ObterIdSelecionado();

            return repositorioAluguel.SelecionarPorId(id);
        }
    }
}
