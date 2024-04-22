using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace MyWebSite1.DAL
{
    public class myDAL
    {
        private static readonly string connString =
           System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
        public DataSet SelectItem()
        {
            DataSet ds = new DataSet(); // Declare and instantiate a new dataset
            SqlConnection con = new SqlConnection(connString); // Declare and instantiate a new SQL connection
            con.Open(); // Open the SQL connection
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SELECT * FROM Items", con); // Instantiate SQL command cmd
                cmd.CommandType = CommandType.Text; // Set the type of SQL command
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds); // Add the result set returned from SqlCommand to ds
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds; // Return the dataset
        }

    }
}