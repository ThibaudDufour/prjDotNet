using AutoMapper;
using Projet.Datas.Entities;

namespace Projet.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anomaly, AnomalyDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<BusinessCustomer, BusinessCustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<PrivateCustomer, PrivateCustomerDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }


    }
}
