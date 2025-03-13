using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;

namespace Projet.Datas.Repositories
{
	public class BusinessCustomerRepository : IRepository<BusinessCustomer>
	{
		public BusinessCustomerRepository()
		{
			InitializeDataBase();
		}

		private void InitializeDataBase()
		{
			using var context = new MyDbContext();
		}

		public async Task<List<BusinessCustomer>> GetAll()
		{
			using var context = new MyDbContext();
			return await context.BusinessCustomers
				.Include("Accounts")
				.ToListAsync();
		}

		public Task<BusinessCustomer?> GetById(int id)
		{
			using var context = new MyDbContext();
			return context.BusinessCustomers
				.Include("Accounts")
				.FirstOrDefaultAsync(bc => bc.Id == id);
		}

		public Task<BusinessCustomer?> GetBySiret(string siret)
		{
			using var context = new MyDbContext();
			return context.BusinessCustomers
				.Include("Accounts")
				.FirstOrDefaultAsync(bc => bc.Siret == siret);
		}

		public Task<int> Add(BusinessCustomer entity)
		{
			using var context = new MyDbContext();
			context.BusinessCustomers.Add(entity);
			return context.SaveChangesAsync();
		}

		public Task<int> Update(BusinessCustomer entity)
		{
			using var context = new MyDbContext();
			context.Attach(entity).State = EntityState.Modified;
			return context.SaveChangesAsync();
		}

		public Task<int> Delete(int id)
		{
			using var context = new MyDbContext();
			var entity = context.BusinessCustomers.Find(id);
			if (entity == null)
			{
				throw new InvalidOperationException("Business customer not found");
			}
			context.BusinessCustomers.Remove(entity);
			return context.SaveChangesAsync();
		}
	}
}
