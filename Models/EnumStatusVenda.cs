namespace Pagamento.Models
{
    public enum EnumStatusVenda
    {
        AguardandoPagamento = 1,
        PagamentoAprovado = 2,
        EnviadoParaTransport = 3,
        Entregue = 4,
        Cancelada = 5
    }
}