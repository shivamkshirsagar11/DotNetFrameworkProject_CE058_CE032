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

        }

        protected void btnclick(object sender, EventArgs e)
        {
            string un = uname.Text;
            string psw = pass.Text;
            string q = "select from login";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LoginDB"].ConnectionString;

            try
            {
                using (con)
                {

                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
             
        }
    }
}