using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;

namespace Projet.Datas.Repositories
{
    public class PrivateCustomerRepository : IRepository<PrivateCustomer>
    {
        public PrivateCustomerRepository()
        {
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async Task<List<PrivateCustomer>> GetAll()
        {
            using var context = new MyDbContext();
            return await context.PrivateCustomers
                .Include("Accounts")
                .ToListAsync();
        }

        public Task<PrivateCustomer?> GetById(int id)
        {
            using var context = new MyDbContext();
            return context.PrivateCustomers
                .Include("Accounts")
                .FirstOrDefaultAsync(bc => bc.Id == id);
        }

        public Task<int> Add(PrivateCustomer entity)
        {
            using var context = new MyDbContext();
            context.PrivateCustomers.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task<int> Update(PrivateCustomer entity)
        {
            using var context = new MyDbContext();
            context.PrivateCustomers.Update(entity);
            return context.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
            using var context = new MyDbContext();
            var entity = context.PrivateCustomers.Find(id);
            if (entity != null)
            {
                context.PrivateCustomers.Remove(entity);
            }
            return context.SaveChangesAsync();
        }
    }
}
