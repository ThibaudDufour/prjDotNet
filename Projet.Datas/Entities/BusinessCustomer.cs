using Projet.Datas.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Projet.Datas.Entities
{
    public class BusinessCustomer : Customer
    {
        [StringLength(14)]
        public string Siret {  get; set; }
        public EnumLegalStatus LegalStatus { get; set; }
        public string SiegeLabel { get; set; }
        public string? SiegeComplement { get; set; }
        public string SiegePostalCode { get; set; }
        public string SiegeCity { get; set; }
    } 
}
