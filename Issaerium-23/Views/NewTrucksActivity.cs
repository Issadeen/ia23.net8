using Android.App;
using Android.OS;
using Android.Widget;
using Issaerium_23.Models;
using Issaerium_23.Services;
using Issaerium_23.Utils;

namespace Issaerium_23.Views
{
    [Activity(Label = "NewTrucksActivity")]
    public class NewTrucksActivity : Activity
    {
        private EditText truckNoEditText;
        private EditText ownerEditText;
        private EditText transporterEditText;
        private EditText driverEditText;
        private EditText agoEditText;
        private EditText pmsEditText;
        private CheckBox moreCompsCheckBox;
        private Button submitButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_new_trucks);

            truckNoEditText = FindViewById<EditText>(Resource.Id.truckNoEditText);
            ownerEditText = FindViewById<EditText>(Resource.Id.ownerEditText);
            transporterEditText = FindViewById<EditText>(Resource.Id.transporterEditText);
            driverEditText = FindViewById<EditText>(Resource.Id.driverEditText);
            agoEditText = FindViewById<EditText>(Resource.Id.agoEditText);
            pmsEditText = FindViewById<EditText>(Resource.Id.pmsEditText);
            moreCompsCheckBox = FindViewById<CheckBox>(Resource.Id.moreCompsCheckBox);
            submitButton = FindViewById<Button>(Resource.Id.submitButton);

            submitButton.Click += SubmitButton_Click;
        }

        private async void SubmitButton_Click(object sender, System.EventArgs e)
        {
            if (Validators.ValidateTruckForm(truckNoEditText.Text, ownerEditText.Text, transporterEditText.Text, driverEditText.Text, agoEditText.Text, pmsEditText.Text))
            {
                Truck newTruck = new Truck
                {
                    TruckNo = truckNoEditText.Text,
                    Owner = ownerEditText.Text,
                    Transporter = transporterEditText.Text,
                    Driver = driverEditText.Text,
                    Ago = agoEditText.Text,
                    Pms = pmsEditText.Text,
                    MoreComps = moreCompsCheckBox.Checked
                };

                FirebaseService firebaseService = new FirebaseService();
                await firebaseService.AddTruck(newTruck);

                Toast.MakeText(this, "New truck added successfully", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Please fill all the fields correctly", ToastLength.Short).Show();
            }
        }
    }
}