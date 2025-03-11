using AutoMapper;
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

		public async Task<List<TransactionDto>> GetTransactionsByAccountAndPeriod(string accountNumber, DateTime startDate, DateTime endDate)
		{
			var transactions = await _transactionRepository.GetTransactionsByAccountAndPeriod(accountNumber, startDate, endDate);
			return transactions
				.Select(t => new TransactionDto {
					Id = t.Id,
					CardNumber = MaskCardNumber(t.CardNumber),
					Amount = t.Amount,
					TransactionType = t.TransactionType,
					TransactionDate = t.TransactionDate,
					Currency = t.Currency
				})
				.ToList<TransactionDto>();
		}

		private string MaskCardNumber(string cardNumber)
		{
			return cardNumber.Substring(0, 4) + "********" + cardNumber.Substring(12, 4);
		}
	}
}
