﻿using System.ComponentModel.DataAnnotations;

namespace Projet.Datas.Entities
{
	public class Account
	{
		[Key]
		public string AccountNumber { get; set; }
		public DateTime OpeningDate { get; set; }
		public double Balance { get; set; } = 1000;
		public int Overdraft { get; set; } = 500;

		public List<Customer> Owners { get; set; }

		public List<Transaction> Transactions { get; set; }

		public void Deposit(double amount)
		{
			Balance += amount;
		}

		public void Withdraw(double amount)
		{
			if (Balance - amount < -Overdraft)
			{
				throw new InvalidOperationException("Insufficient balance");
			}
			Balance -= amount;
		}

		public static string GenerateAccountNumber()
		{
			Random rand = new Random();
			return $"FR{rand.Next(1000, 9999)}{rand.Next(1000, 9999)}{rand.Next(1000, 9999)}";
		}
	}
}
