using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Models;
using DataLayer.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DataLayer.Repositories.Operations;
using ObjectSearchAPI.Hubs;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ControllerBase
    {
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private readonly IUserRepository _userRepository;
        private readonly IOperationsRepository _operationRepository;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IMapper _mapper;
        public UserController(
            IUserRepository userRepository,
            IOperationsRepository operationRepository,
            IHubContext<NotificationHub> notificationHub,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _operationRepository = operationRepository;
            _notificationHub = notificationHub;
            _mapper = mapper;
        }

        [HttpGet("getCoordinate")]
        public ActionResult<IEnumerable<User>> GetUsersCoordinate(int operationId)
        {
            var users = _userRepository.GetCoordinateUser(UserId, operationId);
            var userPositions = new List<UserPosition>();
            foreach(var item in users)
            {
                List<UserPosition> userPositionTMP = new List<UserPosition>();
                userPositionTMP.Add(_userRepository.GetLastUserPosition(item.Id));
                item.UserPositions = userPositionTMP;
            }
            foreach(var item in users)
            {
                item.OperationUsers = null;
                item.Operations = null;
            }
            if(users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpPost("postCoordinate")]
        public ActionResult<string> PushUsersCoordinate(double  x, double y)
        {
            if (!_userRepository.CreateUserCoordinate(x, y, UserId)) return NotFound();
            bool prov = _userRepository.SaveChanges();
            if (prov) return Ok("200 ОК");
            return NotFound(); 
        }

        [HttpGet("infoUser")]
        public ActionResult<User> GetInfoUser()
        {
            var user = _userRepository.GetInfoById(UserId);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
            
        }

        [HttpGet]
        [Authorize(Roles = "Координатор ПСР")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            int ActiveOperationId = _operationRepository.GetActiveOperationId(UserId);
            var users = _userRepository.Get(ActiveOperationId).ToList();
            return Ok(users);
        }
        [HttpPost]
        [Route("addusers")]
        [Authorize(Roles = "Координатор ПСР")]
        public ActionResult<IEnumerable<User>> AddUsersToOperations()
        {
            //var activeOperation = _operationRepository.GetActiveOperation(UserId);
            var activeOperationId = _operationRepository.GetActiveOperationId(UserId);
            var activeOperation = _operationRepository.GetById(activeOperationId);
            var users = _userRepository.Get(UserRoleId: 4, UserStatusId: 2).ToList();
            users.AddRange(_userRepository.Get(UserRoleId: 4, UserStatusId: 3).ToList());
            var activeOperationUsers = _userRepository.Get(activeOperationId).ToList();
            var usersToAdd = activeOperationUsers;

            foreach (var user in users)
            {
                if (!activeOperationUsers.Any(c => c.Id == user.Id))
                {
                    usersToAdd.Add(user);
                }
            }

            activeOperation.Users = usersToAdd;
            //foreach (var user in users)
            //{
            //    activeOperation.Users.Append(user);
            //}
            _operationRepository.Update(activeOperation); // Best practice
            _operationRepository.SaveChanges();
            _notificationHub.Clients.All.SendAsync("SendMessage", "У вас новая операция");
            _notificationHub.Clients.All.SendAsync("Notification", "Вам назначена новая операция"); 
            return Ok();
        }
    }
}
