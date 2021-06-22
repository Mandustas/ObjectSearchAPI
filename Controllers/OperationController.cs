using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DTOs.Operation;
using DataLayer.Models;
using DataLayer.Repositories.Operations;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using ObjectSearchAPI.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/operation")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OperationController : ControllerBase
    {
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private readonly IOperationsRepository _operationsRepository;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IMapper _mapper;
        public OperationController(
            IOperationsRepository operationsRepository,
            IHubContext<NotificationHub> notificationHub,
            IMapper mapper
            )
        {
            _operationsRepository = operationsRepository;
            _notificationHub = notificationHub;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Operation>> GetOperations()
        {
            var operations = _operationsRepository.Get(UserId).ToList();
            return Ok(operations);
        }

        [HttpGet("user", Name = "GetOperationForUser")]
        public ActionResult<IEnumerable<Operation>> GetOperationsForUser(bool? isActive = null, int? coordinatorId = null)
        {
            var operations = _operationsRepository.Get(!isActive, coordinatorId).ToList();
            return Ok(operations);
        }


        [HttpGet("{id}", Name = "GetOperationById")]
        public ActionResult<Operation> GetOperationById(int id)
        {
            var operation = _operationsRepository.GetById(id);
            if (operation != null)
            {
                return Ok(operation);
            }
            return NotFound();
        }

        [HttpGet("active", Name = "GetActiveOperation")]
        public ActionResult<Operation> GetActiveOperation()
        {
            var operation = _operationsRepository.GetActiveOperation(UserId);
            if (operation != null)
            {
                return Ok(operation);
            }

            return NotFound();
        }

        [HttpGet("activeUser", Name = "GetActiveOperationUser")]
        public ActionResult<OperationDTO> GetActiveOperationUser()
        {
            var operation = _operationsRepository.GetByUserId(UserId);
            if (operation != null)
            {
                OperationDTO opDto = new OperationDTO(operation);
                return Ok(opDto);
            }

            return NotFound();
        }

        [HttpPost("enterOperation", Name = "EnterToOperaton")]
        public ActionResult EnterToOperation(int idOperation)
        {
            OperationUser operationUser = new OperationUser();
            operationUser.UserId = UserId; operationUser.OperationId = idOperation;
            _operationsRepository.EnterToOperationUser(operationUser);
            _operationsRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteOperation", Name = "DeleteOperationUser")]
        public ActionResult DeleteOperationUser(int idOperation)
        {
            OperationUser operationUser = new OperationUser();
            operationUser.UserId = UserId; operationUser.OperationId = idOperation;
            _operationsRepository.DeleteOperationUser(operationUser);
            _operationsRepository.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Координатор ПСР")]

        [HttpPost]
        public ActionResult<OperationsCreateDto> CreateOperation(OperationsCreateDto operationsCreateDto)
        {
            var operation = _mapper.Map<Operation>(operationsCreateDto);
            operation.Date = DateTime.Now;
            operation.IsSuccess = false;
            operation.CoordinatorId = UserId; 
            _operationsRepository.Create(operation);
            _operationsRepository.SaveChanges();

            var operationsReadDto = _mapper.Map<Operation>(operation);
            _notificationHub.Clients.All.SendAsync("SendMessage", "OperationCreated");
            return CreatedAtRoute(nameof(GetOperationById), new { Id = operationsReadDto.Id }, operationsReadDto); //Return 201
        }
        [Authorize(Roles = "Координатор ПСР")]
        [HttpPut("{id}")]
        public ActionResult<Operation> UpdateOperation(int id, OperationsUpdateDto operationsUpdateDto)
        {
            var operation = _operationsRepository.GetById(id);
            if (operation == null)
            {
                return NotFound();
            }

            _mapper.Map(operationsUpdateDto, operation);
            _operationsRepository.Update(operation); // Best practice
            _operationsRepository.SaveChanges();
            _notificationHub.Clients.All.SendAsync("SendMessage", "OperationUpdated");
            _notificationHub.Clients.All.SendAsync("Notification", "Всем спасибо! Все свободны!");
            return NoContent();
        }

        [Authorize(Roles = "Координатор ПСР")]
        [HttpDelete("{id}")]
        public ActionResult DeleteOperation(int id)
        {
            var operation = _operationsRepository.GetById(id);
            if (operation == null)
            {
                return NotFound();
            }

            _operationsRepository.Delete(operation);
            _operationsRepository.SaveChanges();
            _notificationHub.Clients.All.SendAsync("SendMessage", "OperationDeleted");
            return NoContent();
        }
    }
}