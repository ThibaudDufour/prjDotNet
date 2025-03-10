using Projet.Datas.Entities;
using Projet.Datas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business
{
    class TransactionDto
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
        public string Currency { get; set; }
        public int BankAccountId { get; set; }

        public Account BankAccount { get; set; }
    }
}
