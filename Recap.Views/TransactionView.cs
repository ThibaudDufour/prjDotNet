using Projet.Business;
using Projet.Datas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Views
{
    public class TransactionView
    {
        public void ShowHistoricTransaction(string numeroCompte, List<TransactionDto> historique) {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine} Historique des transactions du compte {numeroCompte} :");

            if (!historique.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucune transaction effectuée.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var t in historique)
            {
                Console.WriteLine($"{t.TransactionDate:dd/MM/yyyy HH:mm} - {t.TransactionType}: {t.CardNumber}: {t.Amount} {t.Currency}");
            }
            Console.ResetColor();
        }

        public void ShowHistoricTransactionByType(string accountNumber, EnumTransactionType transactionType, List<TransactionDto> transactions)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                $"{Environment.NewLine} Historique des transactions de type {transactionType.ToString()} :"
            );
            if (!transactions.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucune transaction effectuée.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.TransactionDate:dd/MM/yyyy HH:mm} - {t.CardNumber}: {t.Amount} {t.Currency}");
            }
            Console.ResetColor();
        }

    }
}
