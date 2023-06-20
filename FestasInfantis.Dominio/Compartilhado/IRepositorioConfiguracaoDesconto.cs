namespace FestasInfantis.Dominio.Compartilhado
{
    public interface IRepositorioConfiguracaoDesconto
    {
        void GravarMudancas(ConfiguracaoDesconto configuracaoDesconto);
        ConfiguracaoDesconto ObterConfiguracao();
    }
}
