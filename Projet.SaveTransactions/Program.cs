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

        await TransactionFolder.CreateFile();

        await TransactionFolder.ProcessFiles();

        Console.WriteLine("Serveur Running...");

        var createFilesTask = TransactionFolder.CreateFilesAsync();
        var processFilesTask = TransactionFolder.ProcessFilesAsync();

        await Task.WhenAll(createFilesTask,processFilesTask);
    }
}