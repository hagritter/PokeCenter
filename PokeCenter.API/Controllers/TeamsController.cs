// stopped at 7.8 min. 3:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

// using PokeCenter.API.Models;
using Microsoft.AspNetCore.Mvc;
using PokeCenter.API.Base.DTOs;
using PokeCenter.API.Base.Services.Repositories;

namespace PokeCenter.API.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        //Fields
        private readonly IPokeCenterRepository _pokeCenterRepository;
        private readonly IMapper _mapper;

        public TeamsController(IPokeCenterRepository pokeCenterRepository, IMapper mapper)
        {
            _pokeCenterRepository = pokeCenterRepository ??
                throw new ArgumentNullException(nameof(pokeCenterRepository));
            this._mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamWithoutTrainersDto>>> GetTeams()
        {
            var teamEntities = await _pokeCenterRepository.GetTeamsAsync();
            return Ok(_mapper.Map<IEnumerable<TeamWithoutTrainersDto>>(teamEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id, bool includeTrainers = false)
        {
            var team = await _pokeCenterRepository.GetTeamAsync(id, includeTrainers);
            if (team == null)
            {
                return NotFound();
            }

            if (includeTrainers)
            {
                return Ok(_mapper.Map<TeamDto>(team));
            }

            return Ok(_mapper.Map<TeamWithoutTrainersDto>(team));
        }
    }
}