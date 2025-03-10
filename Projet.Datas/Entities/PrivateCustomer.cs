using Projet.Datas.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Projet.Datas.Entities
{
    public class PrivateCustomer : Customer
    {
        public DateTime DateBirth { get; set; }
        [MaxLength(50)]
		public string FirstName {  get; set; }
        public EnumSexe Sex { get; set; }
    }
}
