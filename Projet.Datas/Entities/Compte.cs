using System.ComponentModel.DataAnnotations;

namespace Projet.Datas.Entities
{
	public class Compte
	{
		[Key]
		public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
		public DateTime OpeningDate { get; set; } = DateTime.Now;
		public decimal Balance { get; set; } = 1000m;
		public int Overdraft { get; set; } = 1000;

		public int OwnerId { get; set; }
		public Client Owner { get; set; }

		public List<Transaction> Transactions { get; set; }

		public void Deposit(decimal amount)
		{
			Balance += amount;
		}

		public void Withdraw(decimal amount)
		{
			if (Balance - amount < -Overdraft)
			{
				throw new InvalidOperationException("Insufficient balance");
			}
			Balance -= amount;
		}
	}
}
