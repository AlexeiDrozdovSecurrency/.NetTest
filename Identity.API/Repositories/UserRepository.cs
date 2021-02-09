using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestWeb.API.Entities;

namespace TestWeb.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<UserEntity> Get()
        {
            return _context.Users.Include(u => u.AddressEntity);
        }

        public UserEntity Save(UserEntity user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}