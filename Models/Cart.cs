using System.Collections.Generic;
using e_commerce_system_task.Interfaces;

namespace e_commerce_system_task.Models
{
    public class Cart
    {
        private readonly List<CartItem> _items = new();
        public IReadOnlyList<CartItem> Items
        {
            get { return _items; }
        }

        public void Add(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (!product.IsInStock(quantity))
                throw new InvalidOperationException($"Requested quantity exceeds available stock for {product.Name}.");

            if (product.IsExpired())
                throw new InvalidOperationException($"Cannot add expired product {product.Name} to cart.");

            _items.Add(new CartItem(product, quantity));
            product.ReduceStock(quantity);
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }
        public double Subtotal
        {
            get
            {
                double total = 0;
                foreach (CartItem item in _items)
                {
                    total += item.LineTotal;
                }
                return total;
            }
        }

        public List<IShippable> GetShippableItems()
        {
            var list = new List<IShippable>();
            foreach (var item in _items)
            {
                if (item.Product.RequiresShipping)
                {
                    for (int i = 0; i < item.Quantity; i++)
                        list.Add(item.Product);
                }
            }
            return list;
        }
    }
}
