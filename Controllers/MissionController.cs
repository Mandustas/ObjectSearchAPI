using AutoMapper;
using DataLayer.Models;
using DataLayer.Repositories.Missions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;
        public MissionController(
            IMissionRepository missionRepository,
            IMapper mapper
            )
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<Mission> GetMissions()
        {
            var missions = _missionRepository.Get().ToList();

            return Ok(missions);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetMissionById")]
        public ActionResult<Target> GetMissionById(int id)
        {
            var mission = _missionRepository.GetById(id);
            if (mission != null)
            {
                return Ok(mission);
            }

            return NotFound();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<MissionCreateDto> CreateMission(MissionCreateDto missionCreateDto)
        {
            var mission = _mapper.Map<Mission>(missionCreateDto);
            _missionRepository.Create(mission);
            _missionRepository.SaveChanges();
            var missionReadDto = _mapper.Map<Mission>(mission);

            return CreatedAtRoute(nameof(GetMissionById), new { Id = missionReadDto.Id }, missionReadDto); //Return 201
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMission(int id)
        {
            var mission = _missionRepository.GetById(id);
            if (mission == null)
            {
                return NotFound();
            }

            _missionRepository.Delete(mission);
            _missionRepository.SaveChanges();
            return NoContent();
        }
    }
}
