using Projet.Controllers;
using Projet.Datas.Entities.Interfaces;
using Recap.Views;

class Program
{
    private static async Task Main()
    {
        LoginView loginView = new LoginView();
        LoginController loginController = new LoginController(loginView);

		while (true)
        {
			loginView.ShowMenu();
			Console.Write("Votre choix : ");
			string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bool isAuthenticated = await loginController.Login();
                    if (isAuthenticated)
                    {
                        await ShowMainMenu(loginView);
					}
					break;

				case "2":
					await loginController.Register();
					break;

				case "0":
                    loginView.ShowGoodbyeMessage();
					return;

                default:
                    loginView.ShowInvalidChoice();
					break;
            }
        }
    }

    private static async Task ShowMainMenu(LoginView loginView)
    {
        RapportView rapportView = new RapportView();
        TransactionView TransactionView = new TransactionView();
        RapportController rapportController = new RapportController(rapportView);
        HistoriqueTransaction historiqueTransaction = new HistoriqueTransaction(TransactionView);

        while (true)
        {
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("Menu principal");
            Console.WriteLine("1. Générer un rapport");
            Console.WriteLine("2. Historique des transactions");
            Console.WriteLine("0. Déconnexion");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.Write("Votre choix : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await rapportController.GenerateExport();
                    break;

                 case "2":
                    await ShowHistoriqueTransaction(historiqueTransaction);
                    break;
                case "0":
                    loginView.ShowGoodbyeMessage();
                    return;

				default:
                    loginView.ShowInvalidChoice(); 
                    break;
			}
        }
    }

    private static async Task ShowHistoriqueTransaction(HistoriqueTransaction historiqueTransaction)
    {
        Console.WriteLine("Entrez votre numéro de compte : ");
        string numeroCompte = Console.ReadLine();
        historiqueTransaction.AfficherHistorique(numeroCompte);

        Console.WriteLine("Filtrez sur le type de transaction que vous souhaitez : ");
        Console.WriteLine("1-Retrait");
        Console.WriteLine("2-Dépôt");
        Console.WriteLine("3-Paiement par carte");
        string type = Console.ReadLine();

                switch (type)
                {
                    case "1":
                        Console.WriteLine("Historique des Retraits");
                        historiqueTransaction.AfficherHistoriqueByType(numeroCompte, EnumTransactionType.CashWithdrawal);
                        break;
                    case "2":
                        Console.WriteLine("Historique des Dépôts");
                        historiqueTransaction.AfficherHistoriqueByType(numeroCompte, EnumTransactionType.CashDeposit);
                        break;
                    case "3":
                        Console.WriteLine("Historique des paiements par carte");
                        historiqueTransaction.AfficherHistoriqueByType(numeroCompte, EnumTransactionType.CardPayment);
                        break;
                    default:
                        Console.WriteLine("Type de transaction invalide");
                        break;
                }
    }
}

