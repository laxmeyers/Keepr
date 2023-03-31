namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep CreateKeep(Keep keepData)
        {
            string sql = @"
            Insert into keeps
            (name, description, img, creatorId)
            values
            (@name, @description, @img, @creatorId);
            Select Last_Insert_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, keepData);
            keepData.Id = id;
            return keepData;
        }

        internal int DeleteKeep(int id)
        {
            string sql = @"
            Delete 
            from keeps 
            where id = @id;
            ";

            int rows = _db.Execute(sql, new { id });
            return rows;
        }

        internal int EditKeep(Keep original)
        {
            string sql = @"
            Update keeps
            set
            id = @id,
            name = @name,
            description = @description,
            creatorId = @creatorId,
            img = @img,
            views = @views
            where id = @id;
            ";
            int rows = _db.Execute(sql, original);
            return rows;
        }

        internal List<Keep> GetAllKeeps()
        {
            string sql = @"
            Select 
            k.*,
            acct.* 
            from keeps k
            join accounts acct on acct.id = k.creatorId;
            ";
            List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (k, prof) =>
            {
                k.Creator = prof;
                return k;
            }).ToList();
            return keeps;
        }

        internal Keep GetKeep(int id)
        {
            string sql = @"
            Select 
            k.*,
            acct.* 
            from keeps k
            join accounts acct on acct.id = k.creatorId
            where k.id = @id;
            ";
            Keep keep = _db.Query<Keep, Profile, Keep>(sql, (k, prof) =>
            {
                k.Creator = prof;
                return k;
            }, new { id }).FirstOrDefault();
            return keep;
        }

        internal List<Keep> GetProfilesKeeps(string profileId)
        {
            string sql = @"
            Select 
            * 
            from keeps 
            where creatorId = @profileId;
            ";

            List<Keep> keeps = _db.Query<Keep>(sql, new { profileId }).ToList();
            return keeps;
        }
    }
}