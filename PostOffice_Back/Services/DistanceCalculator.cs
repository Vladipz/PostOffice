using System;

namespace lab3.Services
{
    public class DistanceCalculator
    {
        public int CalculateDistance()
        {
            Random random = new Random();

            // Define the range for the random integer
            int minValue = 10;
            int maxValue = 1000;

            // Generate a random integer within the specified range
            int distance = random.Next(minValue, maxValue + 1);
            return distance;

        }
    }
}
