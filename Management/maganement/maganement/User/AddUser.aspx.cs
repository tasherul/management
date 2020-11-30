using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace management.User
{
    public partial class AddUser : System.Web.UI.Page
    {
        Check _chk = new Check();
        Verification _VR = new Verification();
        private string Error_page = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath),Session["m_UserID"].ToString()))
            {
                if (!IsPostBack)
                {
                    btnUpdate.Visible = false;
                }
                if (Request.QueryString["ed_id"] != null) // edit Query
                {
                    btnUpdate.Visible = true;
                    btnUser.Visible = false;
                    string UserID = Request.QueryString["ed_id"].ToString();
                    string St = " from m_login where userid='" + UserID + "' ";
                    _chk.ConfigarationName = "dbm";
                    if (_chk.int32Check("select count(*)  " + St) == 1)
                    {
                        if (!IsPostBack)
                        {
                            txtAddress.Text = _chk.stringCheck("select Address " + St);
                            txtDetails.Text = _chk.stringCheck("select Details " + St);
                            txtEmail.Text = _chk.stringCheck("select Email " + St);
                            txtName.Text = _chk.stringCheck("select Name " + St);
                            txtNID.Text = _chk.stringCheck("select Nid " + St);
                            txtPassword.Text = _chk.stringCheck("select Password " + St);
                            txtUserName.Text = _chk.stringCheck("select Username " + St);
                            ddlGroup.SelectedValue = _chk.stringCheck("select GroupName " + St);
                            ddlLoginPermit.SelectedValue = _chk.stringCheck("select Authority " + St);
                            txtMobileNumber.Text = _chk.stringCheck("select Number " + St);
                        }
                    }
                    else
                    {
                        Response.Redirect(Error_page);
                    }

                }
                if (Request.QueryString["de_id"] != null)// delete a user profile
                {
                    string UserID = Request.QueryString["ed_id"].ToString();
                    string St = " from m_login where userid='" + UserID + "' ";
                    _chk.ConfigarationName = "dbm";
                    if (_chk.int32Check("select count(*)  " + St) == 1)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "delete from m_login where userid='" + UserID + "' ";
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("~/User/UserList");
                        }
                    }
                    else
                    {
                        Response.Redirect(Error_page);
                    }
                }
                if (Request.QueryString["cng_id"] != null && Request.QueryString["ad_id"] != null)
                {
                    string New_ID = Request.QueryString["cng_id"].ToString();
                    string Admin_ID = Request.QueryString["ad_id"].ToString();
                    _chk.ConfigarationName = "dbm";
                    //string St = " from m_login where userid='" + UserID + "' ";
                    if (_chk.int32Check("select count(*) from  m_login where userid='" + New_ID + "'") == 1 &&
                       _chk.int32Check("select count(*) from  m_login where userid='" + Admin_ID + "'") == 1)
                    {
                        string New_Type = _chk.stringCheck("select Type from  m_login where userid='" + New_ID + "'");
                        string New_GroupName = _chk.stringCheck("select GroupName from  m_login where userid='" + New_ID + "'");
                        string Admin_Type = _chk.stringCheck("select Type from  m_login where userid='" + Admin_ID + "'");
                        string Admin_GroupName = _chk.stringCheck("select GroupName from  m_login where userid='" + Admin_ID + "'");
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "update  m_login set Type='" + Admin_Type + "', GroupName='" + Admin_GroupName + "', Authority='True' where userid='" + New_ID + "' ";
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmd.CommandText = "update  m_login set Type='" + New_Type + "', GroupName='" + New_GroupName + "', Authority='True' where userid='" + Admin_ID + "' ";
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            if (Session["m_Type"] != null)
                            {
                                Session["m_Type"] = New_Type;
                            }
                            Response.Redirect("~/User/UserList");
                        }
                    }
                    else
                    {
                        Response.Redirect(Error_page);
                    }
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }




        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtUserName.Text!="" && txtPassword.Text!="" && ddlGroup.SelectedValue!="")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                {
                    RandomNumber _rn = new RandomNumber();
                    _rn.Number = true;
                    _rn.CapitalLetter = true;
                    string UID = _rn.RandomStringNumber("UserID");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"insert into m_login (userid,Name,Email,Number,Username,Password,Nid,Address,Details,Photo,Type,GroupName,Authority) 
                        values(@userid,@Name,@Email,@Number,@Username,@Password,@Nid,@Address,@Details,@Photo,@Type,@GroupName,@Authority)";
                    cmd.Parameters.AddWithValue("@userid", UID);
                    cmd.Parameters.AddWithValue("@Name",txtName.Text);
                    cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Number",txtMobileNumber.Text);
                    cmd.Parameters.AddWithValue("@Username",txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password",txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Nid",txtNID.Text);
                    cmd.Parameters.AddWithValue("@Address",txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Details",txtDetails.Text);
                    int err = 0;string ext = "";
                    string DateTime_ = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    if (ImageUpload.HasFile)
                    {
                        string n = ImageUpload.FileName.ToLower();
                        if(n.EndsWith(".jpg"))
                        {
                            ext = ".jpg";
                            cmd.Parameters.AddWithValue("@Photo", UID+"_"+ DateTime_ + ext);
                            ImageUpload.SaveAs(Server.MapPath("../image/"+ UID + "_" + DateTime_ +  ext));
                        }
                        else
                        {
                            err++;
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Photo", "noimage.jpg");
                    }         
                    cmd.Parameters.AddWithValue("@Type","Group");
                    cmd.Parameters.AddWithValue("@GroupName",ddlGroup.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Authority",ddlLoginPermit.SelectedValue.ToString());
                    if(err==0)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblResult.Text = "<div class='alert alert-success'><span>Add a User</span></div> ";
                        txtAddress.Text = "";
                        txtDetails.Text = "";
                        txtEmail.Text = "";
                        txtMobileNumber.Text = "";
                        txtNID.Text = "";
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        txtName.Text = "";
                        
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>Some problem Please Fixed the image issu. only(*.jpg)</span></div> ";
                    }

                }

            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Name, UserName, Password, Select Group Requid.</span></div> ";

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtUserName.Text != "" && txtPassword.Text != "" && ddlGroup.SelectedValue != "")
            {
                string UserID = Request.QueryString["ed_id"].ToString();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update m_login set Name=@Name,Email=@Email,Number=@Number,Username=@Username,Password=@Password,Nid=@Nid,Address=@Address,Details=@Details,Photo=@Photo,Type=@Type,GroupName=@GroupName,Authority=@Authority  where userid='"+UserID+"' ";
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Number", txtMobileNumber.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Nid", txtNID.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Details", txtDetails.Text);
                    int err = 0; string ext = "";
                    string DateTime_ = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    if (ImageUpload.HasFile)
                    {
                        string n = ImageUpload.FileName.ToLower();
                        if (n.EndsWith(".jpg"))
                        {
                            ext = ".jpg";
                            cmd.Parameters.AddWithValue("@Photo", UserID + "_" + DateTime_ + ext);
                            ImageUpload.SaveAs(Server.MapPath("../image/" + UserID + "_" + DateTime_ + ext));
                        }
                        else
                        {
                            err++;
                        }
                    }
                    else
                    {
                        _chk.ConfigarationName = "dbm";
                        string Old_Image = _chk.stringCheck("select Photo from m_login where userid='"+UserID+"' ");
                        cmd.Parameters.AddWithValue("@Photo", Old_Image);
                    }
                    cmd.Parameters.AddWithValue("@Type", "Group");
                    cmd.Parameters.AddWithValue("@GroupName", ddlGroup.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Authority", ddlLoginPermit.SelectedValue.ToString());
                    if (err == 0)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblResult.Text = "<div class='alert alert-success'><span>User Update</span></div> ";
                        txtAddress.Text = "";
                        txtDetails.Text = "";
                        txtEmail.Text = "";
                        txtMobileNumber.Text = "";
                        txtNID.Text = "";
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        txtName.Text = "";

                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>Some problem Please Fixed the image issu. only(*.jpg)</span></div> ";
                    }
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Name, UserName, Password, Select Group Requid.</span></div> ";
            }
        }
    }
}