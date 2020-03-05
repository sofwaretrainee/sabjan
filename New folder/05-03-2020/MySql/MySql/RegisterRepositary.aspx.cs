using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySql
{
    public partial class RegisterRepositary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnReg.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                if (Session["Idlbl"] != null)
                {

                    DBManager dbManager = (DBManager)Application["dbManager"];
                    int _studentId = Convert.ToInt16(Session["Idlbl"]);
                    IDbConnection con = null;
                    var parameters = new List<IDbDataParameter>();
                    parameters.Add(dbManager.CreateParameter("@Student_id", _studentId, DbType.Int32));
                    var data = dbManager.GetDataSet("Select_Student", CommandType.StoredProcedure, parameters.ToArray());

                    if (data.Tables[0].Rows.Count > 0)
                    {
                        txtStudName.Text = data.Tables[0].Rows[0]["student_name"].ToString();
                        radGender.SelectedValue = data.Tables[0].Rows[0]["student_gender"].ToString();
                        txtMarks.Text = data.Tables[0].Rows[0]["student_marks"].ToString();
                        txtPhone.Text = data.Tables[0].Rows[0]["student_phone"].ToString();
                        CountryDropdown.SelectedValue = data.Tables[0].Rows[0]["student_nationality"].ToString();
                        string address = data.Tables[0].Rows[0]["student_address"].ToString();
                        string[] spladd = address.Split(',');
                        txtAddress1.Text = spladd[0];
                        txtAddress2.Text = spladd[1];
                        txtAddress3.Text = spladd[2];
                    }
                    btnReg.Visible = false;
                    btnClear.Visible = false;
                    btnUpdate.Visible = true;
                }
                
            }
            
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            DBManager dbManager = (DBManager)Application["dbManager"];
             string addr1=txtAddress1.Text;
             string addr2=txtAddress2.Text;
             string addr = txtAddress1.Text + "," + txtAddress2.Text + "," + txtAddress3.Text;
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_name", txtStudName.Text, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", radGender.SelectedItem.Value, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", Convert.ToDouble(txtMarks.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_phone", Convert.ToInt64(txtPhone.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_Nationality", CountryDropdown.SelectedValue, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_address", addr, DbType.String));

            int lastId = 0;
            dbManager.Insert("Stud_Insert", CommandType.StoredProcedure, parameters.ToArray(), out lastId);
            Response.Redirect("RetriveStudent.aspx");

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DBManager dbManager = (DBManager)Application["dbManager"];
            int _studentId = Convert.ToInt16(Session["Idlbl"]);
            string addr = txtAddress1.Text + "," + txtAddress2.Text + "," + txtAddress3.Text;
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_id", _studentId, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Student_name", txtStudName.Text, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", radGender.SelectedItem.Value, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", Convert.ToDouble(txtMarks.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_phone", Convert.ToInt64(txtPhone.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_Nationality", CountryDropdown.SelectedValue, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_address", addr, DbType.String));

            int lastId = 0;
            dbManager.Update("Student_Update", CommandType.StoredProcedure, parameters.ToArray());
            Response.Redirect("RetriveStudent.aspx");
        }

        
    }
}