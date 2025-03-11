using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Projet.Business;
using Projet.Business.Services;
using Recap.Views;
using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace Projet.Controllers
{
	public class RapportController
	{
		private readonly TransactionService _transactionService;
		private readonly RapportView _rapportView;
		private readonly string _xmlExportPath = @"C:\Exports\BankStatements\XML\{0}_{1}.xml";

		public RapportController(RapportView rapportView)
		{
			_transactionService = new TransactionService();
			_rapportView = rapportView;
		}

		/// <summary>
		/// Génère un rapport XML des transactions d'un compte pour une période donnée
		/// </summary>
		/// <returns></returns>
		public async Task GenerateExport()
		{
			// Récupère le numéro de compte depuis la vue
			string accountNumber = _rapportView.GetAccountNumber();
			// Récupère la date de début depuis la vue
			DateTime startDate = _rapportView.GetStartDate();
			// Récupère la date de fin depuis la vue
			DateTime endDate = _rapportView.GetEndDate();

			// Vérifie que la date de fin n'est pas antérieure à la date de début
			if (endDate < startDate)
			{
				_rapportView.DisplayWarningMessage("La date de fin ne peut pas être antérieure à la date de début.");
				return;
			}

			// Récupère les transactions pour le compte et la période spécifiés
			var transactionDtos = await _transactionService.GetTransactionsByAccountAndPeriod(accountNumber, startDate, endDate);
			// Si aucune transaction n'est trouvée, affiche un message d'avertissement et retourne
			if (!transactionDtos.Any())
			{
				_rapportView.DisplayWarningMessage("Aucune transaction trouvée pour cette période.");
				return;
			}

			// Génère le fichier XML des transactions
			bool resultXML = GenerateXmlExport(accountNumber, startDate, endDate, transactionDtos, out string xmlPath);
			// Si la génération du fichier XML échoue, affiche un message d'erreur et retourne
			if (!resultXML)
			{
				_rapportView.DisplayExportError("Erreur lors de la génération du fichier XML.");
				return;
			}
			// Affiche le chemin du fichier exporté
			_rapportView.DisplayExportPath(xmlPath);
			// Affiche un message de succès
			_rapportView.DisplaySuccessMessage();
		}

		/// <summary>
		/// Génère un fichier XML contenant les transactions d'un compte pour une période donnée
		/// </summary>
		/// <param name="accountNumber">Numéro de compte</param>
		/// <param name="startDate">Date de début</param>
		/// <param name="endDate">Date de fin</param>
		/// <param name="transactionDtos">Liste des transactions</param>
		/// <param name="path">Chemin du fichier généré</param>
		/// <returns>True si la génération est réussie, sinon False</returns>
		private bool GenerateXmlExport(string accountNumber, DateTime startDate, DateTime endDate, List<TransactionDto> transactionDtos, out string path)
		{
			// Définit le chemin du fichier XML
			path = string.Format(_xmlExportPath, accountNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));

			try
			{
				// Crée le répertoire si nécessaire
				Directory.CreateDirectory(Path.GetDirectoryName(path));

				// Crée un objet BankStatementDto avec les informations nécessaires
				var bankStatement = new BankStatementDto
				{
					AccountNumber = accountNumber,
					Period = new TransactionPeriodDto
					{
						StartDate = startDate,
						EndDate = endDate
					},
					Transactions = transactionDtos
				};

				// Sérialise l'objet BankStatementDto en XML et l'écrit dans le fichier
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(BankStatementDto));
				using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					xmlSerializer.Serialize(fileStream, bankStatement);
					fileStream.Close();
				}

				return true;
			}
			catch (Exception ex)
			{
				// Affiche un message d'erreur en cas d'exception
				_rapportView.DisplayExportError(ex.Message);

				return false;
			}
		}

	}
}
