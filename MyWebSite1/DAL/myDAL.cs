using System;
using System.Data;
using System.Data.SqlClient;

namespace MyWebSite1.DAL
{
    public class myDAL
    {

        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;

        private SqlConnection conn; // Declare SqlConnection at the class level

        public myDAL()
        {
            conn = new SqlConnection(connString); // Initialize SqlConnection in the constructor
        }

        public DataSet SelectItem()
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open(); // Open the connection
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Items", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Close the connection in the finally block
            }

            return ds;
        }
    }
}
