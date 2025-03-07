
namespace GerenciarPedido.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public required string Value { get; set; }
        public required DateTime Date { get; set; }
    }
}
