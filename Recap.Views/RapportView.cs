using System;
using System.Globalization;

namespace Recap.Views
{
	public class RapportView
	{
		public string GetAccountNumber()
		{
			Console.WriteLine("Entrez le numéro de compte : ");
			return Console.ReadLine();
		}

		public DateTime GetStartDate()
		{
			DateTime startDate;
			while (true)
			{
				Console.WriteLine("Entrez la date de début (format: jj/mm/aaaa) : ");
				if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
				{
					startDate = startDate.Date; // Set time to 00:00:00
					break;
				}
				Console.WriteLine("Format de date invalide. Veuillez réessayer.");
			}
			return startDate;
		}

		public DateTime GetEndDate()
		{
			DateTime endDate;
			while (true)
			{
				Console.WriteLine("Entrez la date de fin (format: jj/mm/aaaa) : ");
				if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
				{
					endDate = endDate.Date.Add(new TimeSpan(23, 59, 59)); // Set time to 23:59:59
					break;
				}
				Console.WriteLine("Format de date invalide. Veuillez réessayer.");
			}
			return endDate;
		}

		public void DisplayExportPath(string path)
		{
			Console.WriteLine($"- Export généré à l'emplacement suivant : {path}");
		}

		public void DisplaySuccessMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Export généré avec succès !");
			Console.ResetColor();
		}

		public void DisplayWarningMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		public void DisplayExportError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
