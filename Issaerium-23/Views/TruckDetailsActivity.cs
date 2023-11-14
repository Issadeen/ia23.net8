using Android.App;
using Android.OS;
using Android.Widget;
using Firebase.Database;
using System.Collections.Generic;

namespace Issaerium23.Views
{
    [Activity(Label = "Truck Details")]
    public class TruckDetailsActivity : Activity
    {
        private ListView truckListView;
        private List<Truck> truckList;
        private DatabaseReference truckDatabase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_truck_details);

            truckListView = FindViewById<ListView>(Resource.Id.truckListView);
            truckDatabase = FirebaseDatabase.Instance.GetReference("trucks");

            LoadDataFromFirebase();
        }

        private void LoadDataFromFirebase()
        {
            truckDatabase.AddValueEventListener(new ValueEventListener(truckList, truckListView));
        }
    }

    public class ValueEventListener : Java.Lang.Object, IValueEventListener
    {
        private List<Truck> truckList;
        private ListView truckListView;

        public ValueEventListener(List<Truck> truckList, ListView truckListView)
        {
            this.truckList = truckList;
            this.truckListView = truckListView;
        }

        public void OnCancelled(DatabaseError error)
        {
            // Handle error...
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            truckList.Clear();
            foreach (DataSnapshot truckSnapshot in snapshot.Children)
            {
                Truck truck = truckSnapshot.GetValue<Truck>();
                truckList.Add(truck);
            }
            var adapter = new TruckListAdapter(truckList);
            truckListView.Adapter = adapter;
        }
    }
}