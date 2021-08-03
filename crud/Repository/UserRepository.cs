using crud.Data;
using crud.Models;
using crud.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Repository
{
    public interface IUserRepository
    {
        Task<List<TBL_USER>> GetAll();
    }
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _db;
        public UserRepository(MySQLContext db) => _db = db;
        public async Task<List<TBL_USER>> GetAll() => await _db.TBL_USER.ToListAsync();

    }
}
