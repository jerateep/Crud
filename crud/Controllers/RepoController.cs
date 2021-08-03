using crud.Models;
using crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public RepoController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<List<TBL_USER>> GetAllUser()
        {
            return await _userRepo.GetAll();
        }
    }
}
