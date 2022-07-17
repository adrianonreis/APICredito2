namespace APICredito.Classes
{
    public class SolicitacaoCredito
    {
        public double valorCredito { get; set; }
        public Credito.TTipoCredito tipoCredito { get; set; }
        public int qtdeParcelas { get; set; }
        public DateTime primeiroVencimento { get; set; }

        public Credito validarTipoCredito()
        {
            Credito credito = new Credito(); //un

            switch (this.tipoCredito)
            {
                case Credito.TTipoCredito.CreditoDireto:
                    credito = new CreditoDireto(this);
                    break;
                case Credito.TTipoCredito.CreditoConsignado:
                    credito = new CreditoConsignado(this);
                    break;
                case Credito.TTipoCredito.CreditoPessoaJuridica:
                    credito = new CreditoPessoaJuridica(this);
                    break;
                case Credito.TTipoCredito.CreditoPessoaFisica:
                    credito = new CreditoPessoaFisica(this);
                    break;
                case Credito.TTipoCredito.CreditoImobiliario:
                    credito = new CreditoImobiliario(this);
                    break;
                default:
                    break;
            }

            return credito;
        }
    }
}