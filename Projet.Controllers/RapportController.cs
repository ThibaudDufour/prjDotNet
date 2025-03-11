using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
		private readonly string _pdfExportPath = @"C:\Exports\BankStatements\PDF\{0}_{1}.pdf";
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

			bool resultPDF = GeneratePdfExport(accountNumber, transactionDtos, out string pdfPath);
			if (!resultPDF)
			{
				_rapportView.DisplayExportError("Erreur lors de la génération du fichier PDF.");
				return;
			}
			_rapportView.DisplayExportPath(pdfPath);

			bool resultXML = GenerateXmlExport(accountNumber, transactionDtos, out string xmlPath);
			if (!resultXML)
			{
				_rapportView.DisplayExportError("Erreur lors de la génération du fichier XML.");
				return;
			}
			_rapportView.DisplayExportPath(xmlPath);
			_rapportView.DisplaySuccessMessage();
		}

		private bool GeneratePdfExport(string accountNumber, List<TransactionDto> transactionDtos, out string path)
		{
			path = string.Format(_pdfExportPath, accountNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));

			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));

				using (var writer = new PdfWriter(path))
				using (var pdf = new PdfDocument(writer))
				using (var document = new iText.Layout.Document(pdf))
				{
					document.Add(new Paragraph($"Relevé bancaire - Compte : {transactionDtos.First().BankAccountId}"));
					document.Add(new Paragraph($"Période : {transactionDtos.First().TransactionDate} - {transactionDtos.Last().TransactionDate}"));

					iText.Layout.Element.Table table = new iText.Layout.Element.Table(5);
					table.AddHeaderCell("Date");
					table.AddHeaderCell("Type");
					table.AddHeaderCell("Montant");
					table.AddHeaderCell("Devise");
					table.AddHeaderCell("Numéro de Carte");

					foreach (var transaction in transactionDtos)
					{
						table.AddCell(transaction.TransactionDate.ToString("g"));
						table.AddCell(transaction.TransactionType.ToString());
						table.AddCell(transaction.Amount.ToString("F2"));
						table.AddCell(transaction.Currency.ToString());
						table.AddCell(transaction.CardNumber);
					}

					document.Add(table);
				}

				return true;
			}
			catch (Exception ex)
			{
				_rapportView.DisplayExportError("Erreur lors de la génération du fichier PDF.");
				_rapportView.DisplayExportError(ex.Message);

				return false;
			}
		}

		private bool GenerateXmlExport(string accountNumber, List<TransactionDto> transactionDtos, out string path)
		{
			path = string.Format(_xmlExportPath, accountNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));

			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));

				XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TransactionDto>));
				using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					xmlSerializer.Serialize(fileStream, transactionDtos);
					fileStream.Close();
				}

				return true;
			}
			catch (Exception ex)
			{
				_rapportView.DisplayExportError("Erreur lors de la génération du fichier XML.");
				_rapportView.DisplayExportError(ex.Message);

				return false;
			}
		}

	}
}
