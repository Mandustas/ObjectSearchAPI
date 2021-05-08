using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DTOs.Operation;
using DataLayer.Models;
using DataLayer.Repositories.Operations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/operation")]
    [ApiController]
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
        public ActionResult<IEnumerable<Operation>> GetOperations(bool? isActive = true)
        {
            var operations = _operationsRepository.Get(!isActive).ToList();

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
            var operation = _operationsRepository.Get(isSuccess: false).FirstOrDefault();
            if (operation != null)
            {
                return Ok(operation);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<OperationsCreateDto> CreateOperation(OperationsCreateDto operationsCreateDto)
        {
            var operation = _mapper.Map<Operation>(operationsCreateDto);
            operation.Date = DateTime.Now;
            operation.IsSuccess = false;
            _operationsRepository.Create(operation);
            _operationsRepository.SaveChanges();

            var operationsReadDto = _mapper.Map<Operation>(operation);

            return CreatedAtRoute(nameof(GetOperationById), new { Id = operationsReadDto.Id }, operationsReadDto); //Return 201
        }

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