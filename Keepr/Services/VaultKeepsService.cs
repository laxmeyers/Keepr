namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        private readonly VaultsService _vaultsService;
        private readonly KeepsService _keepsService;

        public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService, KeepsService keepsService)
        {
            _repo = repo;
            _vaultsService = vaultsService;
            _keepsService = keepsService;
        }

        internal List<VaultKeepSaved> GetKeepsInVault(int vaultId, string userId)
        {
            _vaultsService.GetVault(vaultId, userId);
            List<VaultKeepSaved> keeps = _repo.GetKeepsInVault(vaultId);
            return keeps;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
        {
            Vault vault = _vaultsService.GetVault(vaultKeepData.VaultId, vaultKeepData.CreatorId);
            _keepsService.GetKeep(vaultKeepData.KeepId);
            if (vault.CreatorId != vaultKeepData.CreatorId) throw new Exception("You can't add that here.");
            VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
            return vaultKeep;
        }

        internal VaultKeep DeleteVaultKeep(int id, string userId)
        {
            VaultKeep vaultKeep = this.GetVaultKeep(id);
            if (vaultKeep.CreatorId != userId) throw new Exception("You don't own this one.");
            _repo.DeleteVaultKeep(id);
            return vaultKeep;
        }


        internal VaultKeep GetVaultKeep(int id)
        {
            VaultKeep vaultKeep = _repo.GetVaultKeep(id);
            if (vaultKeep == null) throw new Exception("this vault isn't here.");
            return vaultKeep;
        }
    }
}