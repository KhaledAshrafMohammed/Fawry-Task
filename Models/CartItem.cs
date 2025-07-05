namespace e_commerce_system_task.Models
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double LineTotal
        {
            get { return Product.Price * Quantity; }
        }
    }
}
