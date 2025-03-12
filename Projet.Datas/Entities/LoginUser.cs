using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet.Datas.Entities
{
    public class LoginUser
    {
        public int Id { get; set; }

        [Required]
        public  string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
