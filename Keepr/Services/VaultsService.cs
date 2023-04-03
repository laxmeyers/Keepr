namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        private readonly ProfilesService _profilesService;

        public VaultsService(VaultsRepository repo, ProfilesService profilesService)
        {
            _repo = repo;
            _profilesService = profilesService;
        }

        internal Vault CreateVault(Vault vaultData)
        {
            Vault vault = _repo.CreateVault(vaultData);
            return vault;
        }

        internal Vault DeleteVault(int id, string userId)
        {
            Vault vault = this.GetVault(id, userId);
            if (vault.CreatorId != userId) throw new Exception("this is not yours");
            _repo.DeleteVault(id);
            return vault;
        }

        internal Vault EditVault(Vault vaultData)
        {
            Vault original = this.GetVault(vaultData.Id, vaultData.CreatorId);

            if (original.CreatorId != vaultData.CreatorId) throw new Exception("this is not yours");

            original.Name = vaultData.Name != null ? vaultData.Name : original.Name;
            original.IsPrivate = vaultData.IsPrivate != null ? vaultData.IsPrivate : original.IsPrivate;
            _repo.EditVault(original);
            return original;

        }

        internal List<Vault> GetMyvaults(string userId)
        {
            List<Vault> vaults = _repo.GetMyVaults(userId);
            return vaults;
        }

        internal List<Vault> GetProfilesVaults(string profileId, string userId)
        {
            _profilesService.GetProfile(profileId);
            List<Vault> vaults = _repo.GetProfilesVaults(profileId);
            if(profileId != userId){
            vaults = vaults.FindAll(v => v.IsPrivate == false);
            }else{
                return vaults;
            }
            return vaults;

        }

        internal Vault GetVault(int id, string userId)
        {
            Vault vault = _repo.GetVault(id);
            if (vault == null) throw new Exception("There is no vault here.");
            if (vault.IsPrivate == true && vault.CreatorId != userId) throw new Exception("You can't see that.");
            return vault;
        }
    }
}