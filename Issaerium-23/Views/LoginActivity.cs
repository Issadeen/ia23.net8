using Android.App;
using Android.OS;
using Android.Widget;
using Firebase.Auth;
using System.Text.RegularExpressions;

namespace Issaerium23.Views
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private EditText emailInput;
        private EditText passwordInput;
        private Button loginButton;
        private FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            auth = FirebaseAuth.Instance;

            emailInput = FindViewById<EditText>(Resource.Id.emailInput);
            passwordInput = FindViewById<EditText>(Resource.Id.passwordInput);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            string email = emailInput.Text;
            string password = passwordInput.Text;

            if (IsValidEmail(email) && IsValidPassword(password))
            {
                auth.SignInWithEmailAndPassword(email, password)
                    .AddOnSuccessListener(this, task =>
                    {
                        StartActivity(typeof(HomeActivity));
                    })
                    .AddOnFailureListener(this, e =>
                    {
                        Toast.MakeText(this, "Login failed", ToastLength.Short).Show();
                    });
            }
            else
            {
                Toast.MakeText(this, "Invalid email or password", ToastLength.Short).Show();
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            // Add your password validation logic here
            return password.Length >= 6;
        }
    }
}