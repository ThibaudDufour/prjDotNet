using System.ComponentModel.DataAnnotations;

namespace Projet.Business
{
	public class LoginUserDto
	{
		[Required]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Le nom ne peut pas dépasser 50 caracteres")]
		public string Name { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "L'adresse mail n'est pas valide")]
		public string Email { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		public void SetPassword(string password)
		{
			PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
		}

		public bool VerifyPassword(string password)
		{
			return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
		}
	}
}
