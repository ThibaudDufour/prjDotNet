using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Datas.Entities
{
    public class Auth
    {
        private readonly MyDbContext _context;

        public Auth()
        {
            _context = new MyDbContext();
            _context.Database.EnsureCreated();
        }

        public void Register(string nom, string email, string password)
        {
            if (_context.LoginUsers.Any(u => u.Email == email))
            {
                Console.WriteLine("Cet email est déjà utilisé !");
                return;
            }

            var user = new LoginUser { Name = nom, Email = email };
            user.SetPassword(password);

            _context.LoginUsers.Add(user);
            _context.SaveChanges();
            Console.WriteLine("Inscription réussie !");
        }

        public bool Login(string email, string password)
        {
            var user = _context.LoginUsers.SingleOrDefault(u => u.Email == email);
            if (user == null || !user.VerifyPassword(password))
            {
                Console.WriteLine("Identifiants incorrects !");
                return false;
            }

            Console.WriteLine($"Bienvenue, {user.Name} !");
            return true;
        }
    }
}
