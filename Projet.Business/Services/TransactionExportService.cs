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
		private static readonly string _baseCardNumber = "497401850223";

		public TransactionExportService()
		{
			_transactionRepository = new TransactionRepository();
			_mapper = MappingConfig.Mapper;
		}

		public async Task ExportVerifiedTransaction()
		{
			var exchangesRates = await new ExchangeRateService().GetExchangeRate();
			var transactions = await _transactionRepository.GetAll();

			if (!transactions.Any())
				return;

			List<TransactionDto> transactionsDto = _mapper.Map<List<TransactionDto>>(transactions);

			var transactionsToExport = transactionsDto.Select(transaction => new
			{
				transaction.Id,
				transaction.CardNumber,
				transaction.Amount,
				transaction.TransactionType,
				TransactionDate = transaction.TransactionDate.ToString("g"),
				transaction.Currency,
				transaction.BankAccountId,

				ExchangeRate = transaction.Currency != EnumCurrency.EUR.ToString() ?
							   exchangesRates.GetValueOrDefault(transaction.Currency, 1) :
							   1,

				ConvertedAmount = transaction.Currency != EnumCurrency.EUR.ToString() ?
								  transaction.Amount * exchangesRates.GetValueOrDefault(transaction.Currency, 1) :
								  transaction.Amount
			}).ToList();

			string json = JsonSerializer.Serialize(transactionsDto, new JsonSerializerOptions { WriteIndented = true });
			await File.WriteAllTextAsync(_exportPath, json);
		}
	}
}

