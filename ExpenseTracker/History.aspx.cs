using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace ExpenseTracker
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            call_this();

        }
        protected void call_this()
        {
            SqlConnection con = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString
            };
            try
            {
                using (con)
                {
                    string q = "select id,ename,edetails,eamount,edate from dbo.expenses where refid = '" + Session["userId"] + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    History1.DataSource = dr;
                    History1.DataBind();

                    dr.Close();
                }
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
            finally
            {
                con.Close();
            }
        }
        protected void History1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Response.Write(History1.DataKeys[e.RowIndex].Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString
                };
                con.Open();
                int rowi = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
                int eid = Convert.ToInt32(History1.Rows[rowi].Cells[1].Text);
                SqlCommand cmd = new SqlCommand("delete from expenses where id = '" + eid + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                call_this();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}