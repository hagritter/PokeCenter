using PokeCenter.API.Base.Entities;

namespace PokeCenter.API.Base.Services.Repositories
{

    //Contract of the Pokecenter Repository interface
    public interface IPokeCenterRepository
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<Team?> GetTeamAsync(int teamId, bool includeTrainer);
        Task<bool> TeamExistsAsync(int teamId);

        Task<IEnumerable<Trainer>> GetTrainersForTeamAsync(int teamId);
        Task<Trainer?> GetTrainerForTeamAsync(int teamId, int trainerId);
        Task AddTrainerForTeamAsync(int teamId, Trainer trainer);
        //Task UpdateTrainerForTeamAsync(int teamId, int trainerId, Trainer trainer);
        void DeleteTrainer(Trainer trainer); 
        Task<bool> SaveChangesAsync();


    }
}
