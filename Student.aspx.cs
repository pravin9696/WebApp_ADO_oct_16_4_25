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
    }
}