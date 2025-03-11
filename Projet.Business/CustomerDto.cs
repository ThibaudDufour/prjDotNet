using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = " Le nom ne peut pas dépasser 50 caracteres")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = " L'adresse ne peut pas dépasser 100 caracteres")]
        public string Label { get; set; }
        public string AdditionalInfo { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = " La ville ne peut pas dépasser 50 caracteres")]
        public string City { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
