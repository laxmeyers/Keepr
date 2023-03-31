namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Vault CreateVault(Vault vaultData)
        {
            string sql = @"
            Insert into vaults
            (name, description, isPrivate, img, creatorId)
            values
            (@name, @description, @isPrivate, @img, @creatorId);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }

        internal int DeleteVault(int id)
        {
            string sql = @"
            Delete 
            from vaults 
            where id = @id;
            ";
            int rows = _db.Execute(sql, new { id });
            return rows;
        }

        internal int EditVault(Vault original)
        {
            string sql = @"
            Update vaults
            set
            id = @id,
            name = @name,
            description = @description,
            img = @img,
            isPrivate = @isPrivate
            where id = @id;
            ";
            int rows = _db.Execute(sql, original);
            return rows;
        }

        internal List<Vault> GetMyVaults(string userId)
        {
            string sql = @"
            Select 
            vaults.*,
            creator.* 
            from vaults
            join accounts creator on creator.id = vaults.creatorId
            where creatorId = @userId;
            ";
            List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, creator) =>
            {
                vault.Creator = creator;
                return vault;
            }, new { userId }).ToList();
            return vaults;
        }

        internal List<Vault> GetProfilesVaults(string profileId)
        {
            string sql = @"
            Select 
            * 
            from vaults 
            where creatorId = @profileId;
            ";

            List<Vault> vaults = _db.Query<Vault>(sql, new { profileId }).ToList();
            return vaults;
        }

        internal Vault GetVault(int id)
        {
            string sql = @"
            Select 
            v.*,
            creator.* 
            from vaults v 
            join accounts creator on creator.id = v.creatorid
            where v.id = @id;
            ";
            Vault vault = _db.Query<Vault, Profile, Vault>(sql, (v, creator) =>
            {
                v.Creator = creator;
                return v;
            }, new { id }).FirstOrDefault();
            return vault;
        }
    }
}