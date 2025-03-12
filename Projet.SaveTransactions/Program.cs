using Projet.Business;
using Projet.Business.Services;
using Projet.Datas.Repositories;
using Projet.Luhn;
using Projet.SaveTransactions;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    
    private static async Task Main(string[] args)
    {
        TransactionFolder.CreateFoldersIfNotExist();

        TransactionFolder.ClearFolders();

        TransactionFolder.CreateFile();

        await TransactionFolder.ProcessFiles();

    }
}