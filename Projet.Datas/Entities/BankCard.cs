using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet.Datas.Entities
{
    public class BankCard
    {
		[Required]
		[RegularExpression(@"^\d{16}$", ErrorMessage = "Le numéro de carte doit contenir exactement 16 chiffres.")]
		public string CardNumber { get; set; }

		[Required]
		public string AccountNumber { get; set; }

		[ForeignKey("AccountNumber")]
		public Account BankAccount { get; set; }
	}
}
