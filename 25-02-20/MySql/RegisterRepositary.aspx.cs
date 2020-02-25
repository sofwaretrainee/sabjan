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
                if (Session["Idlbl"] != null)
                {

                    var dbManager = new DBManager("constr");
                    int _studentId = Convert.ToInt16(Session["Idlbl"]);
                    IDbConnection con = null;
                    var parameters = new List<IDbDataParameter>();
                    parameters.Add(dbManager.CreateParameter("@Student_id", _studentId, DbType.Int32));
                    var data = dbManager.GetDataSet("Select_Student", CommandType.StoredProcedure, parameters.ToArray());

                    if (data.Tables[0].Rows.Count >= 0)
                    {
                        txtStudName.Text = data.Tables[0].Rows[0]["student_name"].ToString();
                        string gender = data.Tables[0].Rows[0]["student_gender"].ToString();
                        if (gender == "male")
                        {
                            radGender.SelectedIndex = 0;
                        }
                        else if (gender == "female")
                        {
                            radGender.SelectedIndex = 1;
                        }
                        txtMarks.Text = data.Tables[0].Rows[0]["student_marks"].ToString();
                        txtPhone.Text = data.Tables[0].Rows[0]["student_phone"].ToString();
                        txtAddress.Text = data.Tables[0].Rows[0]["student_address"].ToString();

                    }
                }
            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            var dbManager = new DBManager("constr");

            //Student student = new Student
            //{
            //    _studentName = txtStudName.Text,
            //    _studentGender = radGender.SelectedItem.Value,
            //    _studentMarks = Convert.ToDouble(txtMarks.Text),
            //    _studentPhone = Convert.ToInt64(txtPhone),
            //    _studentAddress = txtAddress.Text
            //};
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_name", txtStudName.Text, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", radGender.SelectedItem.Value, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", Convert.ToDouble(txtMarks.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_phone", Convert.ToInt64(txtPhone.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_address", txtAddress.Text, DbType.String));

            int lastId = 0;
            dbManager.Insert("Stud_Insert", CommandType.StoredProcedure, parameters.ToArray(), out lastId);
            Response.Redirect("RetriveStudent.aspx");

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var dbManager = new DBManager("constr");
            int _studentId = Convert.ToInt16(Session["Idlbl"]);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_id", _studentId, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Student_name", txtStudName.Text, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", radGender.SelectedItem.Value, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", Convert.ToDouble(txtMarks.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_phone", Convert.ToInt64(txtPhone.Text), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_address", txtAddress.Text, DbType.String));

            int lastId = 0;
            dbManager.Update("Student_Update", CommandType.StoredProcedure, parameters.ToArray());
            Response.Redirect("RetriveStudent.aspx");
        }
    }
}