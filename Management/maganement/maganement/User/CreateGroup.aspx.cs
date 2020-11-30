using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace management.User
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        Check _Chk = new Check();
        Verification _VR = new Verification();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                ShowGroupData_Code();
                if (Request.QueryString["g_name"] != null)
                {
                    pnlUpdate.Visible = true;
                    string G_Name = Request.QueryString["g_name"].ToString();
                    if (!IsPostBack)
                    {
                        ShowGroupUpdate(G_Name);
                    }
                }
                else
                {
                    if (!IsPostBack)
                    {
                        pnlUpdate.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
               
        }

        protected void btnCreateGroup_Click(object sender, EventArgs e)
        {
            _Chk.ConfigarationName = "dbm";
            lblCreateGroup.Text = "";
            string GroupName = txtGroupName.Text;
            if(txtGroupName.Text!="")
            {
                string Query = "select count(*) from m_UserGroup where GroupName='" + GroupName + "'";
                if(((_Chk.int32Check(Query) == 0) ? true : false))
                {
                    int i = 0;
                    foreach (GridViewRow row in GridView_Create.Rows)
                    {
                        CheckBox status = (row.Cells[1].FindControl("CheckBox1") as CheckBox);
                        Label rollno = (row.Cells[0].FindControl("Label1") as Label);
                        if (status.Checked)
                        {
                            //lblCreateGroup.Text += "True " + rollno.Text + ", "+status.Text;
                            // updaterow(rollno, "true");
                            InsertGroup(GroupName, rollno.Text);
                            i++;
                        }                        
                    }
                    if(i>0)
                    {
                        lblCreateGroup.Text = "<div class='alert alert-success'><span>Add a Group Name</span></div> ";
                        txtGroupName.Text = "";
                        //GridView_Create.DataBind();
                        //ShowGroupData_Code();
                        Response.Redirect("../User/CreateGroup");
                    }
                }
                else
                {
                    lblCreateGroup.Text = "<div class='alert alert-danger'><span> Group Name is Avaiable.</span></div> ";
                }           
            }
            else
            {
                lblCreateGroup.Text = "<div class='alert alert-danger'><span> Type a Group Name </span></div> ";
            }


            

        }
        private void InsertGroup(string GroupName, string ID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into m_UserGroup (GroupName,Page_id) values(@GroupName,@Page_id)";
                cmd.Parameters.AddWithValue("@GroupName",GroupName);
                cmd.Parameters.AddWithValue("@Page_id",ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void ShowGroupData_Code()
        {
            ShowGroupData.Controls.Clear();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                string Show = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select DISTINCT GroupName from m_UserGroup";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Show += "<li><a href='CreateGroup?g_name=" + dr["GroupName"].ToString()+"'> "+ dr["GroupName"].ToString() + " </a></li>";
                }
                con.Close();
                ShowGroupData.Controls.Add(new LiteralControl(Show));
            }
        }
        private void ShowGroupUpdate(string GroupName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"select m_page.m_id as ID from m_UserGroup,m_page
                where m_UserGroup.Page_id = m_page.m_id and m_UserGroup.GroupName = '" + GroupName + "' ";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkUpGrid(dr["ID"].ToString());
                }
                con.Close();
                
            }
        }
        private void checkUpGrid(string ID)
        {
            foreach (GridViewRow row in GridView_Update.Rows)
            {
                CheckBox status = (row.Cells[1].FindControl("CheckBox1") as CheckBox);
                Label IDs = (row.Cells[0].FindControl("Label1") as Label);
                if(ID==IDs.Text)
                {
                    status.Checked = true;
                }
            }


        }
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("../User/CreateGroup");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string GroupName = Request.QueryString["g_name"].ToString();
            DeleteGroup(GroupName);
            foreach (GridViewRow row in GridView_Update.Rows)
            {
                CheckBox status = (row.Cells[1].FindControl("CheckBox1") as CheckBox);
                Label rollno = (row.Cells[0].FindControl("Label1") as Label);
                if (status.Checked)
                {
                    InsertGroup(GroupName, rollno.Text);
                }
            }
            lblCreateGroup2.Text = "<div class='alert alert-success'><span>Group Update</span></div> ";

        }
        private void DeleteGroup(string GroupName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from m_UserGroup where GroupName='" + GroupName + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string GroupName = Request.QueryString["g_name"].ToString();
            DeleteGroup(GroupName);
            Response.Redirect("../User/CreateGroup");
        }

    }

}