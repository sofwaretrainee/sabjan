using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;


namespace MySql
{
    public partial class Register : System.Web.UI.Page
    {
        string _conString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        int _studentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            if (!IsPostBack)
            {
                try
                {
                    if (Session["Idlbl"] != null)
                    {
                        _studentId = Convert.ToInt32(Session["Idlbl"]);

                        var sql = "SELECT * FROM student_info WHERE student_id = '" + _studentId + "' ";

                        con.Open();

                        MySqlCommand cmd = new MySqlCommand(sql, con);

                        MySqlDataAdapter adapter = new MySqlDataAdapter();

                        adapter.SelectCommand = cmd;

                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            txtStudName.Text = dt.Rows[0]["student_name"].ToString();
                            string gender = dt.Rows[0]["student_gender"].ToString();
                            if (gender == "male")
                            {
                                radGender.SelectedIndex = 0;
                            }
                            else if (gender == "female")
                            {
                                radGender.SelectedIndex = 1;
                            }
                            txtMarks.Text = dt.Rows[0]["student_marks"].ToString();
                            txtPhone.Text = dt.Rows[0]["student_phone"].ToString();
                            txtAddress.Text = dt.Rows[0]["student_address"].ToString();
                        }
                    }
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
        protected void btnReg_Click(object sender, EventArgs e)
        {
           
            MySqlConnection con = new MySqlConnection(_conString);

            try
            {
                var sql = "INSERT INTO `student_db`.`student_info`(`student_name`,`student_gender`,`student_marks`,`student_phone`,student_address)VALUES('" + txtStudName.Text + "','" + radGender.SelectedItem.Value + "','" + Convert.ToDouble(txtMarks.Text) + "','" + Convert.ToInt64(txtPhone.Text) + "','" + txtAddress.Text + "')";

                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.InsertCommand = cmd;

                int result = cmd.ExecuteNonQuery();

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            _studentId = Convert.ToInt32(Session["Idlbl"]);
            try
            {
                if (Session["Idlbl"] != null)
                {
                    _studentId = Convert.ToInt32(Session["Idlbl"]);

                    var sql = "UPDATE `student_db`.`student_info`SET `student_name` = '" + txtStudName.Text + "',`student_gender` = '" + radGender.SelectedItem.Value + "',`student_marks` = '" + Convert.ToDouble(txtMarks.Text) + "',`student_phone` = '" + Convert.ToInt64(txtPhone.Text) + "',`student_address` = '" + txtAddress.Text + "' WHERE student_id = '" + _studentId + "' ";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    adapter.UpdateCommand = cmd;

                    int result = cmd.ExecuteNonQuery();
                    Response.Redirect("Retrive.aspx");
                }
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