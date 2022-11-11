namespace Pagamento.Models
{
    public class Venda
    {
        public int Id {get; set;}
        public DateTime Data {get;set;}
        public EnumStatusVenda Status {get; set;}
        public Vendedor Vendedor {get;set;}

        public List<Item> Itens {get; set;}
    }

    // o vendedor que a efetivou, 
    //data, identificador do pedido e os itens que foram vendidos;
}