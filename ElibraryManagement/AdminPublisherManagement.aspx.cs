using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class AdminPublisherManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // ADD 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                Response.Write("<script> alert('Publisher with this ID is already Exists. Yiu cannot add publisher with the same publisher id.');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        //UPDATE
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script> alert('Publisher with this ID is Not Exists.');</script>");
            }
        }

        //DELETE
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script> alert('Publisher with this ID is Not Exists.');</script>");
            }
        }

        //GO
        protected void Button2_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }

        /// <summary>
        /// This method check the Publisher exist or not.
        /// </summary>
        /// <returns></returns>
        bool checkIfPublisherExists()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE " +
                    " publisher_id = '" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        /// <summary>
        /// This method add the new Publisher in the Db
        /// </summary>
        void addNewPublisher()
        {
            // Response.Write("<script> alert('Testing');</script>");

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl " +
                    "(publisher_id, Publisher_name) VALUES" +
                    "(@1, @2)", con);

                cmd.Parameters.AddWithValue("@1", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@2", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Publisher Added Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        /// <summary>
        /// This method update the Publisher in the db.
        /// </summary>
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl set Publisher_name = @PublisherName" +
                    " Where publisher_id = '" + TextBox1.Text.Trim() + "' ", con);

                cmd.Parameters.AddWithValue("@PublisherName", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Publisher Updated Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl Where publisher_id = '" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Publisher Deleted Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        void getPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE " +
                    " publisher_id = '" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Publisher ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
    }
}