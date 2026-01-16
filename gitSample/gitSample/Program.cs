using Microsoft.Data.SqlClient;
using System.Data;

namespace gitSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Server=(localdb)\\mssqllocaldb;Database=blogdb;TrustServerCertificate=True;";
            string sql = @"SELECT TOP (1000)  
                              [Qty]
                               ,[Name]
                          FROM [blogdb].[dbo].[LockDemo]";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlBulkCopy bulk = new SqlBulkCopy(
                    conn,
                    SqlBulkCopyOptions.KeepIdentity,
                    null))
                {
                    bulk.DestinationTableName = "dbo.LockDemo";
                    bulk.BatchSize = 5000;
                    bulk.BulkCopyTimeout = 60;

                    //bulk.ColumnMappings.Add("Name", "Name");
                    //bulk.ColumnMappings.Add("Qty", "Qty");
   

                    bulk.WriteToServer(dt);
                }
            }

        }
    }
}
