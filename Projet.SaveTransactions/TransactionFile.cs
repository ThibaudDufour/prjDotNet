using Projet.Business;
using System.Text;
using Projet.Luhn;
using Projet.Datas.Entities.Interfaces;
using System.Text.Json;
using Projet.Business.Services;

namespace Projet.SaveTransactions
{
    public class TransactionFile
    {
        private string adress;

        private string content;

        private BankCardService bankCardService = new BankCardService();

        private ExchangeRateService exchangeRateService = new ExchangeRateService();

        public string Adress {
            get {
                return adress;
            }
        }

        public TransactionFile()
        {
            CreatePath();
        }

        private async Task<List<string>> GetCardNumbersFromBase()
        {
            return await bankCardService.GetAllCardsNumber();
        }

        private void CreatePath()
        {
            string endPath = DateTime.Now.ToString("s");
            endPath = endPath.Replace(":", "");
            endPath = endPath.Replace("-", "");
            endPath = endPath.Replace("T", "");
            adress = "./transactions/transactions_" + endPath + ".json";
        }

        private async Task CreateContent()
        {
            List<Transaction> transList = new List<Transaction>();
            var rand = new Random();
            List<string> cardNumbersFromBase = await GetCardNumbersFromBase();

            for (var i = 0; i < 10; i++)
            {
                string cardNumber; 
                if ( rand.Next(1,4) == 1)
                {
                    cardNumber = rand.Next(5) == 1 ? Luhn.Luhn.CreateInvalidCardNumber() : Luhn.Luhn.CreateValidCardNumber();
                }
                else
                {
                    cardNumber = cardNumbersFromBase[rand.Next(0, cardNumbersFromBase.Count - 1)];
                }

                double amount;
                EnumTransactionType type;
                int coinFlipType = rand.Next(1,4);
                EnumCurrency currency = EnumCurrency.EUR;
                int coinFlipCur = rand.Next(1, 5);


                if (coinFlipType == 1)
                {
                    type = EnumTransactionType.CashWithdrawal;
                    amount = Math.Round(0.01 * rand.Next(1, 10000), 0) * 10;
                } else {
                    type = coinFlipType == 2 ? EnumTransactionType.CardPayment : EnumTransactionType.CashDeposit;
                    amount = Math.Round(0.01 * rand.Next(10, 100000), 2);
                }

                switch (coinFlipCur)
                {
                    case 1:
                        currency = EnumCurrency.EUR;
                        break;
                    case 2:
                        currency = EnumCurrency.USD;
                        break;
                    case 3:
                        currency = EnumCurrency.GBP;
                        break;
                    case 4:
                        currency = EnumCurrency.CNY;
                        break;
                }

                Dictionary<string, double> dicExRate = await exchangeRateService.GetExchangeRate(currency.ToString());
                double rate;
                dicExRate.TryGetValue(EnumCurrency.EUR.ToString(), out rate);

                Transaction trans = new Transaction
                {
                    CardNumber = cardNumber,
                    Amount = amount,
                    TransactionType = type,
                    TransactionDate = DateTime.Now,
                    Currency = currency,
                    ExchangeRate = rate
                };

                transList.Add(trans);
            }

            content = JsonSerializer.Serialize<List<Transaction>>(transList);
        }

        public async Task Create()
        {
            await CreateContent();

            try
            {
                using (FileStream fs = File.Create(Path.GetFullPath(adress)))
                {
                    byte[] json = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(json, 0, json.Length);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
