using Heshlash.Api.Service.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Heshlash.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        [Required(ErrorMessage = "Username is required ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required ")]
        [EmailAttribute]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
