using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet.Datas.Entities;
using Projet.Datas;

namespace Projet.Datas.Repositories
{
    public class AnomalyRepository : IRepository<Anomaly>
    {
        public AnomalyRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }

        public async Task<int> Add(Anomaly anoEntity)
        {
            using var context = new MyDbContext();
            context.Anomalies.Add(anoEntity);         
            return await context.SaveChangesAsync();
        }

        public async Task<Anomaly?> GetById(int id)
        {
            using var context = new MyDbContext();
            var anomaly = await context.Anomalies
                                            .Where<Anomaly>(a => a.Id == id)
                                            .SingleOrDefaultAsync<Anomaly>();
            return anomaly;
        }

        public async Task<int> Delete(int id)
        {
            using var context = new MyDbContext();
            Anomaly anomalyToRemove = await GetById(id);

            int lineAffected = 0;

            if (anomalyToRemove != null)
            {
                context.Anomalies.Remove(anomalyToRemove);
                lineAffected = await context.SaveChangesAsync();
            }

            return lineAffected;
        }

        public async Task<List<Anomaly>> GetAll()
        {
            using var context = new MyDbContext();
            List<Anomaly> anomalies = await context.Anomalies.ToListAsync<Anomaly>();
            return anomalies;
        }

        public async Task<int> Update(Anomaly entity)
        {
            throw new NotImplementedException();
        }
    }
}
