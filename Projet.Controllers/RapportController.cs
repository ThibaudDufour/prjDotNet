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

		public async Task GenerateExport()
		{
			string accountNumber = _rapportView.GetAccountNumber();
			DateTime startDate = _rapportView.GetStartDate();
			DateTime endDate = _rapportView.GetEndDate();

			var transactionDtos = await _transactionService.GetTransactionsByAccountAndPeriod(accountNumber, startDate, endDate);
			if (!transactionDtos.Any())
			{
				_rapportView.DisplayWarningMessage("Aucune transaction trouvée pour cette période.");
				return;
			}

			bool resultXML = GenerateXmlExport(accountNumber, startDate, endDate, transactionDtos, out string xmlPath);
			if (!resultXML)
			{
				_rapportView.DisplayExportError("Erreur lors de la génération du fichier XML.");
				return;
			}
			_rapportView.DisplayExportPath(xmlPath);
			_rapportView.DisplaySuccessMessage();
		}

		private bool GenerateXmlExport(string accountNumber, DateTime startDate, DateTime endDate, List<TransactionDto> transactionDtos, out string path)
		{
			path = string.Format(_xmlExportPath, accountNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));

			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));

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
				_rapportView.DisplayExportError(ex.Message);

				return false;
			}
		}

	}
}
