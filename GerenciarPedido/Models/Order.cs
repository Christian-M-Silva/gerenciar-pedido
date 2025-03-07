
namespace GerenciarPedido.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid ClientID { get; set; }
        public required double Value { get; set; }
        public required DateTime Date { get; set; }
    }
}
