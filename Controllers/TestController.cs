using azurecSharpDemo.keyVault;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IKeyVaultManager _secretManager;

        public TestController(IKeyVaultManager secretManager)
        {
            _secretManager = secretManager;
        }

        [HttpGet(Name = "GetSecretName")]
        public async Task<IActionResult> GetSecretName([FromQuery] string secretName)
        {
            try
            {
                if (string.IsNullOrEmpty(secretName))
                {
                    return BadRequest();
                }

                string secretValue = await

                _secretManager.GetSecret(secretName);

                if (!string.IsNullOrEmpty(secretValue))
                {
                    return Ok(secretValue);
                }

                else
                {
                    return NotFound("Secret key not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: Unable to read secret");
            }
        }
      
    }
}
