//7:10 min. 0:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PokeCenter.API.Base.DTOs;
using PokeCenter.API.Base.Services.Repositories;

namespace PokeCenter.API.Controllers
{
    [Route("api/teams/{teamId}/trainers")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        //Fields
        private readonly IPokeCenterRepository _pokeCenterRepository;
        private readonly IMapper _mapper;

        public TrainersController(IPokeCenterRepository pokeCenterRepository, IMapper mapper)
        {
            _pokeCenterRepository = pokeCenterRepository ??
                throw new ArgumentNullException(nameof(pokeCenterRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // Get Trainers For Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerDto>>> GetTrainers(
            int teamId)
        {
            if (!await _pokeCenterRepository.TeamExistsAsync(teamId))
            {
                //_Logger.LogInformation(
                //    $"Team with id {teamId} wasn't found when accessing points of interest.");
                return NotFound();
            }
            var trainersForTeam = await _pokeCenterRepository
                .GetTrainersForTeamAsync(teamId);

            return Ok(_mapper.Map<IEnumerable<TrainerDto>>(trainersForTeam));
        }

        // Get Trainer For Team
        [HttpGet("{trainerId}", Name = "GetTrainer")]
        public async Task<ActionResult<TrainerDto>> GetTrainer(
            int teamId, int trainerId)
        {
            if (!await _pokeCenterRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var trainer = await _pokeCenterRepository
                .GetTrainerForTeamAsync(teamId, trainerId);

            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TrainerDto>(trainer));
        }

        [HttpPost]
        public async Task<ActionResult<TrainerDto>> CreateTrainer(
            int teamId,
            TrainerNewDto trainer)
        {
            if (!await _pokeCenterRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var finalTrainer = _mapper.Map<Base.Entities.Trainer>(trainer);

            await _pokeCenterRepository.AddTrainerForTeamAsync(
                teamId, finalTrainer);

            await _pokeCenterRepository.SaveChangesAsync(); 

            var createdTrainerToReturn =
                _mapper.Map<Base.DTOs.TrainerDto>(finalTrainer);

            return CreatedAtRoute("GetTrainer",
                new
                {
                    teamId = teamId,
                    trainerId = createdTrainerToReturn.Id,
                },
                createdTrainerToReturn);
        }

        [HttpPut("{trainerid}")]
        public async Task<ActionResult> UpdateTrainer(
            int teamId, 
            int trainerId, 
            TrainerUpdateDto trainer)
        {
            if (!await _pokeCenterRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var trainerEntity = await _pokeCenterRepository
                .GetTrainerForTeamAsync(teamId, trainerId);
            if (trainerEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(trainer, trainerEntity);             //automapper overrides values from source (left) in the destination (right)

            await _pokeCenterRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{trainerid}")]
        public async Task<ActionResult> PartiallyUpdateTrainer(
        int teamId,
        int trainerId,
        JsonPatchDocument<TrainerUpdateDto> patchDocument)
        {
            if (!await _pokeCenterRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var trainerEntity = await _pokeCenterRepository
                .GetTrainerForTeamAsync(teamId, trainerId);
            if (trainerEntity == null)
            {
                return NotFound();
            }

            var trainerToPatch = _mapper.Map<TrainerUpdateDto>(trainerEntity);             //automapper overrides values from source (left) in the destination (right)

            patchDocument.ApplyTo(trainerToPatch, ModelState);

            if (!TryValidateModel(trainerToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(trainerToPatch, trainerEntity);
            await _pokeCenterRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{trainerid}")]
        public async Task<ActionResult> DeleteTrainer(
            int teamId, 
            int trainerId)
        {
            if (!await _pokeCenterRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var trainerEntity = await _pokeCenterRepository
                .GetTrainerForTeamAsync(teamId, trainerId);
            if(trainerEntity == null)
            {
                return NotFound();
            }

            _pokeCenterRepository.DeleteTrainer(trainerEntity);
            await _pokeCenterRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}