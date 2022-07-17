namespace APICredito.Classes
{
    public abstract class ICredito
    {
        public SolicitacaoCredito? solicitacao;
        //
        public string? status { get; set; }
        public double valorTotalComJuros { get; set; }
        public double valorJuros { get; set; }
        public string? mensagem { get; set; }

        public abstract void validarValorMinimo(double valorCredito);
        public abstract void validarQtdeMinimaParcelas(int qtdeParcelas);
        public abstract void validarValorMaximoCredito(double valorCredito);
    }
}