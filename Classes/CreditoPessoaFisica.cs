namespace APICredito.Classes
{
    public class CreditoPessoaFisica : Credito
    {
        public CreditoPessoaFisica(SolicitacaoCredito solicitacao)
        {
            this.taxaCredito = 0.03;

            base.CalcularCredito(solicitacao);
        }
    }
}