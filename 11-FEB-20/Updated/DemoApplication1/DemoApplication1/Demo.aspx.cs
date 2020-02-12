using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;


namespace DemoApplication1
{
    public partial class Demo : System.Web.UI.Page
    {
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        SqlDataAdapter adapter;
        String sql, Output = " ";
        int empID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Visible = true;
            //Button2.Visible = true;
            //btnUpdate.Visible = false;
            if (!IsPostBack)
            {
                //Button1.Visible = false;
                //Button2.Visible = true;
                //btnUpdate.Visible = true;
                try
                {
                    if (Session["empid"] != null)
                    {

                        empID = Convert.ToInt32(Session["empid"]);
                        //Session["empid"] = null;
                        //Request.QueryString.Clear();
                        connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=emp_db ;User ID= wmuser; Password= wmuser";

                        cnn = new SqlConnection(connetionString);

                        cnn.Open();



                        //sql = "Select * from dbo.emp_info where emp_id = empID";

                        //command = new SqlCommand(sql);

                        adapter = new SqlDataAdapter("Select * from dbo.emp_info where emp_id= '" + empID + "'", cnn);

                        DataSet ds = new DataSet();

                        adapter.Fill(ds, "dbo.emp_info");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            txtFirstName.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
                            TextBox3.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
                            TextBox4.Text = ds.Tables[0].Rows[0]["email"].ToString();
                            TextBox5.Text = ds.Tables[0].Rows[0]["password"].ToString();
                            TextBox6.Text = ds.Tables[0].Rows[0]["cpassword"].ToString();
                            //Radiobutton
                            string gender = ds.Tables[0].Rows[0]["gender"].ToString();
                            if (gender == "male")
                            {
                                RadioButtonList1.SelectedIndex = 0;
                            }
                            else if (gender == "female")
                            {
                                RadioButtonList1.SelectedIndex = 1;
                            }
                            string s = Convert.ToString(ds.Tables[0].Rows[0]["dob"]);
                            DateTime DOB = Convert.ToDateTime(s);
                            TextBox7.Text = DOB.ToString("yyyy-MM-dd");
                            TextBox8.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                            txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                        }





                    }
                }


                catch (Exception e1)
                {
                    Response.Write("Connection Unsuccessful!!!!!!");
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
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                //connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=employee_db ;User ID=wmuser; Password=wmuser";
                connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=emp_db ;User ID= wmuser; Password= wmuser";

                cnn = new SqlConnection(connetionString);

                cnn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                sql = "Insert into emp_info(first_name,last_name,email,password,cpassword,gender,dob,mobile,address) values('" + txtFirstName.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + RadioButtonList1.SelectedItem.Value + "','" + TextBox7.Text + "','" + Convert.ToInt64(TextBox8.Text) + "','" + txtAddress.Text + "')";
                //sql = "Insert into employee_info(empid,firstname,lastname,email,password,cpassword,gender,dob,mobile,address) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + RadioButtonList1.SelectedItem.Value + "','" + TextBox7.Text + "','" + Convert.ToInt64(TextBox8.Text) + "','" + txtAddress.Text + "')";
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                Response.Redirect("NewRegister.aspx");
            }
            catch (Exception e1)
            {
                Response.Write("Connection Unsuccessful!!!!!!");
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

        protected void Button2_Click(object sender, EventArgs e)
        {

            txtFirstName.Text = String.Empty;
            TextBox3.Text = String.Empty;
            TextBox4.Text = String.Empty;
            TextBox5.Text = String.Empty;
            TextBox6.Text = String.Empty;
            RadioButtonList1.Text = String.Empty;
            TextBox7.Text = String.Empty;
            TextBox8.Text = String.Empty;
            txtAddress.Text = String.Empty;

        }

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    //update logic
        //    try
        //    {
        //        //connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=employee_db ;User ID=wmuser; Password=wmuser";
        //        connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=emp_db ;User ID= wmuser; Password= wmuser";

        //        cnn = new SqlConnection(connetionString);

        //        cnn.Open();

        //        SqlDataAdapter adapter = new SqlDataAdapter();

        //        sql = "Update emp_info SET first_name = '" + TextBox2.Text + "' where empid= '" + TextBox1.Text + "'  ";

        //        command = new SqlCommand(sql, cnn);

        //        adapter.UpdateCommand = new SqlCommand(sql, cnn);
        //        adapter.UpdateCommand.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Update Unsuccessful!!!!!");
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            command.Dispose();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        try
        //        {
        //            if (cnn != null)
        //                cnn.Close();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //}

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    //delete logic
        //    try
        //    {
        //        connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=employee_db ;User ID=wmuser; Password=wmuser";

        //        cnn = new SqlConnection(connetionString);

        //        cnn.Open();

        //        SqlDataAdapter adapter = new SqlDataAdapter();

        //        sql = "Delete employee_info where empid= '" + TextBox9.Text + "'  ";

        //        command = new SqlCommand(sql, cnn);

        //        adapter.DeleteCommand = new SqlCommand(sql, cnn);
        //        adapter.DeleteCommand.ExecuteNonQuery();


        //    }
        //    catch(Exception ex)
        //    {
        //        Response.Write("Delete Unsuccessful!!!!!");
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            command.Dispose();
        //        }
        //        catch(Exception ex)
        //        {

        //        }
        //        try
        //        {
        //            if (cnn != null)
        //                cnn.Close();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //}

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //int empID = Convert.ToInt32(Request.QueryString["empID"]);
            empID = Convert.ToInt32(Session["empid"]);
            try
            {


                //connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=employee_db ;User ID=wmuser; Password=wmuser";
                connetionString = @"Server = NDVORSVR02\SQL2014;Initial Catalog=emp_db ;User ID= wmuser; Password= wmuser";

                cnn = new SqlConnection(connetionString);

                cnn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                sql = "Update emp_info SET first_name = '" + txtFirstName.Text + "',last_name = '" + TextBox3.Text + "',email ='" + TextBox4.Text + "' ,password ='" + TextBox5.Text + "',cpassword ='" + TextBox6.Text + "',mobile ='" + Convert.ToInt64(TextBox8.Text) + "',address ='" + txtAddress.Text + "' where emp_id= '" + empID + "'  ";

                command = new SqlCommand(sql, cnn);

                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                int res = adapter.UpdateCommand.ExecuteNonQuery();

                Response.Redirect("NewRegister.aspx");
            }
            catch (Exception ex)
            {

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