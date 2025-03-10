using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;

namespace Projet.Datas.Repositories
{
    public class AccountRepository
    {
        public AccountRepository()
        {
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            using var context = new MyDbContext();
			context.Database.EnsureCreated();
		}

        public async Task<List<Account>> GetAll()
		{
			using var context = new MyDbContext();
			return await context.Accounts
                .Include("Customers")
                .Include("Transactions")
				.ToListAsync();
		}

		public async Task<List<Account>> GetByCustomerId(int customerId)
		{
			using var context = new MyDbContext();
			return await context.Accounts
				.Include("Customers")
				.Include("Transactions")
				.Where(a => a.Owners.Any(o => o.Id == customerId))
				.ToListAsync();
		}

		public async Task<Account?> GetByAccountNumber(string accountNumber)
		{
			using var context = new MyDbContext();
			return await context.Accounts
				.Include("Customers")
				.Include("Transactions")
				.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
		}

		public Task<int> Add(Account entity)
		{
			using var context = new MyDbContext();
			context.Accounts.Add(entity);
			return context.SaveChangesAsync();
		}

		public Task<int> Update(Account entity)
		{
			using var context = new MyDbContext();
			context.Accounts.Update(entity);
			return context.SaveChangesAsync();
		}

		public Task<int> Delete(string accountNumber)
		{
			using var context = new MyDbContext();
			var account = context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
			if (account != null)
			{
				context.Accounts.Remove(account);
			}
			return context.SaveChangesAsync();
		}
	}
}
