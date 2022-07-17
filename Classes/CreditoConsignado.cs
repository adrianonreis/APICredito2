namespace APICredito.Classes
{
    public class CreditoConsignado : Credito
    {
        public CreditoConsignado(SolicitacaoCredito solicitacao)
        {
            this.taxaCredito = 0.01;

            base.CalcularCredito(solicitacao);
        }

    }
}