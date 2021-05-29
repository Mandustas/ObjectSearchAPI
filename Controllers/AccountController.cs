using AutoMapper;
using DataLayer.DTOs.Login;
using DataLayer.Models;
using DataLayer.Repositories.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AccountController(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<User> GetUserById(int id)
        {
            User user = _userRepository.GetById(id);
            return Ok(user);
        }


        [HttpGet]
        public ActionResult<User> GetByLoginAndPassword(string username, string password)
        {
            User user = _userRepository.GetByLoginPassword(username, password);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
    }
}
