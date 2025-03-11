using AutoMapper;
using Projet.Datas.Entities.Interfaces;
using Projet.Datas.Repositories;
using System.Text.Json;

namespace Projet.Business.Services
{
	public class TransactionExportService
	{
		private readonly TransactionRepository _transactionRepository;
		private readonly IMapper _mapper;
		private readonly string _exportPath = @"C:\Exports\TransactionsVerified.json";

		public TransactionExportService()
		{
			_transactionRepository = new TransactionRepository();
			_mapper = MappingConfig.Mapper;
		}

		/// <summary>
		/// Exporte les transactions vérifiées dans un fichier JSON
		/// </summary>
		/// <returns></returns>
		public async Task<bool> ExportVerifiedTransaction()
		{
			// Récupère les taux de change
			var exchangesRates = await new ExchangeRateService().GetExchangeRate();
			// Récupère toutes les transactions
			var transactions = await _transactionRepository.GetAll();

			// Si aucune transaction n'est trouvée, sortir de la méthode
			if (!transactions.Any())
				return false;

			// Mapper les transactions en DTO
			List<TransactionDto> transactionsDto = _mapper.Map<List<TransactionDto>>(transactions);

			// Préparer les transactions à exporter avec les taux de change et les montants convertis
			var transactionsToExport = transactionsDto.Select(transaction => new
			{
				transaction.Id,
				transaction.CardNumber,
				transaction.Amount,
				TransactionType = transaction.TransactionType.ToString(),
				TransactionDate = transaction.TransactionDate.ToString("g"),
				transaction.Currency,

				ExchangeRate = transaction.Currency != EnumCurrency.EUR.ToString() ?
								 exchangesRates.GetValueOrDefault(transaction.Currency, 1) :
								 1,

				ConvertedAmount = transaction.Currency != EnumCurrency.EUR.ToString() ?
								 transaction.Amount * exchangesRates.GetValueOrDefault(transaction.Currency, 1) :
								 transaction.Amount
			}).ToList();

			// Sérialiser les transactions en JSON
			string json = JsonSerializer.Serialize(transactionsToExport, new JsonSerializerOptions { WriteIndented = true });

			// Vérifier si le répertoire d'export existe, sinon le créer
			string directoryPath = Path.GetDirectoryName(_exportPath);
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			// Écrire le fichier JSON dans le chemin d'export
			await File.WriteAllTextAsync(_exportPath, json);

			return true;
		}
	}
}

