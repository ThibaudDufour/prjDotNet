using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;

namespace Projet.Datas.Repositories
{
    public class LoginRepository
    {
        public LoginRepository() 
        {
            InitializeDataBase();
        }

        private void InitializeDataBase()
		{
			using var context = new MyDbContext();
			context.Database.EnsureCreated();
		}

		public async Task<List<LoginUser>> GetAll()
		{
			using var context = new MyDbContext();
			return await context.LoginUsers
				.Select(u => new LoginUser
				{
					Id = u.Id,
					Name = u.Name,
					Email = u.Email
				})
				.ToListAsync<LoginUser>();
		}

		public async Task<LoginUser?> GetByEmail(string email)
		{
			using var context = new MyDbContext();
			return await context.LoginUsers
				.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<int> Add(LoginUser entity)
		{
			using var context = new MyDbContext();
			context.LoginUsers.Add(entity);
			return await context.SaveChangesAsync();
		}

		public async Task<int> Update(LoginUser entity)
		{
			using var context = new MyDbContext();
			context.LoginUsers.Update(entity);
			return await context.SaveChangesAsync();
		}

		public async Task<int> Delete(LoginUser entity)
		{
			using var context = new MyDbContext();
			context.LoginUsers.Remove(entity);
			return await context.SaveChangesAsync();
		}

		public async Task<int> DeleteByEmail(string email)
		{
			using var context = new MyDbContext();
			var user = context.LoginUsers.FirstOrDefault(u => u.Email == email);
			if (user != null)
			{
				context.LoginUsers.Remove(user);
			}
			return await context.SaveChangesAsync();
		}
	}
}
