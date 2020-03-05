using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql;

namespace MySql
{
    
    public partial class RetriveStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["dbManager"] != null)
                {
                    DropDownList1.SelectedValue = Application["selecetdDB"].ToString();
                    Application["dbManager"] = null;
                    DropDownList1_SelectedIndexChanged(null, null);
                }
            }
        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterRepositary.aspx");
        }

        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Delete"))
            {
                GridViewRow row = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label Idlbl = (Label)row.FindControl("lblStudentId");
                delete(Idlbl);
            }
            else if (e.CommandName.Equals("Update"))
            {
                GridViewRow row = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label Idlbl = (Label)row.FindControl("lblStudentId");
                Session["Idlbl"] = Idlbl.Text;
                Response.Redirect("RegisterRepositary.aspx");
            }
        }

        void delete(Label Idlbl)
        {
            int _studentId = Convert.ToInt32(Idlbl.Text);
            //var dbManager = new DBManager("constr");

            DBManager dbManager = (DBManager)Application["dbManager"];
            var parameters  = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_id", _studentId, DbType.Int32));
            dbManager.Delete("Student_Delete", CommandType.StoredProcedure,parameters.ToArray());
            Response.Redirect("RetriveStudent.aspx");
        }

        protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBManager dbManager =null;


            if (DropDownList1.SelectedValue == "mysql")
            {
                 dbManager = new DBManager("constr");
            }
            else if (DropDownList1.SelectedValue == "mssql")
            {
                 dbManager = new DBManager("constring");
            }
            loadGrid(dbManager);
            Application["dbManager"] = dbManager;
            Application["selecetdDB"] = DropDownList1.SelectedValue;
        }

        private void loadGrid(DBManager connectionString)
         {
            var dbManager = connectionString;

            //IDbConnection con = null;

            var data = dbManager.GetDataTable("Student_Select", CommandType.StoredProcedure);

            gvStudent.DataSource = data;

            gvStudent.DataBind();
        }
        
    }
}