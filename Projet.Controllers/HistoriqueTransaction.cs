using Projet.Business.Services;
using Projet.Datas;
using Projet.Datas.Entities.Interfaces;
using Recap.Views;
using System;
using System.Linq;

namespace Projet.Controllers
{
    public class HistoriqueTransaction
    {
        private readonly TransactionService _transactionService;
        private readonly TransactionView _transactionView;

        public HistoriqueTransaction(TransactionView transactionView)
        {
            _transactionService = new TransactionService();
            _transactionView = transactionView;
        }

        public void AfficherHistorique(string numeroCompte)
        {
            var historique = _transactionService.GetTransactionsHistoric(numeroCompte).Result;

            _transactionView.ShowHistoricTransaction(numeroCompte, historique);
        }

        public void AfficherHistoriqueByType(string accountNumber, EnumTransactionType transactionType)
        {
            var transactions = _transactionService.GetTransactionHistoricByType(accountNumber, transactionType).Result;
            _transactionView.ShowHistoricTransaction(accountNumber, transactions);

        }

    }
}
