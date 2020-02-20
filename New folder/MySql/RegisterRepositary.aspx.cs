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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}