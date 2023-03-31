namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        private readonly ProfilesService _profilesService;

        public KeepsService(KeepsRepository repo, ProfilesService profilesService)
        {
            _repo = repo;
            _profilesService = profilesService;
        }

        internal Keep CreateKeep(Keep keepData)
        {
            Keep keep = _repo.CreateKeep(keepData);
            return keep;
        }

        internal Keep DeleteKeep(int id, string userId)
        {
            Keep original = this.GetKeep(id);
            if (original.CreatorId != userId) throw new Exception("this isn't yours.");
            int rows = _repo.DeleteKeep(id);
            return original;
        }

        internal Keep EditKeep(Keep keepData)
        {
            Keep original = this.GetKeep(keepData.Id);
            if (original.CreatorId != keepData.CreatorId) throw new Exception($"You don't own {keepData.Name}");

            original.Name = keepData.Name != null ? keepData.Name : original.Name;
            original.Kept = keepData.Kept != null ? keepData.Kept : original.Kept;
            original.Description = keepData.Description != null ? keepData.Description : original.Description;
            original.Img = keepData.Img != null ? keepData.Img : original.Img;
            original.Views = keepData.Views != null ? keepData.Views : original.Views;

            _repo.EditKeep(original);
            return original;
        }

        internal List<Keep> GetAllKeeps()
        {
            List<Keep> keeps = _repo.GetAllKeeps();
            return keeps;
        }

        internal Keep GetKeep(int id)
        {
            Keep keep = _repo.GetKeep(id);
            if (keep == null) throw new Exception($"This keep doesn't exist at {id}");
            return keep;
        }

        internal List<Keep> GetProfilesKeeps(string profileId)
        {
            _profilesService.GetProfile(profileId);
            List<Keep> keeps = _repo.GetProfilesKeeps(profileId);
            return keeps;
        }
    }
}