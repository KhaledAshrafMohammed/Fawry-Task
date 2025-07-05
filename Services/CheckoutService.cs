using System.Collections.Generic;
using e_commerce_system_task.Models;
using e_commerce_system_task.Interfaces;

namespace e_commerce_system_task.Services
{
    public static class CheckoutService
    {
        private const double FlatShippingFee = 30.0;

        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
                throw new InvalidOperationException("Cart is empty.");

            List<IShippable> shippableItems = cart.GetShippableItems();
            if (shippableItems.Count > 0)
            {
                ShippingService.Ship(shippableItems);
            }

            double subtotal = cart.Subtotal;
            double shipping = shippableItems.Count > 0 ? FlatShippingFee : 0.0;
            double total = subtotal + shipping;

            customer.Pay(total);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.LineTotal}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal}");
            Console.WriteLine($"Shipping {shipping}");
            Console.WriteLine($"Amount {total}");
            Console.WriteLine($"{customer.Name} current balance {customer.Balance}\n");
        }
    }
}
