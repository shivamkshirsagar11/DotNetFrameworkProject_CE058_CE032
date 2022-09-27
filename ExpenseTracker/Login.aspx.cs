using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginerr.Text = "";

        }

        protected void Btnclick(object sender, EventArgs e)
        {
            string un = uname.Text;
            string psw = pass.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            try
            {
                using (con)
                {
                    string q = "select * from dbo.login where uname = '" + un +"' and pass = '"+psw+"'";
                    Console.WriteLine(un, psw);
                    SqlCommand cmd = new SqlCommand(q, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //Response.Write("Inside using conn");
                    if (dr.HasRows)
                    {
                        //Response.Write("inside if");
                        if (dr.Read())
                        {
                            Response.Write(dr[0].ToString()+" "+dr[1].ToString());
                            loginerr.Text = "User found!";
                        }
                    }
                    else
                    {
                        loginerr.Text = "No user found!";
                        //Response.Write("Inside else");
                    }
                    dr.Close();
                   
                }

            }
            catch (Exception exp)
            {
                Response.Write("Error: " + exp.Message);
            }

            finally
            {
               // Response.Write("In button click fxn");
                //loginerr.Text = "No messege, error";
            }
             
        }
    }
}