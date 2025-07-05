namespace e_commerce_system_task.Models
{
    public class Customer
    {
        public string Name { get; }
        public double Balance { get; private set; }

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public void Pay(double amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance.");
            Balance -= amount;
        }
    }
}
