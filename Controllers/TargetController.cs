﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataLayer.Models;
using DataLayer.Repositories.Targets;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DataLayer.Repositories.Operations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/target")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TargetController : ControllerBase
    {
        enum TargetStatuses
        {
            Finded = 1,
            Attention = 2,
            NotFound = 3
        }

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private readonly ITargetRepository _targetRepository;
        private readonly IOperationsRepository _operationRepository;
        private readonly IMapper _mapper;
        public TargetController(
            ITargetRepository targetRepository,
            IOperationsRepository operationRepository,
            IMapper mapper
            )
        {
            _targetRepository = targetRepository;
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Target>> GetTarget()
        {
            var targets = _targetRepository.Get().ToList();
            return Ok(targets);
        }

        [HttpGet("User/{iduser}", Name = "GetForUser")]
        public ActionResult<IEnumerable<Target>> GetForUser(int iduser)
        {
            var targets = _targetRepository.GetByUserId(iduser);
            if (targets != null)
                return Ok(targets);
            else
                return NotFound();
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

        [Authorize(Roles = "Координатор ПСР")]
        [HttpPost]
        public ActionResult<TargetCreateDto> CreateTarget(TargetCreateDto targetCreateDto)
        {
            var target = _mapper.Map<Target>(targetCreateDto);
            target.TargetStatusId = (int)TargetStatuses.NotFound;
            target.LostTime = targetCreateDto.LostTime.ToLocalTime();
            target.OperationId = _operationRepository.GetActiveOperationId(UserId);
            _targetRepository.Create(target);
            _targetRepository.SaveChanges();

            var targetReadDto = _mapper.Map<Target>(target);


            return CreatedAtRoute(nameof(GetTargetById), new { Id = targetReadDto.Id }, targetReadDto); //Return 201
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Координатор ПСР")]

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

        [Authorize(Roles = "Координатор ПСР")]
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
