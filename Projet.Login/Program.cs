using Projet.Datas.Entities;
using System;

class Program
{
    static void Main()
    {
        Auth authService = new Auth();

        while (true)
        {
            Console.WriteLine("Menu Authentification :");
            Console.WriteLine("1️-Inscription");
            Console.WriteLine("2️-Connexion");
            Console.WriteLine("3️-Quitter");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nNom : ");
                    string name = Console.ReadLine();

                    Console.Write("Email : ");
                    string email = Console.ReadLine();

                    Console.Write("Mot de passe : ");
                    string password = Console.ReadLine();

                    authService.Register(name, email, password);
                    break;

                case "2":
                    Console.Write("\nEmail : ");
                    string loginEmail = Console.ReadLine();

                    Console.Write("Mot de passe : ");
                    string loginPassword = Console.ReadLine();

                    if (authService.Login(loginEmail, loginPassword))
                    {
                        Console.WriteLine("\nAccès validé !");
                        return;
                    }
                    break;

                case "3":
                    Console.WriteLine("Au revoir !");
                    return;

                default:
                    Console.WriteLine("Choix invalide !");
                    break;
            }
        }
    }
}

