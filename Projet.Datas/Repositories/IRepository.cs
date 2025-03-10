namespace Projet.Datas.Repositories
{
    public interface IReadOnlyRepository<T>
		where T : class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
	}

	public interface IWriteOnlyRepository<T>
		where T : class
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}

	public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
		where T : class
	{

    }
}
