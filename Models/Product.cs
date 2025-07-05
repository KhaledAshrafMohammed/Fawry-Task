using e_commerce_system_task.Interfaces;

namespace e_commerce_system_task.Models
{
    public class Product : IShippable
    {
        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; private set; }
        public bool RequiresShipping { get; }

        private readonly DateTime? _expiryDate;
        private readonly double _weightKg; 

        public Product(string name,
                       double price,
                       int quantity,
                       bool requiresShipping,
                       double weightKg,
                       DateTime? expiryDate = null)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            RequiresShipping = requiresShipping;
            _weightKg = requiresShipping ? weightKg : 0;
            _expiryDate = expiryDate;
        }

        public bool IsExpired()
        {
            if (!_expiryDate.HasValue)
            {
                return false;
            }
            return DateTime.Now.Date > _expiryDate.Value.Date;
        }
        public bool IsInStock(int requestedQty)
        {
            return requestedQty <= Quantity;
        }

        public void ReduceStock(int qty)
        {
            if (qty > Quantity)
                throw new InvalidOperationException($"Not enough stock for {Name}.");
            Quantity -= qty;
        }

        public string GetName()
        {
            return Name;
        }
        public double GetWeight()
        {
            return _weightKg;
        }
    }
}
