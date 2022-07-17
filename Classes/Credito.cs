namespace APICredito.Classes
{
    public class Credito
    {
        public enum TTipoCredito
        {
            CreditoDireto = 0,
            CreditoConsignado = 1,
            CreditoPessoaJuridica = 2,
            CreditoPessoaFisica = 3,
            CreditoImobiliario = 4
        }
        //
        public double taxaCredito { get; set; }
        //
        public string? status { get; set; }
        public double valorTotalComJuros { get; set; }
        public double valorJuros { get; set; }
        public string? mensagem { get; set; }
        //
        internal SolicitacaoCredito solicitacao = new SolicitacaoCredito(); //un
        //

        public Credito()
        {
            status = "Recusado";
            mensagem = "tipo de crédito selecionado inválido";
        }

        public Credito(SolicitacaoCredito solicitacao)
        {
            this.CalcularCredito(solicitacao);
        }

        public void CalcularCredito(SolicitacaoCredito solicitacao)
        {
            this.solicitacao = solicitacao;

            try
            {
                this.validarValorMinimo(solicitacao.valorCredito);
                this.validarQtdeMinimaParcelas(solicitacao.qtdeParcelas);
                this.validarValorMaximoCredito(solicitacao.valorCredito);
                this.validarPrimeiroVencimento(solicitacao.primeiroVencimento);

                status = "Aprovado";
                mensagem = "";

                this.valorJuros = this.solicitacao.valorCredito * this.taxaCredito;
                this.valorTotalComJuros = this.solicitacao.valorCredito + this.valorJuros;

            }
            catch (Exception ex)
            {
                status = "Recusado";
                mensagem = ex.Message.ToString();
            }
        }

        public void validarValorMinimo(double valorCredito)
        {
            double valorMaximo = 1000*1000;
            if (valorCredito > valorMaximo)
                throw new Exception(String.Format("o Valor máximo a ser liberado é de {0}", valorMaximo));
            
            if (valorCredito <= 0)
                throw new Exception(String.Format("sabe que isso não existe, né? Valor do pedido de crédito = {0}", valorCredito));
        }

        public void validarQtdeMinimaParcelas(int qtdeParcelas)
        {
            int qtdeMinima = 5;
            int qtdeMaxima = 72;
            
            if (qtdeParcelas < qtdeMinima)
                throw new Exception(String.Format("a qtde mínima de parcelas é de {0}", qtdeMinima));
            
            if (qtdeParcelas > qtdeMaxima)
                throw new Exception(String.Format("a qtde máxima de parcelas é de {0}", qtdeMaxima));
        }

        public void validarValorMaximoCredito(double valorCredito)
        {
            //ignorar este método: a regra está especificada no credito juridico
        }

        private void validarPrimeiroVencimento(DateTime primeiroVencimento)
        {
            if (primeiroVencimento < DateTime.Now.AddDays(15))
                throw new Exception(String.Format("o primeiro vencimento deve ser no mínimo 15 dias a partir da data atual"));

            if (primeiroVencimento > DateTime.Now.AddDays(40))
                throw new Exception(String.Format("o primeiro vencimento deve ser no máximo 40 dias a partir da data atual"));

        }
    }
}