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
    public partial class Register1 : System.Web.UI.Page
    {
        SqlDataAdapter adapter;
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        String sql, Output = " ";
        int _studentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    if (Session["empid"] != null)
                    {

                        _studentId = Convert.ToInt32(Session["empid"]);
                        connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=student_db ;User ID= wmuser; Password= wmuser";

                        cnn = new SqlConnection(connetionString);

                        cnn.Open();

                        command = new SqlCommand();
                        command.CommandText = "Student_Proc";
                        command.Connection = cnn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Event", "SelectStu");
                        command.Parameters.AddWithValue("@Student_id", _studentId);
                        adapter = new SqlDataAdapter(command);

                       DataTable table = new DataTable();

                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {

                            txtStudName.Text = table.Rows[0]["student_name"].ToString();
                            string gender = table.Rows[0]["student_gender"].ToString();
                            if (gender == "male")
                            {
                                radGender.SelectedIndex = 0;
                            }
                            else if (gender == "FEMALE")
                            {
                                radGender.SelectedIndex = 1;
                            }
                            txtMarks.Text = table.Rows[0]["student_marks"].ToString();
                            txtPhone.Text = table.Rows[0]["student_phone"].ToString();
                            txtAddress.Text = table.Rows[0]["student_address"].ToString();  
                        }
                        btnReg.Visible = false;
                        btnClear.Visible = false;
                        btnUpdate.Visible = true;
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    if (cnn != null)
                        cnn.Close();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
              try
                {
                    if (Session["empid"] != null)
                    {

                        _studentId = Convert.ToInt32(Session["empid"]);
                        connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=student_db ;User ID= wmuser; Password= wmuser";

                        cnn = new SqlConnection(connetionString);

                        cnn.Open();
                        command = new SqlCommand();
                        command.CommandText = "Student_Proc";
                        command.Connection = cnn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Event", "Update");
                        command.Parameters.AddWithValue("@Student_id", _studentId);
                        command.Parameters.AddWithValue("@Student_name", Convert.ToString(txtStudName.Text.Trim()));
                        command.Parameters.AddWithValue("@Student_gender", Convert.ToString(radGender.Text.Trim()));
                        command.Parameters.AddWithValue("@Student_marks", Convert.ToString(txtMarks.Text.Trim()));
                        command.Parameters.AddWithValue("@Student_phone", Convert.ToString(txtPhone.Text.Trim()));
                        command.Parameters.AddWithValue("@Student_address", Convert.ToString(txtAddress.Text));
                        int result = Convert.ToInt32(command.ExecuteNonQuery());
                        Response.Redirect("Retrive.aspx");

                    }
                }


                catch (Exception ex)
                {

                }

                finally
                {
                    if (cnn != null)
                        cnn.Close();
                }
            }
       

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
               
                    connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=student_db ;User ID= wmuser; Password= wmuser";

                    cnn = new SqlConnection(connetionString);

                    cnn.Open();
                    command = new SqlCommand();
                    command.CommandText = "Student_Proc";
                    command.Connection = cnn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Event", "Insert");
                    //command.Parameters.AddWithValue("@Student_id", _studentId);
                    command.Parameters.AddWithValue("@Student_name", Convert.ToString(txtStudName.Text.Trim()));
                    command.Parameters.AddWithValue("@Student_gender", Convert.ToString(radGender.Text.Trim()));
                    command.Parameters.AddWithValue("@Student_marks", Convert.ToString(txtMarks.Text.Trim()));
                    command.Parameters.AddWithValue("@Student_phone", Convert.ToString(txtPhone.Text.Trim()));
                    command.Parameters.AddWithValue("@Student_address", Convert.ToString(txtAddress.Text));
                    int result = Convert.ToInt32(command.ExecuteNonQuery());
                    Response.Redirect("Retrive.aspx");
                    
                }
           


            catch (Exception ex)
            {

            }

            finally
            {
                if (cnn != null)
                    cnn.Close();
            }
        }
    }
}