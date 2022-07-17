namespace APICredito.Classes
{
    public class CreditoPessoaJuridica : Credito
    {
        public CreditoPessoaJuridica(SolicitacaoCredito solicitacao)
        {
            this.taxaCredito = 0.05;
            
            base.CalcularCredito(solicitacao);
        }

        /// <summary>
        /// Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00;
        /// </summary>
        /// <param name="valorCredito"></param>
        /// <exception cref="Exception"></exception>
        public new void validarValorMaximoCredito(double valorCredito)
        {
            double valorMinimoSolicitacaoCredito = 15000;

            if (valorCredito < valorMinimoSolicitacaoCredito)
                throw new Exception(String.Format("o Valor mínimo a ser liberado é de {0}", valorMinimoSolicitacaoCredito));
        }
    }
}