using Microsoft.AspNetCore.DataProtection;
using Pratik_Identity.Data;
using Pratik_Identity.Model;

namespace Pratik_Identity.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IDataProtector _protector;

        public UserService(AppDbContext context, IDataProtectionProvider dataProtectionProvider)
        {
            _context = context;
            _protector = dataProtectionProvider.CreateProtector("UserPasswordProtector");
        }

        public void RegisterUser(string email, string password)
        {
            var hashedPassword = _protector.Protect(password);
            var user = new User
            {
                Email = email,
                Password = hashedPassword
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool VerifyUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            var unprotectedPassword = _protector.Unprotect(user.Password);
            return unprotectedPassword == password;
        }
    }
}
