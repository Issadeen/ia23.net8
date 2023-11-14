using Android.App;
using Android.OS;
using Android.Widget;
using Issaerium_23.Services;
using Issaerium_23.Models;
using Issaerium_23.Utils;

namespace Issaerium_23.Views
{
    [Activity(Label = "SignupActivity")]
    public class SignupActivity : Activity
    {
        private EditText emailInput;
        private EditText passwordInput;
        private EditText confirmPasswordInput;
        private EditText workIdInput;
        private Button signupButton;
        private FirebaseService firebaseService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signup);

            firebaseService = new FirebaseService();

            emailInput = FindViewById<EditText>(Resource.Id.emailInput);
            passwordInput = FindViewById<EditText>(Resource.Id.passwordInput);
            confirmPasswordInput = FindViewById<EditText>(Resource.Id.confirmPasswordInput);
            workIdInput = FindViewById<EditText>(Resource.Id.workIdInput);
            signupButton = FindViewById<Button>(Resource.Id.signupButton);

            signupButton.Click += SignupButton_Click;
        }

        private async void SignupButton_Click(object sender, System.EventArgs e)
        {
            string email = emailInput.Text;
            string password = passwordInput.Text;
            string confirmPassword = confirmPasswordInput.Text;
            string workId = workIdInput.Text;

            if (Validators.ValidateEmail(email) && Validators.ValidatePassword(password, confirmPassword) && Validators.ValidateWorkId(workId))
            {
                User newUser = new User { Email = email, Password = password, WorkId = workId };
                bool result = await firebaseService.CreateUser(newUser);

                if (result)
                {
                    Toast.MakeText(this, "Account created successfully", ToastLength.Short).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Error creating account", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Invalid input", ToastLength.Short).Show();
            }
        }
    }
}