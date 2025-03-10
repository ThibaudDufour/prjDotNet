using Projet.Datas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business
{
    class PrivateCustomerDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = " Le prénom ne peut pas dépasser 50 caracteres")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^(M|F)$", ErrorMessage = "Le sexe doit être 'M' ou 'F'.")]
        public EnumSexe Sex { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }
    }
}
