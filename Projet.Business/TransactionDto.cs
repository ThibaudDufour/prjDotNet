using Projet.Datas.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Projet.Business
{
    public class TransactionDto
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Le numéro de carte bancaire doit contenir exactement 16 chiffres.")]
        public string CardNumber { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0.")]
        public double Amount { get; set; }

        [Required]
        [RegularExpression(@"^(DEBIT|CREDIT)$", ErrorMessage = "Le type de transaction doit être 'DEBIT' ou 'CREDIT'.")]
        public EnumTransactionType TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
        public EnumCurrency Currency { get; set; }
    }
}
