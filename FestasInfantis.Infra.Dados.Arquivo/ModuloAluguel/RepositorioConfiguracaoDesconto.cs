﻿using FestasInfantis.Dominio.Compartilhado;
using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Infra.Dados.Arquivo.Compartilhado;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuloAluguel
{
    public class RepositorioConfiguracaoDesconto : IRepositorioConfiguracaoDesconto
    {
        private ContextoDados contextoDados;

        public RepositorioConfiguracaoDesconto(ContextoDados contextoDados)
        {
            this.contextoDados = contextoDados;
        }

        public void GravarMudancas(ConfiguracaoDesconto configuracaoDesconto)
        {
            contextoDados.GravarEmArquivoJson(configuracaoDesconto);
        }

        public ConfiguracaoDesconto ObterConfiguracao()
        {
            return contextoDados.configuracaoDesconto;
        }
    }
}