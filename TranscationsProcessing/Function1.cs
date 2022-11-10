using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TranscationsProcessing
{
    public class BackendTransaction
    {
        private IConfiguration _configuration;

        public BackendTransaction(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [FunctionName("BackendTransaction")]
        public void Run([ServiceBusTrigger("transactions", Connection = "SBConnectionString")] Transaction transaction, ILogger log)
        {
            try
            {
                string cmdString = "INSERT INTO Transactions (UserID,TransactionAmount,TransactionDateTime) VALUES (@UserID, @TransactionAmount, @TransactionDateTime)";
                string DBconnectionString = _configuration.GetConnectionString("BackendDBConnection");
                using (SqlConnection sqlConnection = new SqlConnection(DBconnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = cmdString;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Parameters.AddWithValue("@UserID", transaction.UserId);
                        sqlCommand.Parameters.AddWithValue("@TransactionAmount", transaction.Credit);
                        sqlCommand.Parameters.AddWithValue("@TransactionDateTime", DateTime.UtcNow.ToString());
                        try
                        {
                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            log.LogError(e.Message, e);
                        }
                        finally
                        {
                            sqlConnection.Close();
                        }
                    }

                }
            }
            catch (Exception x)
            {
                log.LogError(x.Message, x);

            }


        }
    }
    public class Transaction
    {
        public Guid UserId { get; set; }
        public decimal Credit { get; set; }
    }
}
