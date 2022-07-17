namespace APICredito.Classes
{
    public class CreditoDireto : Credito
    {
        public CreditoDireto(SolicitacaoCredito solicitacao)
        {
            this.taxaCredito = 0.02;

            base.CalcularCredito(solicitacao);
        }

    }
}