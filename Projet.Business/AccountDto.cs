using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business
{
    class AccountDto
    {
        public string AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal Balance { get; init; }

        public int Overdraft { get; init; }
        public int OwnerId { get; set; }
    }
}
