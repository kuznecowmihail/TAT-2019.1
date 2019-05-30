using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new delivery.
    /// </summary>
    public class DeliveryCreater : BaseInformationCreater
    {
        /// <summary>
        /// Method creates object of delivery, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Delivery CreateDelivery(List<Delivery> deliveries)
        {
            Delivery delivery = new Delivery();

            Console.WriteLine("Enter delivery ID:");
            delivery.ID = GetIntNewID(deliveries.Select(t => t.ID).ToList());

            Console.WriteLine("Enter house Description:");
            delivery.Description = GetStringValue();

            Console.WriteLine("Enter delivery date:");
            delivery.DeliveryDate = GetStringValue();

            return delivery;
        }
    }
}
