using System.Collections.Generic;
using e_commerce_system_task.Interfaces;

namespace e_commerce_system_task.Services
{
    public static class ShippingService
    {
        public static void Ship(List<IShippable> items)
        {
            if (items == null || items.Count == 0) return;

            Console.WriteLine("\n** Shipment notice **");

            var summary = new Dictionary<string, (int Count, double WeightPerItem)>();
            double totalWeight = 0;
            foreach (IShippable item in items)
            {
                string name = item.GetName();
                double weight = item.GetWeight();
                totalWeight += weight;

                if (summary.ContainsKey(name))
                {
                    summary[name] = (summary[name].Count + 1, weight);
                }
                else
                {
                    summary[name] = (1, weight);
                }
            }

            foreach (var kvp in summary)
            {
                Console.WriteLine($"{kvp.Value.Count}x {kvp.Key} {kvp.Value.WeightPerItem * 1000:F0}g");
            }
            Console.WriteLine($"Total package weight {totalWeight:F1}kg\n");
        }
    }
}
