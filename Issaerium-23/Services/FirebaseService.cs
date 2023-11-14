using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Issaerium23.Services
{
    public class FirebaseService
    {
        FirebaseClient client;

        public FirebaseService()
        {
            client = new FirebaseClient("YourFirebaseURL");
        }

        public async Task<List<Truck>> GetTruckData()
        {
            return (await client
              .Child("Trucks")
              .OnceAsync<Truck>()).Select(item => new Truck
              {
                  TruckNo = item.Object.TruckNo,
                  Driver = item.Object.Driver,
                  Transporter = item.Object.Transporter,
                  AgoComps = item.Object.AgoComps,
                  PmsComps = item.Object.PmsComps
              }).ToList();
        }

        // Add other methods for interacting with Firebase here
    }
}