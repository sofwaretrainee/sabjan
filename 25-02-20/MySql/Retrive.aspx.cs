
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySql
{
    public partial class Retrive : System.Web.UI.Page
    {
        string _conString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            
                try
                {
                    var sql = "SELECT * FROM student_info";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    adapter.SelectCommand = cmd;

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    gvStudent.DataSource = dt;

                    gvStudent.DataBind();
                }
                catch (Exception ex)
                {

                }

                finally
                {
                    if (con != null)
                        con.Close();
                }

        }
        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void gvStudent_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
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
                Response.Redirect("Register.aspx");
            }
        }
        protected void delete(Label Idlbl)
        {

            int _stuId = Convert.ToInt32(Idlbl.Text);

            MySqlConnection con = new MySqlConnection(_conString);
            try
            {
                var sql = "DELETE FROM `student_db`.`student_info` WHERE student_id = '" + _stuId + "' ";

                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                Response.Redirect("Retrive.aspx");
            }

            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }



        }
    }
}