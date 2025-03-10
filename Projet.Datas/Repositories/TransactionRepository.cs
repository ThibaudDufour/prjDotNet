﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet.Datas.Entities;
using Projet.Datas;

namespace Projet.Datas.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        public TransactionRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async Task<int> Add(Transaction transEntity)
        {
            using var context = new MyDbContext();
            context.Transactions.Add(transEntity);
            return await context.SaveChangesAsync();
        }

        public async Task<Transaction?> GetById(int id)
        {
            using var context = new MyDbContext();
            return await context.Transactions
                                            .Where<Transaction>(testc => testc.Id == id)
                                            .SingleOrDefaultAsync<Transaction>();
        }

        public async Task<int> Delete(int id)
        {
            using var context = new MyDbContext();
            Transaction transactionToRemove = await this.GetById(id);

            int lineAffected = 0;

            if (transactionToRemove != null)
            {
                context.Transactions.Remove(transactionToRemove);
                lineAffected = await context.SaveChangesAsync();
            }

            return lineAffected;
        }

        public async Task<List<Transaction>> GetAll()
        {
            using var context = new MyDbContext();
            List<Transaction> transactions = await context.Transactions.ToListAsync<Transaction>();
            return transactions;
        }

        public async Task<int> Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
