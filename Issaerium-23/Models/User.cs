using System.ComponentModel.DataAnnotations;

namespace Issaerium23.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^_IA23_\d{3}$", ErrorMessage = "Work ID must start with _IA23_ followed by 3 digits.")]
        public string WorkId { get; set; }

        public string FirstName
        {
            get
            {
                var index = Email.IndexOf('@');
                return index > 0 ? Email.Substring(0, index) : Email;
            }
        }
    }
}