using AutoMapper;
using Projet.Datas.Entities;
using Projet.Datas.Entities.Interfaces;
using Projet.Datas.Repositories;

namespace Projet.Business.Services
{
	public class TransactionService
	{
		private readonly TransactionRepository _transactionRepository;
		private readonly IMapper _mapper;

		public TransactionService()
		{
			_transactionRepository = new TransactionRepository();
			_mapper = MappingConfig.Mapper;
		}

		public async Task<int> AddTransaction(TransactionDto transDto)
        {
            Transaction trans = _mapper.Map<Transaction>(transDto);
            return await _transactionRepository.Add(trans);
        }

		/// <summary>
		/// Récupère les transactions d'un compte pour une période donnée
		/// </summary>
		/// <param name="accountNumber">Numéro du compte</param>
		/// <param name="startDate">Date de début</param>
		/// <param name="endDate">Date de fin</param>
		/// <returns>Retourne une liste de transaction, liste vide si aucune transaction n'a été trouvée</returns>
		public async Task<List<TransactionDto>> GetTransactionsByAccountAndPeriod(string accountNumber, DateTime startDate, DateTime endDate)
		{
			// Récupère les transactions du dépôt de données
			var transactions = await _transactionRepository.GetTransactionsByAccountAndPeriod(accountNumber, startDate, endDate);

			// Transforme les transactions en DTO et masque les numéros de carte
			return transactions
				.Select(t => new TransactionDto
				{
					Id = t.Id,
					CardNumber = $"**** **** **** {t.CardNumber[^4..]}",
					Amount = t.Amount,
					TransactionType = t.TransactionType,
					TransactionDate = t.TransactionDate,
					Currency = t.Currency
				})
				.ToList<TransactionDto>();
		}

		public async Task<List<TransactionDto>> GetTransactionsHistoric(string accountNumber)
        {
            // Récupère les transactions du dépôt de données
            var transactions = await _transactionRepository.GetTransactionsHistoric(accountNumber);
            // Transforme les transactions en DTO et masque les numéros de carte
            return transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    CardNumber = $"**** **** **** {t.CardNumber[^4..]}",
                    Amount = t.Amount,
                    TransactionType = t.TransactionType,
                    TransactionDate = t.TransactionDate,
                    Currency = t.Currency
                })
                .ToList<TransactionDto>();
        }

		public async Task<List<TransactionDto>> GetTransactionHistoricByType(string accountNumber, EnumTransactionType transactionType)
		{
            // Récupère les transactions du dépôt de données
            var transactions = await _transactionRepository.GetTransactionsHistoricByType(accountNumber, transactionType);
            // Transforme les transactions en DTO et masque les numéros de carte
            return transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    CardNumber = $"**** **** **** {t.CardNumber[^4..]}",
                    Amount = t.Amount,
                    TransactionType = t.TransactionType,
                    TransactionDate = t.TransactionDate,
                    Currency = t.Currency
                })
                .ToList<TransactionDto>();
        }
    }
}
