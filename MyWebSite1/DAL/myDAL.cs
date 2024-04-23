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

                using (SqlCommand cmd = new SqlCommand("SELECT i.item_number AS ItemNumber, n.name AS ItemName, tu.total_units AS TotalUnits FROM    itemno i  INNER JOIN itemname n ON i.id = n.id   INNER JOIN totalunits tu ON i.id = tu.item_id;", conn))
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
        public int SearchItem(string name, ref DataTable dt)
        {
            int found = 0;
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("spsearchitems", con)) // Assuming "searchitems" is the name of your stored procedure
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, 15).Value = name;
                    cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                    try
                    {
                        cmd.ExecuteNonQuery(); // Execute the stored procedure
                        //found = Convert.ToInt32(cmd.Parameters["@found"].Value); // Convert the output parameter to an integer
                        //if (found == 1)
                        //{
                        //    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        //    {
                        //        da.Fill(ds);
                        //        dt = ds.Tables[0];
                        //    }
                        //}
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                }
            }

            return found;
        }

    }
}
