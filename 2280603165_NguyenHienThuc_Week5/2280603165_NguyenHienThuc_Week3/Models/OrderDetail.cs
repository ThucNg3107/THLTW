namespace _2280603165_NguyenHienThuc_Week3.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Orders Order { get; set; }
        public Product Product { get; set; }
    }
}
