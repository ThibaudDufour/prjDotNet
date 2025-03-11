using Projet.Business.Services;

internal class Program
{
	private static void Main(string[] args)
	{
		TransactionExportService _transactionExportService = new TransactionExportService();
		DisplayMenu(_transactionExportService);
	}

	private static void DisplayMenu(TransactionExportService transactionExportService)
	{
		while (true)
		{
			Console.WriteLine($"*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
			Console.WriteLine("1. Exporter les transactions vérifiées");
			Console.WriteLine("2. Quitter");
			Console.WriteLine($"*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
			Console.Write("Choisissez une option: ");
			string? choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					ExportVerifiedTransactions(transactionExportService).Wait();
					break;
				case "2":
					return;
				default:
					Console.WriteLine("Option invalide. Veuillez réessayer");
					break;
			}
		}
	}

	private async static Task ExportVerifiedTransactions(TransactionExportService transactionExportService)
	{
		try
		{
			Console.WriteLine("Exportation des transactions vérifiées...");
			await transactionExportService.ExportVerifiedTransaction();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Exportation terminée avec succès.");
			
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"ERREUR : {ex.Message}");
		}
		finally
		{
			Console.ResetColor();
			Console.WriteLine($"{Environment.NewLine}*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
		}
	}
}
