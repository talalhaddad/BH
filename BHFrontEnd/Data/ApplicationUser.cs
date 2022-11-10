using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BHFrontEnd.Data
{

    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
   
}
