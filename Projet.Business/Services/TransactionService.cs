using AutoMapper;
using Microsoft.Identity.Client;
using Projet.Datas.Entities;
using Projet.Datas.Entities.Interfaces;
using Projet.Datas.Repositories;

namespace Projet.Business.Services
{
	public class TransactionService
	{
		private readonly TransactionRepository _transactionRepository;
		private readonly BankCardRepository _bankCardRepository;
		private readonly AccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public TransactionService()
		{
			_transactionRepository = new TransactionRepository();
			_bankCardRepository = new BankCardRepository();
			_accountRepository = new AccountRepository();
			_mapper = MappingConfig.Mapper;
		}

		/// <summary>
		/// Ajoute une transaction et met à jour le solde du compte associé
		/// </summary>
		/// <param name="transDto"></param>
		/// <returns></returns>
		public async Task<int> AddTransaction(TransactionDto transDto)
        {
            Transaction trans = _mapper.Map<Transaction>(transDto);
            var result = await _transactionRepository.Add(trans);

			// Si la transaction a été ajoutée, modifier le solde du compte
			if (result > 0)
			{
				// Récupère la carte bancaire associée à la transaction
				BankCard? card = await _bankCardRepository.GetByCardNumber(transDto.CardNumber);
				if (card != null)
				{
					// Récupère le compte associé à la carte bancaire
					Account? account = await _accountRepository.GetByAccountNumber(card.AccountNumber);

					// Si le compte existe et que la transaction est un dépôt d'argent
					if (account != null && transDto.TransactionType == EnumTransactionType.CashDeposit)
					{
						// Dépose le montant sur le compte
						account.Deposit(transDto.Amount);
						await _accountRepository.Update(account);
					}
					else if (account != null)
					{
						// Retire le montant du compte
						if (account.Withdraw(transDto.Amount))
						{
							await _accountRepository.Update(account);
						}
					}
				}
			}

			return result;
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
