using System.Text.Json.Serialization;
using System.Text.Json;
using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.Infra.Dados.Arquivo.Compartilhado
{
    public class ContextoDados
    {
        private const string NOME_ARQUIVO = "configuracoes.json";

        private const decimal PORCENTAGEM_DESCONTO_PADRAO = 1.5m;
        private const decimal PORCENTAGEM_DESCONTO_MAXIMA = 20m;

        public ConfiguracaoDesconto configuracaoDesconto;

        public ContextoDados()
        {
            configuracaoDesconto = 
                new ConfiguracaoDesconto(PORCENTAGEM_DESCONTO_PADRAO, PORCENTAGEM_DESCONTO_MAXIMA);
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDoArquivoJson();
        }

        public void GravarEmArquivoJson(ConfiguracaoDesconto configuracaoDesconto)
        {
            this.configuracaoDesconto = configuracaoDesconto;

            JsonSerializerOptions config = ObterConfiguracoes();

            string registrosJson = JsonSerializer.Serialize(this, config);

            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                if (registrosJson.Length > 0)
                {
                    ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosJson, config)!;

                    configuracaoDesconto = ctx.configuracaoDesconto;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
