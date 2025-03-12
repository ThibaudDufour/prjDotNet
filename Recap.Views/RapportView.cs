using System;
using System.Globalization;

namespace Recap.Views
{
	public class RapportView
	{
		/// <summary>
		/// Récupère le numéro de compte depuis la console
		/// </summary>
		/// <returns></returns>
		public string GetAccountNumber()
		{
			Console.WriteLine("Entrez le numéro de compte : ");
			return Console.ReadLine();
		}

		/// <summary>
		/// Récupère la date de début depuis la console
		/// </summary>
		/// <returns></returns>
		public DateTime GetStartDate()
		{
			DateTime startDate;
			while (true)
			{
				// Demande à l'utilisateur d'entrer la date de début
				Console.WriteLine("Entrez la date de début (format: jj/mm/aaaa) : ");
				// Tente de convertir l'entrée utilisateur en DateTime avec le format spécifié
				if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
				{
					// Si la conversion réussit, fixe l'heure à 00:00:00
					startDate = startDate.Date; // Set time to 00:00:00
					break;
				}
				// Si la conversion échoue, affiche un message d'erreur
				Console.WriteLine("Format de date invalide. Veuillez réessayer.");
			}
			return startDate;
		}

		/// <summary>
		/// Récupère la date de fin depuis la console
		/// </summary>
		/// <returns></returns>
		public DateTime GetEndDate()
		{
			DateTime endDate;
			while (true)
			{
				// Demande à l'utilisateur d'entrer la date de fin
				Console.WriteLine("Entrez la date de fin (format: jj/mm/aaaa) : ");
				// Tente de convertir l'entrée utilisateur en DateTime avec le format spécifié
				if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
				{
					// Si la conversion réussit, fixe l'heure à 23:59:59
					endDate = endDate.Date.Add(new TimeSpan(23, 59, 59)); // Set time to 23:59:59
					break;
				}
				// Si la conversion échoue, affiche un message d'erreur
				Console.WriteLine("Format de date invalide. Veuillez réessayer.");
			}
			return endDate;
		}

		/// <summary>
		/// Affiche le chemin du fichier exporté
		/// </summary>
		/// <param name="path"></param>
		public void DisplayExportPath(string path)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"- Export généré à l'emplacement suivant : {path}");
			Console.ResetColor();
		}

		/// <summary>
		/// Affiche un message de succès
		/// </summary>
		public void DisplaySuccessMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Export généré avec succès !");
			Console.ResetColor();
		}

		/// <summary>
		/// Affiche un message d'avertissement
		/// </summary>
		/// <param name="message"></param>
		public void DisplayWarningMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		/// <summary>
		/// Affiche un message d'erreur
		/// </summary>
		/// <param name="message"></param>
		public void DisplayExportError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
