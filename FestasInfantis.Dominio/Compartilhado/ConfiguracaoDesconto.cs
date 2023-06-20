namespace FestasInfantis.Dominio.Compartilhado
{
    public class ConfiguracaoDesconto
    {
        public decimal PorcentagemDesconto { get; private set; }
        public decimal PorcentagemMaxima { get; private set; }

        public ConfiguracaoDesconto(decimal porcentagemPorDesconto, decimal porcentagemMaxima)
        {
            PorcentagemDesconto = porcentagemPorDesconto;
            PorcentagemMaxima = porcentagemMaxima;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (PorcentagemDesconto > PorcentagemMaxima)
                erros.Add("A porcentagem de desconto não pode ultrapassar a porcentagem máxima!");

            return erros.ToArray();
        }
    }
}
