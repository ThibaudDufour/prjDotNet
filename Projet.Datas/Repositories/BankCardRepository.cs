using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;

namespace Projet.Datas.Repositories
{
    public class BankCardRepository
    {
        public BankCardRepository() 
        {
			InitializeDataBase();
		}

		private void InitializeDataBase()
		{
			using var context = new MyDbContext();
			context.Database.EnsureCreated();
		}

		public async Task<List<BankCard>> GetAll()
		{
			using var context = new MyDbContext();
			return await context.BankCards
				.Include("Account")
				.ToListAsync();
		}

		public async Task<List<BankCard>> GetByAccountId(string accountNumber)
		{
			using var context = new MyDbContext();
			return await context.BankCards
				.Include("Account")
				.Where(b => b.AccountNumber == accountNumber.ToUpper())
				.ToListAsync();
		}

		public async Task<BankCard?> GetByCardNumber(string cardNumber)
		{
			using var context = new MyDbContext();
			return await context.BankCards
				.Include("Account")
				.FirstOrDefaultAsync(b => b.CardNumber == cardNumber);
		}

		public Task<int> Add(BankCard entity)
		{
			using var context = new MyDbContext();
			context.BankCards.Add(entity);
			return context.SaveChangesAsync();
		}

		public Task<int> Delete(BankCard entity)
		{
			using var context = new MyDbContext();
			context.BankCards.Remove(entity);
			return context.SaveChangesAsync();
		}
	}
}
