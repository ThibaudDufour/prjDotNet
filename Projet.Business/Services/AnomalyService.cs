using AutoMapper;
using Projet.Datas.Repositories;
using Projet.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Services
{
    public class AnomalyService
    {
        private readonly AnomalyRepository _repo;
        private readonly IMapper _mapper;

        public AnomalyService()
        {
            _repo = new AnomalyRepository();
            _mapper = MappingConfig.Mapper;
        }

        public async Task<int> AddTransaction(AnomalyDto anoDto)
        {
            Anomaly ano = _mapper.Map<Anomaly>(anoDto);
            return await _repo.Add(ano);
        }
    }
}
