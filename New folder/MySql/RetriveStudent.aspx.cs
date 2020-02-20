using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySql
{
    public partial class RetriveStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dbManager = new DBManager("constr");

            IDbConnection con = null;
            
            var data = dbManager.GetDataTable("Student_Select", CommandType.StoredProcedure);

            gvStudent.DataSource = data;

            gvStudent.DataBind();
            

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
        }

        void delete(Label Idlbl)
        {
            int _studentId = Convert.ToInt32(Idlbl.Text);
            var dbManager = new DBManager("constr");

            var parameters  = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_id", _studentId, DbType.Int32));
            dbManager.Delete("Student_Delete", CommandType.StoredProcedure,parameters.ToArray());
        }

        protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}