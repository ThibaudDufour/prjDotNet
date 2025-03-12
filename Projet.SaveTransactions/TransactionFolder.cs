using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Projet.Business;
using Projet.Business.Services;

namespace Projet.SaveTransactions
{
    public static class TransactionFolder
    {
        private static string folderPath = "./transactions";
        private static string logFolderPath = "./transactions_logs";

        private static TransactionService _transactionService = new TransactionService();
        private static AnomalyService _anomalyService = new AnomalyService();

        private static void CreateFolderIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Folder Created : " + path);
            }
        }

        public static void CreateFoldersIfNotExist()
        {
            CreateFolderIfNotExist(folderPath);
            CreateFolderIfNotExist(logFolderPath);
        }


        public static void ClearFolders()
        {
            ClearFolder(folderPath);
            ClearFolder(logFolderPath);
        }
        private static void ClearFolder(string path)
        {
            string[] transfiles = Directory.GetFiles(path);
            
            foreach(string file in transfiles)
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine($"File deleted : {Path.GetFullPath(file)}");
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        public static async Task CreateFile()
        {
            
            TransactionFile file = new TransactionFile();
            await file.Create();
            Console.WriteLine("New transaction file created");
        }


        public static async Task ProcessFiles()
        {
            string[] transfiles = Directory.GetFiles("./transactions");

            foreach (string transfile in transfiles)
            {
                try
                {
                    string transJson = File.ReadAllText(transfile);

                    var options = new JsonSerializerOptions
                    {
                        Converters = { new JsonStringEnumConverter() }
                    };

                    var transData = JsonSerializer.Deserialize<List<TransactionDto>>(transJson, options);
                    foreach (TransactionDto transDto in transData)
                    {
                        if (Projet.Luhn.Luhn.IsValid(transDto.CardNumber))
                        {
                            if (await _transactionService.AddTransaction(transDto) > 0)
                            {
                                Console.WriteLine("Ajout en base réussi");
                            }
                            else
                            {
                                Console.WriteLine("Echec de l'ajout en base");
                            }
                        }
                        else
                        {
                            AnomalyDto anoDto = new AnomalyDto
                            {
                                CardNumber = transDto.CardNumber,
                                Amount = transDto.Amount,
                                Currency = transDto.Currency,
                                TransactionType = transDto.TransactionType,
                                TransactionDate = transDto.TransactionDate
                            };

                            if (await _anomalyService.AddTransaction(anoDto) > 0)
                            {
                                Console.WriteLine("Ajout en base réussi");
                            }
                            else
                            {
                                Console.WriteLine("Echec de l'ajout en base");
                            }

                        }
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                string destination = transfile.Replace(folderPath, logFolderPath);
                File.Move(transfile, destination);
            }
        }

        public static async Task CreateFilesAsync()
        {
            while (true)
            {
                await Task.Delay(10000);

                await CreateFile();
            }
        }

        public static async Task ProcessFilesAsync()
        {
            while (true)
            {
                await Task.Delay(30000);

                await ProcessFiles();
            }
        }
    }
}
