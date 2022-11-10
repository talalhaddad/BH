using BHBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BHBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly ILogger<AccountInfoController> _logger;

        public AccountInfoController(ILogger<AccountInfoController> logger)
        {
            _logger = logger;
        }

        // GET api/<AccountInfoController>/5
        [HttpGet("{id}")]
        public AccountInfo Get(Guid id)
        {
            return new AccountInfo
            {
                CustomerID = Guid.Parse("18c03cf7-10f6-4a53-bb66-4e5462ece222"),
                Balance = 500,
                Name = "Talal",
                SurName = "Haddad"                
            };
        }
    }
}
