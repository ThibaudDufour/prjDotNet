using Projet.Datas.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Datas.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public double Amount { get; set; }

        public EnumTransactionType TransactionType {get; set; }

        public DateTime TransactionDate { get; set; }

        public string Currency { get; set; }

		public int BankAccountId { get; set; }
		public Account BankAccount { get; set; }
	}
}
