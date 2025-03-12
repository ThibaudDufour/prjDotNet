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
                .Include(a => a.Owners) //test
                .Include("Transactions")
				.ToListAsync();
		}

		public async Task<List<Account>> GetByCustomerId(int customerId)
		{
			using var context = new MyDbContext();
			return await context.Accounts
                .Include(a => a.Owners)
                .Include("Transactions")
				.Where(a => a.Owners.Any(o => o.Id == customerId))
				.ToListAsync();
		}

		public async Task<Account?> GetByAccountNumber(string accountNumber)
		{
			using var context = new MyDbContext();
			return await context.Accounts
                .Include(a => a.Owners)
                .Include("Transactions")
				.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
		}

		public async Task<int> Add(Account entity)
		{
			using var context = new MyDbContext();
			context.Accounts.Add(entity);
			return await context.SaveChangesAsync();
		}

		public async Task<int> Update(Account entity)
		{
			using var context = new MyDbContext();
			context.Attach(entity).State = EntityState.Modified;
			return await context.SaveChangesAsync();
		}

		public async Task<int> Delete(string accountNumber)
		{
			using var context = new MyDbContext();
			var account = context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
			if (account != null)
			{
				context.Accounts.Remove(account);
			}
			return await context.SaveChangesAsync();
		}
	}
}
