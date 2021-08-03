using crud.Models;
using crud.Service;
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
    public class ServiceController : ControllerBase
    {
        private readonly IUserService _userService;
        public ServiceController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<TBL_USER>> GetAllUser()
        {
            return await _userService.GetAll();
        }
    }
}
