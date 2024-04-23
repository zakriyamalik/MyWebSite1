using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyWebSite1.DAL;
namespace MyWebSite1
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Search_Button_Click(object sender, EventArgs e)
        {
            string Name = TextBox1.Text;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL(); // Asumiendo que "MyDAL" es el nombre de tu clase de acceso a datos

            int found;
            found = objMyDal.SearchItem(Name, ref DT);

            if (found > 0)
            {
                ItemGrid.DataSource = DT;
                ItemGrid.DataBind();
                message.InnerHtml = Convert.ToString("Following Items Found");
            }
            else
            {
                message.InnerHtml = "Item Not Found";
                ItemGrid.DataSource = null;
                ItemGrid.DataBind();
            }
        }

    }
}