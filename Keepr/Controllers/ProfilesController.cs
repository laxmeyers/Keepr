namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;
        private readonly Auth0Provider _auth;

        public ProfilesController(ProfilesService profilesService, Auth0Provider auth, KeepsService keepsService, VaultsService vaultsService)
        {
            _profilesService = profilesService;
            _auth = auth;
            _keepsService = keepsService;
            _vaultsService = vaultsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfile(string id)
        {
            try
            {
                Profile profile = _profilesService.GetProfile(id);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> GetProfilesKeeps(string id)
        {
            try
            {
                List<Keep> keeps = _keepsService.GetProfilesKeeps(id);
                return keeps;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public async Task<ActionResult<List<Vault>>> GetProfilesVaults(string id)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                List<Vault> vaults = _vaultsService.GetProfilesVaults(id, userInfo?.Id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}