using Projet.Business;
using System.ComponentModel.DataAnnotations;

namespace Recap.Views
{
	public class LoginView
	{
		public void ShowMenu()
		{
			Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
			Console.WriteLine("Bienvenue sur l'application de gestion de comptes bancaires !");
			Console.WriteLine("1. Se connecter");
			Console.WriteLine("2. S'inscrire");
			Console.WriteLine("");
			Console.WriteLine("0. Quitter");
			Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
		}

		public string GetEmail()
		{
			string? email;
			do
			{
				Console.WriteLine("Entrez votre adresse email : ");
				email = Console.ReadLine();
			} while (string.IsNullOrWhiteSpace(email));

			return email;
		}

		public string GetPassword()
		{
			string password;
			do
			{
				Console.WriteLine("Entrez votre mot de passe : ");
				password = Console.ReadLine();
			} while (string.IsNullOrWhiteSpace(password));

			return password;
		}

		public string GetName()
		{
			string name;
			do
			{
				Console.WriteLine("Entrez votre nom : ");
				name = Console.ReadLine();
			} while (string.IsNullOrWhiteSpace(name));

			return name.ToUpper();
		}

		public void ShowSuccessMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Accès validé !");
			Console.ResetColor();
		}

		public void ShowWelcomeMessage(string name)
		{
			Console.WriteLine($"Bienvenue, {name} !");
		}

		public void ShowInvalidChoice()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Choix invalide !");
			Console.ResetColor();
		}

		public void ShowLoginError()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Identifiants incorrects !");
			Console.ResetColor();
		}

		public void ShowEmailAlreadyUsed()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Cet email est déjà utilisé !");
			Console.ResetColor();
		}

		public void ShowRegistrationSuccess()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Inscription réussie !");
			Console.ResetColor();
		}

		public void ShowRegistrationError()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Erreur lors de l'inscription !");
			Console.ResetColor();
		}

		public void ShowGoodbyeMessage()
		{
			Console.WriteLine("Au revoir !");
		}

		public bool Validate(string name, string email, string password)
		{
			LoginUserDto obj = new LoginUserDto
			{
				Name = name,
				Email = email,
				PasswordHash = password
			};

			var context = new ValidationContext(obj, null, null);
			var results = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(obj, context, results, true);

			if (!isValid)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				foreach (var validationResult in results)
				{
					Console.WriteLine($"\t- {validationResult.ErrorMessage}");
				}
				Console.ResetColor();
			}

			return isValid;
		}
	}
}
