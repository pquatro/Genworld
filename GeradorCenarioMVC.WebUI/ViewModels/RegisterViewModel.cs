using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeradorCenarioMVC.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords don´t match")]
        public string ConfirmPassword { get; set; }

		[Required]
        [Display(Name = "Primeiro Nome")]
		public string FistName { get; set; }

		[Required]
		[Display(Name = "Último Nome")]
		public string LastName { get; set; }

		[DisplayName("RecebeEmail")]
		[DefaultValue(true)]
		public bool? recebeEmail { get; set; }

		[DisplayName("Foto")]
		public byte[]? picture { get; set; }


	}
}
