namespace Keepr.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Profile GetProfile(string id)
        {
            string sql = @"
            Select 
            * 
            from accounts 
            where id = @id;
            ";
            Profile profile = _db.Query<Profile>(sql, new { id }).FirstOrDefault();
            return profile;
        }
    }
}