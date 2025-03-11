using Projet.Business.Auth;
using Projet.Controllers;
using Recap.Views;
using System.Threading.Tasks;

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
        RapportController rapportController = new RapportController(rapportView);

        while (true)
        {
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("Menu principal");
            Console.WriteLine("1. Générer un rapport");
            Console.WriteLine("");
            Console.WriteLine("0. Déconnexion");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.Write("Votre choix : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await rapportController.GenerateExport();
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
}

