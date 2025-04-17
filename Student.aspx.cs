using System;
using System.Collections.Generic;
using System.Data;//dataset
using System.Data.SqlClient;// Sqlconnection, SqldataAdapter,
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_ADO_oct_16_4_25
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbnInsert_Click(object sender, EventArgs e)
        {
            int rollNo = int.Parse(txtRoll.Text);
            string Stud_name = txtName.Text;
            int total_marks =int.Parse( txtTotalMarks.Text);

            // ADO.net logic to insert record into database

            //step1
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-ABKHEEV;Initial Catalog=DB_ADO_Oct;Integrated Security=True;TrustServerCertificate=True";

            //step2
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblStudent", con);

            DataSet ds = new DataSet();// mini database at client side(client machine)
            adp.Fill(ds, "tblStudent");// Fill==>retrive data from DB to datase

            //step3 
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);


            //step 4

            DataRow dr = ds.Tables["tblStudent"].NewRow();

            dr["Roll"] = rollNo;
            dr["Name"] = Stud_name;
            dr["Total_marks"] = total_marks;

            ds.Tables["tblStudent"].Rows.Add(dr);
         int n=   adp.Update(ds, "tblStudent"); //update==> transfer(store) dataset records int DB

            if(n>0)
            {
                Response.Write("<script>alert('record inserted successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('record NOT inserted!!!!');</script>");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int roll =int.Parse( txtRoll.Text);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-ABKHEEV;Initial Catalog=DB_ADO_Oct;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            SqlDataAdapter Myadp = new SqlDataAdapter("select * from tblStudent where Roll="+roll,con);
            DataTable dt = new DataTable();
            Myadp.Fill(dt);
            if (dt.Rows.Count==1)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtTotalMarks.Text = dt.Rows[0]["Total_marks"].ToString();
                btnDelete.Enabled = true;
                btnupdate.Enabled = true;

            }
            else
            {
                txtName.Text = "";
                txtTotalMarks.Text = "";
                btnDelete.Enabled = false;
                btnupdate.Enabled = false;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-ABKHEEV;Initial Catalog=DB_ADO_Oct;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            int roll = int.Parse(txtRoll.Text);

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblStudent where Roll="+roll,con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count==1)
            {
                DataRow dr = dt.Rows[0];
                dr.Delete();
                int n = adp.Update(dt);
                if (n > 0)
                {
                    Response.Write("<script>alert('record deleted successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('record NOT Deleted!!!!');</script>");
                }
            }
            btnDelete.Enabled = false;

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {        
            int roll = int.Parse( txtRoll.Text);
            string name = txtName.Text;
            int totalmarks = int.Parse(txtTotalMarks.Text);

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ABKHEEV;Initial Catalog=DB_ADO_Oct;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblStudent where Roll="+roll,con);
            SqlCommandBuilder scb = new SqlCommandBuilder(adp);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.Rows[0][0] = roll;
            dt.Rows[0]["Name"] = name;
            dt.Rows[0][2] = totalmarks;

            int n = adp.Update(dt);
            if (n > 0)
            {
                Response.Write("<script>alert('record updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('record NOT updated!!!!');</script>");
            }

            btnupdate.Enabled = false;
        }
    }
}