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
    public partial class AdminBookIssuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getName();
        }

        //Issue Book
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script> alert('This Member already has this book');</script>");
                }
                else
                {
                    issueBook();
                }
            }
            else
            {
                Response.Write("<script> alert('Wrong Member ID OR Book ID');</script>");
            }
        }

        //Return Book
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script> alert('This Entry Does Not Exist');</script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Wrong Member ID OR Book ID');</script>");
            }
        }


        //
        void getName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl " +
                    " where book_id = '" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Wrong Book ID');</script>");
                }

                cmd = new SqlCommand("select full_name from member_master_tbl " +
                    "where member_id = '" + TextBox2.Text.Trim() + "'", con);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Wrong Member ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from book_master_tbl " +
                    " where book_id = '" + TextBox1.Text.Trim() + "' " +
                    " AND current_stock > 0", con);

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
            catch
            {
                return false;
            }
        }


        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select full_name from member_master_tbl " +
                    "where member_id = '" + TextBox2.Text.Trim() + "'", con);

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
            catch
            {
                return false;
            }
        }

        
        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl " +
                    "where member_id = '" + TextBox2.Text.Trim() + "'" +
                    "AND book_id = '" + TextBox1.Text.Trim() + "'", con);

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
            catch
            {
                return false;
            }
        }

        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl " +
                    "(member_id, member_name, book_id, book_name, issue_date, due_date) " +
                    "Values(@1, @2, @3, @4, @5, @6)", con);

                cmd.Parameters.AddWithValue("@1", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@2", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@3", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@4", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@5", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@6", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl set current_stock = current_stock - 1 " +
                    "Where book_id = '" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();

                //close the connection
                con.Close();
                Response.Write("<script> alert('Book Issue Successfully.');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl" +
                    " Where book_id = '" + TextBox1.Text.Trim() + "'" +
                    " And member_id = '" + TextBox2.Text.Trim() +"'", con);
             
                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {              
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd = new SqlCommand("UPDATE book_master_tbl set current_stock = current_stock + 1 " +
                        "Where book_id = '" + TextBox1.Text.Trim() + "' ", con);

                    cmd.ExecuteNonQuery();
                    //close the connection
                    con.Close();
                    Response.Write("<script> alert('Book Returned Successfully.');</script>");

                    GridView1.DataBind();
                }                             
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
    }
}