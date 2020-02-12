using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DemoApplication1
{
    public partial class NewRegister : System.Web.UI.Page
    {
        SqlDataAdapter adapter;
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        String sql, Output = " ";
        int empID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateOp();
                
            }
            
        }
        void CreateOp()
        {
            try
            {
                connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=emp_db ;User ID= wmuser; Password= wmuser";
                DataTable table = new DataTable();
                sql = "Select * from dbo.emp_info";
                cnn = new SqlConnection(connetionString);

                cnn.Open();

                adapter = new SqlDataAdapter(sql, cnn);
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                try
                {
                    if (cnn != null)
                        cnn.Close();
                }
                catch (Exception ex)
                {

                }
            }

        }

        //protected void GridView1_RowDeleting(object sender, GridViewCommandEventArgs e)
        //{
        //       if (e.CommandName == "Delete")
        //        {
                    
        //        }   
        //}

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                int RowIndex = e.NewEditIndex;
                Label empid = (Label)GridView1.Rows[RowIndex].FindControl("lblEmpId");
                //Response.Redirect("Demo.aspx?empID=" + empid.Text);
                Session["empid"] = empid.Text;  
                Response.Redirect("Demo.aspx");
               
            }
            catch (Exception ex) { }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                Label empid = (Label)GridView1.Rows[index].FindControl("lblEmpId");
                Session["empid"] = empid.Text;
                deleteUser();
                
            }
           catch(Exception ex)
            {

            }
        }

        protected void deleteUser()
        {
            empID = Convert.ToInt32(Session["empid"]);
            try
            {

                connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=emp_db ;User ID= wmuser; Password= wmuser";

                cnn = new SqlConnection(connetionString);

                cnn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                  sql = "Delete emp_info where emp_id = "+empID+" ";

                command = new SqlCommand(sql, cnn);

                adapter.DeleteCommand = new SqlCommand(sql, cnn);
                int res = adapter.DeleteCommand.ExecuteNonQuery();
                Response.Redirect("NewRegister.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("Delete Unsuccessful!!!!!");
            }
            finally
            {
                try
                {
                    command.Dispose();
                }
                catch (Exception ex)
                {

                }
                try
                {
                    if (cnn != null)
                        cnn.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
       

    }


}

