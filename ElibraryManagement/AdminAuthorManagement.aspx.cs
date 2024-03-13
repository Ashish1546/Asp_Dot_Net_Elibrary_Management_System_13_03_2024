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
    public partial class AdminAuthorManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //Add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                Response.Write("<script> alert('Authod with this ID is already Exists. Yiu cannot add author with the same author id.');</script>");
            }
            else
            {
                addNewAuthor();
            }
        }

        //Update Button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();               
            }
            else
            {
                Response.Write("<script> alert('Authod with this ID is Not Exists.');</script>");
            }
        }

        //Delete Button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script> alert('Authod with this ID is Not Exists.');</script>");
            }
        }

       
        //Go Button Click
        protected void Button2_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }

        /// <summary>
        /// This method check the author exist or not.
        /// </summary>
        /// <returns></returns>
        bool checkIfAuthorExists()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE " +
                    " author_id = '" + TextBox1.Text.Trim() + "'", con);

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
        /// This method add the new author in the Db
        /// </summary>
        void addNewAuthor()
        {
            // Response.Write("<script> alert('Testing');</script>");

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl " +
                    "(author_id, author_name) VALUES" +
                    "(@1, @2)", con);

                cmd.Parameters.AddWithValue("@1", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@2", TextBox2.Text.Trim());
             
                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Author Added Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        /// <summary>
        /// This method update the author in the db.
        /// </summary>
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl set author_name = @authorName" +
                    " Where author_id = '"+ TextBox1.Text.Trim() +"' ", con);

                cmd.Parameters.AddWithValue("@authorName", TextBox2.Text.Trim());
              

                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Author Updated Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl Where author_id = '" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Author Deleted Successfully.');</script>");
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

        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE " +
                    " author_id = '" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Author ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}