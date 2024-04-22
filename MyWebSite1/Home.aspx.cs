using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite1.DAL;

namespace MyWebSite1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Check if the page is loaded for the first time
            {
                LoadGrid(); // Fill the grid only on the first load
            }
        }

        // The LoadGrid() function retrieves data from the database and populates the grid
        public void LoadGrid()
        {
            myDAL objMyDal = new myDAL();
            ItemGrid.DataSource = objMyDal.SelectItem();
            ItemGrid.DataBind(); // Bind the data source to the grid
        }
    }
}
