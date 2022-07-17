namespace APICredito.Classes
{
    public class CreditoImobiliario : Credito
    {
        public CreditoImobiliario(SolicitacaoCredito solicitacao)
        {
            this.taxaCredito = 0.09;

            base.CalcularCredito(solicitacao);
        }
    }
}