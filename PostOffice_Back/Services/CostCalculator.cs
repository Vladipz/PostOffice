
namespace lab3.Services
{
    public class CostCalculator
    {
        public double CalculateDeliveryCost(int distanceInKm, double weightInKg, double costPer10Km)
        {
            // Розрахунок кількості блоків по 10 км
            int blocksOf10Km = distanceInKm / 10;

            // Додавання додаткового блоку, якщо відстань не ділиться на 10 націло
            if (distanceInKm % 10 != 0)
            {
                blocksOf10Km++;
            }

            // Розрахунок вартості доставки
            double deliveryCost = blocksOf10Km * costPer10Km + weightInKg;

            return deliveryCost;
        }
    }
}
