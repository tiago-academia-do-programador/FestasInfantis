﻿using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.Dominio.ModuloCliente
{
    public interface IRepositorioCliente
    {
        void Inserir(Cliente novoCliente);
        void Editar(int id, Cliente cliente);
        void Excluir(Cliente clienteSelecionado);
        List<Cliente> SelecionarTodos();
        Cliente SelecionarPorId(int id);

        void RegistrarAluguelDoCliente(Cliente cliente, Aluguel aluguelEfetuado);
    }
}
