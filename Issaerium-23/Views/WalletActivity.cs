using Android.App;
using Android.OS;
using Android.Widget;
using Issaerium_23.Models;
using Issaerium_23.Services;
using System;
using System.Linq;

namespace Issaerium_23.Views
{
    [Activity(Label = "Wallet")]
    public class WalletActivity : Activity
    {
        private FirebaseService _firebaseService;
        private EditText _workIdInput;
        private ListView _trucksListView;
        private Button _deleteButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_wallet);

            _firebaseService = new FirebaseService();

            _workIdInput = FindViewById<EditText>(Resource.Id.workIdInput);
            _trucksListView = FindViewById<ListView>(Resource.Id.trucksListView);
            _deleteButton = FindViewById<Button>(Resource.Id.deleteButton);

            _deleteButton.Click += DeleteButton_Click;

            LoadTrucks();
        }

        private async void LoadTrucks()
        {
            var trucks = await _firebaseService.GetTrucks();
            _trucksListView.Adapter = new ArrayAdapter<Truck>(this, Android.Resource.Layout.SimpleListItem1, trucks.ToList());
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            var workId = _workIdInput.Text;
            if (string.IsNullOrEmpty(workId))
            {
                Toast.MakeText(this, "Work ID is required", ToastLength.Short).Show();
                return;
            }

            var selectedTruck = _trucksListView.SelectedItem as Truck;
            if (selectedTruck == null)
            {
                Toast.MakeText(this, "No truck selected", ToastLength.Short).Show();
                return;
            }

            await _firebaseService.DeleteTruck(selectedTruck.Id, workId);
            LoadTrucks();
        }
    }
}