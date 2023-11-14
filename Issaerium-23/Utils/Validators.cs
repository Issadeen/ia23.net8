using System.Text.RegularExpressions;

namespace Issaerium23.Utils
{
    public static class Validators
    {
        private static Regex emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
        private static Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
        private static Regex workIdRegex = new Regex(@"^_IA23_\d{3}$");

        public static bool IsValidEmail(string email)
        {
            return emailRegex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            return passwordRegex.IsMatch(password);
        }

        public static bool IsValidWorkId(string workId)
        {
            return workIdRegex.IsMatch(workId);
        }
    }
}