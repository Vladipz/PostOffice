using System;

namespace lab3.Services
{
    public class DateCalculator
    {
        public DateTime CalculateDeliveryDate(DateTime dateOfShipment, int distanceInKm, int deliverySpeedKmPerDay)
        {
            // Розрахунок кількості днів для доставки
            int daysRequired = distanceInKm / deliverySpeedKmPerDay;

            // Додавання цього часу до дати відправлення
            DateTime deliveryDate = dateOfShipment.AddDays(daysRequired);

            return deliveryDate;
        }
    }
}
