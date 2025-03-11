using Projet.Datas.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business
{
    public class BusinessCustomerDto
    {
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Le SIRET doit contenir exactement 14 chiffres.")]
        public string Siret { get; set; }

        [Required]
        [RegularExpression(@"^(SARL|SA|SAS|EURL)$", ErrorMessage = "Le statut juridique doit être SARL, SA, SAS ou EURL.")]
        public EnumLegalStatus LegalStatus { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = " Le label ne peut pas dépasser 100 caracteres")]
        public string SiegeLabel { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = " Le label ne peut pas dépasser 100 caracteres")]
        public string SiegeComplement { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string SiegePostalCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = " La ville du siege ne peut pas dépasser 50 caracteres")]
        public string SiegeCity { get; set; }
    }
}
