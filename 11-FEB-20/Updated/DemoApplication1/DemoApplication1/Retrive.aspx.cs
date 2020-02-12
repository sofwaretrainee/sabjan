using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DemoApplication1
{
    public partial class Retrive : System.Web.UI.Page
    {
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        String sql, Output = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=employee_db ;User ID=wmuser; Password=wmuser";

                cnn = new SqlConnection(connetionString);

                cnn.Open();


                sql = "Select * from employee_info";

                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();

                GridView1.DataSource = dataReader;
                GridView1.DataBind();
                //while (dataReader.Read())
                //{
                //    Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "</br>"
                //                    + dataReader.GetValue(2) + "-" + dataReader.GetValue(3) + "-" + "</br>"
                //                    + dataReader.GetValue(4) + "-" + dataReader.GetValue(5) + "-" + "</br>"
                //                    + dataReader.GetValue(6) + "-" + dataReader.GetValue(7) + "-" + "</br>"
                //                    + dataReader.GetValue(8) + "</br>";
                //}

                //Response.Write(Output);

            }
            catch (Exception e1)
            {
                Response.Write("Connection Unsuccessful!!!!!!");
            }
            finally
            {
                try
                {

                    dataReader.Close();
                }
                catch (Exception ex)
                {

                }
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Demo.aspx");
        }
       
    }
}