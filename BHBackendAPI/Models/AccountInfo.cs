namespace BHBackendAPI.Models
{
    public class AccountInfo
    {
        public Guid CustomerID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public decimal Balance { get; set; } 
    }
}
