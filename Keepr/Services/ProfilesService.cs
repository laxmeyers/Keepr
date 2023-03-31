namespace Keepr.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        internal Profile GetProfile(string id)
        {
            Profile profile = _repo.GetProfile(id);
            if (profile == null) throw new Exception("This person doesn't exist.");
            return profile;
        }
    }
}