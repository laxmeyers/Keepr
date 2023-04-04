namespace Keepr.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth;

    public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vaultsService)
    {
        _accountService = accountService;
        _auth = auth0Provider;
        _vaultsService = vaultsService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(_accountService.GetOrCreateProfile(userInfo));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("vaults")]
    [Authorize]
    public async Task<ActionResult<List<Vault>>> GetMyVaults()
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<Vault> vaults = _vaultsService.GetMyvaults(userInfo.Id);
            return Ok(vaults);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<Account>> EditAccount([FromBody] Account accountdata)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            accountdata.Id = userInfo.Id;
            Account account = _accountService.Edit(accountdata, userInfo.Email);
            return Ok(account);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
