﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Models;
using DataLayer.Repositories.Users;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]


    public class UserController : ControllerBase
    {
        // GET: api/<TargetController>
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Координатор ПСР")]
        public ActionResult<IEnumerable<Target>> GetUsers()
        {
            var users = _userRepository.Get().ToList();
            return Ok(users);
        }
    }
}
