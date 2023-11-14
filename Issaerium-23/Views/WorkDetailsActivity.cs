using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using Issaerium23.Models;
using Issaerium23.Services;

namespace Issaerium23.Views
{
    [Activity(Label = "Work Details")]
    public class WorkDetailsActivity : Activity
    {
        private ListView workDetailsListView;
        private List<Work> workDetails;
        private FirebaseService firebaseService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_work_details);

            firebaseService = new FirebaseService();
            workDetailsListView = FindViewById<ListView>(Resource.Id.workDetailsListView);

            LoadWorkDetails();
        }

        private async void LoadWorkDetails()
        {
            workDetails = await firebaseService.GetWorkDetails();
            // Assuming you have a custom adapter to bind data to the ListView
            var adapter = new WorkDetailsAdapter(this, workDetails);
            workDetailsListView.Adapter = adapter;
        }

        // Add other methods to handle user interactions such as deleting a work detail, marking a work as loaded, etc.
    }
}