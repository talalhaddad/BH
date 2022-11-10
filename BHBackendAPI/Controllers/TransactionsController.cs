using BHBackendAPI.Database;
using BHBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BHBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly BHContext DBcontext;
        public TransactionsController(ILogger<TransactionsController> logger,BHContext dbContext)
        {
            _logger = logger;
            DBcontext = dbContext;
        }


        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public JsonResult Get(Guid id)
        {
            List<CustomerTransaction> data = DBcontext.Transactions.Where(x => x.UserID == id).Select(x => new CustomerTransaction { InitialCredit = x.TransactionAmount, TransactionDate = x.TransactionDateTime }).ToList();
            return new JsonResult { data = data, Balance= data.Sum(x=>x.InitialCredit) };
        }
    }
    public class JsonResult
    {
        public List<CustomerTransaction> data { get; set; }
        public decimal Balance { get; set; }
    }
}
