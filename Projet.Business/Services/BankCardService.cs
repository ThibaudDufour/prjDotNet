using AutoMapper;
using Projet.Datas.Entities;
using Projet.Datas.Repositories;

namespace Projet.Business.Services
{
    public class BankCardService
    {
        private readonly BankCardRepository _bankCardRepository;
        private readonly IMapper _mapper;

		public BankCardService()
		{
			_bankCardRepository = new BankCardRepository();
			_mapper = MappingConfig.Mapper;
		}

		public async Task<List<string>> GetAllCardsNumber()
		{
			var cards = await _bankCardRepository.GetAll();
			var cardsNumbers = cards.Select(cards => cards.CardNumber).ToList<string>();
			return cardsNumbers;
		}

		public async Task<List<BankCardDto>> GetCardsByAccount(string accountNumber)
		{
			var cards = await _bankCardRepository.GetByAccountId(accountNumber);
			return cards.Select(c => _mapper.Map<BankCardDto>(c)).ToList();
		}

		public async Task<BankCardDto?> GetCardByCardNumber(string cardNumber)
		{
			var card = await _bankCardRepository.GetByCardNumber(cardNumber);
			return _mapper.Map<BankCardDto?>(card);
		}

		public async Task<int> AddCard(BankCardDto card)
		{
			var entity = _mapper.Map<BankCard>(card);
			return await _bankCardRepository.Add(entity);
		}

		public async Task<int> DeleteCard(string cardNumber)
		{
			var card = await _bankCardRepository.GetByCardNumber(cardNumber);
			if (card == null)
			{
				return 0;
			}
			return await _bankCardRepository.Delete(card);
		}
	}
}
