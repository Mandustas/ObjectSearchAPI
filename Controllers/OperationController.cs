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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/operation")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationsRepository _operationsRepository;
        private readonly IMapper _mapper;
        public OperationController(
            IOperationsRepository operationsRepository,
            IMapper mapper
            )
        {
            _operationsRepository = operationsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Operation>> GetOperations(bool? isActive = null, int? coordinatorId = null)
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
        public ActionResult<Operation> GetActiveOperation(int? coordinatorId = null)
        {
            var operation = _operationsRepository.Get(isSuccess: false, coordinatorId).FirstOrDefault();
            if (operation != null)
            {
                return Ok(operation);
            }

            return NotFound();
        }

        [HttpGet("activeUser", Name = "GetActiveOperationUser")]
        public ActionResult<OperationDTO> GetActiveOperationUser(int? userId)
        {
            var operation = _operationsRepository.GetByUserId(userId);
            if (operation != null)
            {
                OperationDTO opDto = new OperationDTO(operation);
                return Ok(opDto);
            }

            return NotFound();
        }



        [Authorize(Roles = "Координатор ПСР")]

        [HttpPost]
        public ActionResult<OperationsCreateDto> CreateOperation(OperationsCreateDto operationsCreateDto)
        {
            var operation = _mapper.Map<Operation>(operationsCreateDto);
            operation.Date = DateTime.Now;
            operation.IsSuccess = false;
            operation.CoordinatorId = 1; //TODO заменить "1" на текущего пользователя
            _operationsRepository.Create(operation);
            _operationsRepository.SaveChanges();

            var operationsReadDto = _mapper.Map<Operation>(operation);

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
            return NoContent();
        }
    }
}