using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySql
{
    public partial class DBConnection : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBManager dbManager = null;


            if (DropDownList1.SelectedValue == "mysql")
            {
                dbManager = new DBManager("constr");
            }
            else if (DropDownList1.SelectedValue == "mssql")
            {
                dbManager = new DBManager("constring");
            }

            Application["dbManager"] = dbManager;
        }
    }
}