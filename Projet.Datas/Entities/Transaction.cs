using Projet.Datas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet.Datas.Entities
{
    class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string BankAccount { get; set; }

        public string CardNumber { get; set; }

        public double Amount { get; set; }

        public TransactionType TransactionType {get; set; }

        public DateTime TransactionDate { get; set; }

        public string Currency { get; set; }

    }
}
