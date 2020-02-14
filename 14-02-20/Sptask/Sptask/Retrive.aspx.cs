using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Sptask
{
    public partial class Register : System.Web.UI.Page
    {
        SqlDataAdapter adapter;
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        String sql, Output = " ";
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
                connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=student_db ;User ID= wmuser; Password= wmuser";
                System.Data.DataTable table = new System.Data.DataTable();
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                command = new SqlCommand();
                command.CommandText = "Student_Proc";
                command.Connection = cnn; 
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Event", "Select");
                
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                gvEmp.DataSource = table;
                gvEmp.DataBind();

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

        protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Edit")
            //{
            //    try
            //    {
            //        GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
            //        Label listPriceTextBox = (Label)clickedRow.FindControl("lblStudId");
            //        Session["listPriceTextBox"] = listPriceTextBox.Text;
            //        Response.Redirect("Register.aspx");
            //    }
            //    catch(Exception ex)
            //    {

            //    }

            //}
           if (e.CommandName == "Delete")
            {
                try
                {
                    GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                    Label listPriceTextBox = (Label)clickedRow.FindControl("lblStudId");
                    delete(listPriceTextBox);
                }
                catch (Exception ex)
                {

                }
            }
        }


        protected void lnkbtnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");

        }

        void delete(Label listPriceTextBox)
        {

            connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=student_db ;User ID= wmuser; Password= wmuser";
            System.Data.DataTable table = new System.Data.DataTable();
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            command = new SqlCommand();
            command.CommandText = "Student_Proc";
            command.Connection = cnn;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Event", "Delete");
            command.Parameters.AddWithValue("@Student_id", Convert.ToInt32(listPriceTextBox.Text));
            int result = Convert.ToInt32(command.ExecuteNonQuery());
            Response.Redirect("Retrive.aspx");
        }

        protected void gvEmp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int RowIndex = e.NewEditIndex;
            Label empid = (Label)gvEmp.Rows[RowIndex].FindControl("lblStudId");
            Session["empid"] = empid.Text;
            Response.Redirect("Register.aspx");
            
        }
        
    }
}