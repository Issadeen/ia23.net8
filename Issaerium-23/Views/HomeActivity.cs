using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace Issaerium23.Views
{
    [Activity(Label = "Home")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);

            // Get user's first name from email
            string email = Intent.GetStringExtra("Email");
            string firstName = email.Split('@')[0];

            // Set user's first name on the top bar
            TextView userNameTextView = FindViewById<TextView>(Resource.Id.userNameTextView);
            userNameTextView.Text = firstName;

            // Set page name on the center of the top bar
            TextView pageNameTextView = FindViewById<TextView>(Resource.Id.pageNameTextView);
            pageNameTextView.Text = "Home";

            // Set up hamburger menu
            ImageButton hamburgerButton = FindViewById<ImageButton>(Resource.Id.hamburgerButton);
            hamburgerButton.Click += HamburgerButton_Click;

            // Set up logout button
            Button logoutButton = FindViewById<Button>(Resource.Id.logoutButton);
            logoutButton.Click += LogoutButton_Click;
        }

        private void HamburgerButton_Click(object sender, EventArgs e)
        {
            // Code to reveal a toggle between dark and light theme
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // Code to log out the user
        }
    }
}