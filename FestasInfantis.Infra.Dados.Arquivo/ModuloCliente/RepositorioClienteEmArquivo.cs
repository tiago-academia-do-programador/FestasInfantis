﻿using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloCliente
{
    public class RepositorioClienteEmArquivo : RepositorioEmArquivoBase<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        protected override List<Cliente> ObterRegistros()
        {
            return contextoDados.clientes;
        }
    }
}