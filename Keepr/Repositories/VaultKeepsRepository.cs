namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
        {
            string sql = @"
            Insert into vaultKeeps
            (creatorId, vaultId, keepId)
            values
            (@creatorId, @vaultId, @keepId);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            vaultKeepData.Id = id;
            return vaultKeepData;
        }

        internal int DeleteVaultKeep(int id)
        {
            string sql = @"
            Delete from vaultKeeps 
            where id = @id; 
            ";
            int rows = _db.Execute(sql, new { id });
            return rows;
        }

        internal List<VaultKeepSaved> GetKeepsInVault(int vaultId)
        {
            string sql = @"
            Select 
            vk.*,
            keepsCreator.*,
            k.*
            from vaultKeeps vk
            join keeps k on k.id = vk.keepId
            join accounts keepsCreator on keepsCreator.id = k.CreatorId
            where vk.vaultId = @vaultId;
            ";
            List<VaultKeepSaved> keeps = _db.Query<VaultKeep, Profile, VaultKeepSaved, VaultKeepSaved>(sql, (vk, prof, k) =>
            {
                k.Creator = prof;
                k.VaultKeepId = vk.Id;
                return k;

            }, new { vaultId }).ToList();
            return keeps;
        }

        internal VaultKeep GetVaultKeep(int id)
        {
            string sql = @"
            select 
            * 
            from vaultKeeps 
            where id = @id;
            ";
            VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
            return vaultKeep;
        }
    }
}