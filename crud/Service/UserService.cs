using crud.Models;
using crud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Service
{
    public interface IUserService
    {
        Task<List<TBL_USER>> GetAll();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)  => _userRepo = userRepo;
        public async Task<List<TBL_USER>> GetAll() => await _userRepo.GetAll();
    }
}
