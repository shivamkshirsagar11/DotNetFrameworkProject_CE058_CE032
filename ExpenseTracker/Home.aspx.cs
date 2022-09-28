using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool)Session["authUser"])
            {
                Session["cmnMsg"] = "Un-Authorised User!";
                Response.Redirect("Login.aspx");
            }
        }

        protected string RandomString(string date)
        {
           
            return "Expense_Pack_clusterRefDate_" + date +"_UI_"+ Session["userId"];
        }

        protected void AddExpense(object sender, EventArgs e)
        {
            string en = ename.Text;
            string ed = edetail.Text;
            float amount = float.Parse(eamount.Text);
            string givenDate = edate.Text.Split('T')[0];
            string todayDate = DateTime.Now.ToString().Split(' ')[0];
            string cid = "";
            //bool isSameDateToday = DateTime.Compare(DateTime.Parse(givenDate), DateTime.Parse(todayDate))>= 0 ? true:false;
            //Response.Write(DateTime.Parse(givenDate)+" "+DateTime.Parse(todayDate)+" is same? "+DateTime.Compare(DateTime.Parse(givenDate),DateTime.Parse(todayDate)));
            SqlConnection con = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString
            };

            try
            {
                using (con)
                {
                    string q = "select * from dbo.centralidcluster where userid = '" + Session["userId"] + "' and dateforref = '" + givenDate + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                           
                            cid = dr[2].ToString();
                            dr.Close();
                            q = string.Format("insert into expenses values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", cid, en, ed, amount, givenDate, givenDate, todayDate);
                            cmd = new SqlCommand(q, con);
                            cmd.ExecuteNonQuery();
                            expadded.Text = "Expense Added!";
                        }
                        
                    }
                    else
                    {
                        dr.Close();
                        cid = RandomString(givenDate);
                        q = string.Format("insert into centralidcluster values('{0}','{1}','{2}','{3}')", Session["userId"], cid, givenDate, todayDate);
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        q = string.Format("insert into expenses values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", cid, en, ed, amount, givenDate, givenDate, todayDate);
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        expadded.Text = "Expense Added!";
                    }
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                expadded.Text = "An Error occured!";
                Response.Write("Error: " + exp.Message);
            }
            finally
            {
                con.Close();
                ename.Text = "";
                edetail.Text = "";
                eamount.Text = "";
                edate.Text = "";
            }
        }

        protected void LogoutUser(object sender, EventArgs e)
        {
            Session["authUser"] = false;
            Session["cmnMsg"] = "Logged-Out!";
            Response.Redirect("Login.aspx");
        }

        protected void ResetExoenseForm(object sender, EventArgs e)
        {
            ename.Text = "";
            edetail.Text = "";
            eamount.Text = "";
            edate.Text = "";
        }
    }
}