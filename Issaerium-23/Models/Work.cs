using System;

namespace Issaerium23.Models
{
    public class Work
    {
        public string Id { get; set; }
        public string TruckNo { get; set; }
        public string LoCompany { get; set; }
        public string Destination { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public bool IsLoaded { get; set; }

        public Work()
        {
            // Default constructor required for Firebase
        }

        public Work(string id, string truckNo, string loCompany, string destination, string product, int quantity, bool isLoaded)
        {
            Id = id;
            TruckNo = truckNo;
            LoCompany = loCompany;
            Destination = destination;
            Product = product;
            Quantity = quantity;
            IsLoaded = isLoaded;
        }
    }
}