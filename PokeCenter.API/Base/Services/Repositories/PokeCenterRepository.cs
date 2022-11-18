using Microsoft.EntityFrameworkCore;
using PokeCenter.API.Base.DbContexts;
using PokeCenter.API.Base.Entities;
using System.Diagnostics.Contracts;

namespace PokeCenter.API.Base.Services.Repositories
{
    public class PokeCenterRepository : IPokeCenterRepository
    {
        private readonly PokeCenterContext _context;

        //Constructor (injects the PokeCenterContext via Constructor injection)
        public PokeCenterRepository(PokeCenterContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //+++Contracts implementation (provides persistence logic)+++

        // Get Team
        public async Task<Team?> GetTeamAsync(int TeamId, bool includeTrainer)
        {
            if (includeTrainer)
            {
                return await this._context.Teams.Include(te => te.Trainers)
                    .Where(te => te.Id == TeamId).FirstOrDefaultAsync();
            }

            return await this._context.Teams
                .Where(te => te.Id == TeamId).FirstOrDefaultAsync();
        }

        // Get Teams
        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await this._context.Teams.OrderBy(c => c.Name).ToListAsync();
        }

        // Team exists?
        public async Task<bool> TeamExistsAsync(int teamId)
        {
            return await this._context.Teams.AnyAsync(te => te.Id == teamId);
        }

        // Get Trainers For Team
        public async Task<IEnumerable<Trainer>> GetTrainersForTeamAsync(
            int teamId)
        {
            return await this._context.Trainers
                .Where(tr => tr.TeamId == teamId).ToListAsync();
        }

        // Get Trainer For Team
        public async Task<Trainer?> GetTrainerForTeamAsync(
            int teamId, int trainerId)
        {
            return await this._context.Trainers
                .Where(tr => tr.TeamId == teamId && tr.Id == trainerId)
                .FirstOrDefaultAsync();
        }

        // Post Trainer
        public async Task AddTrainerForTeamAsync(int teamId, Trainer trainer)
        {
            var team = await GetTeamAsync(teamId, false);
            if (team != null)
            {
                team.Trainers.Add(trainer);
            }
        }

        //// Put Trainer
        //public async Task UpdateTrainerForTeamAsync(int teamId, int trainerId, Trainer trainer)
        //{
        //    var trainerToUpdate = await GetTrainerForTeamAsync(trainerId, teamId);
        //}

        // Delete Trainer
        public void DeleteTrainer(Trainer trainer)
        {
            _context.Trainers.Remove(trainer);
        }



        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
