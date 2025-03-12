using Projet.Business;
using System.Text;
using Projet.Luhn;
using Projet.Datas.Entities.Interfaces;
using System.Text.Json;

namespace Projet.SaveTransactions
{
    public class TransactionFile
    {
        private string adress;

        private string content;

        public string Adress {
            get {
                return adress;
            }
        }

        private void CreatePath()
        {
            string endPath = DateTime.Now.ToString("s");
            endPath = endPath.Replace(":", "");
            endPath = endPath.Replace("-", "");
            endPath = endPath.Replace("T", "");
            adress = "./transactions/transactions_" + endPath + ".json";
        }

        private void CreateContent()
        {
            List<TransactionDto> transList = new List<TransactionDto>();
            var rand = new Random();

            // Namespace not recognized for some reason

            for (var i = 0; i < 10; i++)
            {
                string cardNumber = rand.Next(10) == 1 ? Luhn.Luhn.CreateInvalidCardNumber() : Luhn.Luhn.CreateValidCardNumber();

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

                TransactionDto transDto = new TransactionDto
                {
                    CardNumber = cardNumber,
                    Amount = amount,
                    TransactionType = type,
                    TransactionDate = DateTime.Now,
                    Currency = currency
                };

                transList.Add(transDto);
            }

            content = JsonSerializer.Serialize<List<TransactionDto>>(transList);
        }

        public TransactionFile()
        {
            CreatePath();
            CreateContent();
            //Content = "[\r\n  {\r\n    \"type\": \"ATM\",\r\n    \"cardNumber\": \"4974018502231456\",\r\n    \"amount\": 100,\r\n    \"date\": \"2025-03-11T10:30:21\",\r\n    \"currency\": \"EUR\"\r\n  },\r\n  {\r\n    \"type\": \"POS\",\r\n    \"cardNumber\": \"4974018502235218\",\r\n    \"amount\": 12.85,\r\n    \"date\": \"2025-03-11T11:50:45\",\r\n    \"currency\": \"USD\"\r\n  },\r\n  {\r\n    \"type\": \"CASH DEP\",\r\n    \"cardNumber\": \"4974018502230782\",\r\n    \"amount\": 250,\r\n    \"date\": \"2025-03-11T16:02:17\",\r\n    \"currency\": \"CNY\"\r\n  },\r\n  {\r\n    \"type\": \"CASH DEP\",\r\n    \"cardNumber\": \"4974018502231235\",\r\n    \"amount\": 1000,\r\n    \"date\": \"2025-03-11T16:23:12\",\r\n    \"currency\": \"GBP\"\r\n  }\r\n]";
        }

        public void Create()
        {
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
