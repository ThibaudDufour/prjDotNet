namespace Projet.Datas.Repositories
{
    public interface IReadOnlyRepository<T>
		where T : class
	{
		Task<T?> GetById(int id);
		Task<List<T>> GetAll();
	}

	public interface IWriteOnlyRepository<T>
		where T : class
	{
		Task<int> Add(T entity);
		Task<int> Update(T entity);
		Task<int> Delete(int id);
	}

	public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
		where T : class
	{

    }
}
