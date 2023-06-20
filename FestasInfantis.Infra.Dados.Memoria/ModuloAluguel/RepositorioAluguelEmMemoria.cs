using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Infra.Dados.Memoria.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloAluguel
{
    public class RepositorioAluguelEmMemoria : RepositorioEmMemoriaBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmMemoria(List<Aluguel> alugueis) : base(alugueis)
        {
        }
    }
}
