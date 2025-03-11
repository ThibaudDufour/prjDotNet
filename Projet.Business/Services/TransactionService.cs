using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Projet.Datas.Entities;
using Projet.Datas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _repo;
        private readonly IMapper _mapper;

        public TransactionService()
        {
            _repo = new TransactionRepository();
            _mapper = MappingConfig.Mapper;
        }

        public async Task<int> AddTransaction(TransactionDto transDto)
        {
            Transaction trans = _mapper.Map<Transaction>(transDto);
            return await _repo.Add(trans);
        }
    }
}
