using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyDatabaseAPI.Data;
using CompanyDatabaseAPI.DTOs;
using CompanyDatabaseAPI.Models;
using CompanyDatabaseAPI.Services;

namespace CompanyDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ILoginService loginService) : ControllerBase
    {
        // GET: api/Users
        [HttpGet("login/{username}")]
        public async Task<ActionResult<LoginDTO>> GetLogin(string username)
        {
            var loginDTO = await loginService.GetByUsername(username);
            return loginDTO != null ? Ok(loginDTO) : NotFound();
        }
    }
}
