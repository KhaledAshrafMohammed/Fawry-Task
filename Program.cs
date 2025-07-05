using e_commerce_system_task.Models;
using e_commerce_system_task.Services;

namespace e_commerce_system_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sample products for test
            var cheese = new Product("Cheese", 100, 10, true, 0.2, DateTime.Now.AddDays(5));
            var tv = new Product("TV", 500, 3, true, 8.0);
            var scratchCard = new Product("Scratch Card", 50, 100, false, 0);

            var customer = new Customer("Ali", 1000);

            var cart = new Cart();
            cart.Add(cheese, 2);
            cart.Add(tv, 1);
            cart.Add(scratchCard, 1);

            try
            {
                CheckoutService.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
