using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Models;
using DataLayer.Repositories.Targets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/target")]
    [ApiController]


    public class TargetController : ControllerBase
    {
        enum TargetStatuses
        {
            Finded = 1,
            Attention = 2,
            NotFound = 3

        }

        // GET: api/<TargetController>
        private readonly ITargetRepository _targetRepository;
        private readonly IMapper _mapper;
        public TargetController(
            ITargetRepository targetRepository,
            IMapper mapper
            )
        {
            _targetRepository = targetRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Target>> GetTarget()
        {
            var targets = _targetRepository.Get().ToList();
            return Ok(targets);
        }

        [HttpGet("{id}", Name = "GetTargetById")]
        public ActionResult<Target> GetTargetById(int id)
        {
            var target = _targetRepository.GetById(id);
            if (target != null)
            {
                return Ok(target);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<TargetCreateDto> CreateTarget(TargetCreateDto targetCreateDto)
        {
            var target = _mapper.Map<Target>(targetCreateDto);
            target.TargetStatusId = (int)TargetStatuses.NotFound;
            _targetRepository.Create(target);
            _targetRepository.SaveChanges();

            var targetReadDto = _mapper.Map<Target>(target);


            return CreatedAtRoute(nameof(GetTargetById), new { Id = targetReadDto.Id }, targetReadDto); //Return 201
        }

        [HttpPut("{id}")]
        public ActionResult<Target> UpdateTarget(int id, TargetUpdateDto targetUpdateDto)
        {
            var target = _targetRepository.GetById(id);
            if (target == null)
            {
                return NotFound();
            }

            _mapper.Map(targetUpdateDto, target);
            _targetRepository.Update(target); //Best practice
            _targetRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTarget(int id)
        {
            var target = _targetRepository.GetById(id);
            if (target == null)
            {
                return NotFound();
            }

            _targetRepository.Delete(target);
            _targetRepository.SaveChanges();
            return NoContent();
        }
    }
}
