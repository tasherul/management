using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.BrandCategory
{
    public partial class Categoty_Add : System.Web.UI.Page
    {
        Verification _VR= new Verification();
        Check _chk = new Check();
        string ErrorPage = "~/Error";
        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownList WireHouse = (DropDownList)Master.FindControl("WireHouse") as DropDownList;
            //WireHouse.Page = Master.fi;
            //WireHouse.;

            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                
                btnUpdateCategory.Visible = false;
                if(Request.QueryString["c_id"]!=null)
                {
                    btnUpdateCategory.Visible = true;
                    btnAddCategory.Visible = false;
                    string Category_id = Request.QueryString["c_id"].ToString();
                    //_chk.ConfigarationName = "dbm";
                    if(_chk.int32Check("select count(*) from Category where c_id='"+Category_id+"' ")==1)
                    {
                        txtCategoryName.Text = _chk.stringCheck("select CategoryName from Category where c_id='" + Category_id + "'");
                    }
                    else
                    {
                        Response.Redirect(ErrorPage+"?=Category id Not Found.");
                    }
                }
                if(Request.QueryString["dc_id"]!=null)
                {
                    btnAddCategory.Visible = false;
                    btnUpdateCategory.Visible = false;
                    txtCategoryName.Visible = false;
                    string Category_id = Request.QueryString["dc_id"].ToString();
                    if (_chk.int32Check("select count(*) from Category where c_id='" + Category_id + "' ") == 1)
                    {
                        _chk.stringCheck("delete from Category where c_id='" + Category_id + "'");
                        lblResult.Text = "<div class='alert alert-success'><span>Category Deleted.</span></div>";
                    }
                    else
                    {
                        Response.Redirect(ErrorPage + "?=Category id Not Found.");
                    }

                }

            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        AntiInjection _Anti = new AntiInjection();
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if(txtCategoryName.Text!="")
            {
                string CategoryName = txtCategoryName.Text;
                if(_Anti.StringData(CategoryName))
                {
                    DropDownList WireHouse = Master.FindControl("WireHouse") as DropDownList;
                    _chk.ConfigarationName = "dbm";
                    if (_chk.int32Check("select count(*) from Category where CategoryName='" + CategoryName + "' and wirehouse_id='" + WireHouse.SelectedValue.ToString() + "' ") == 0)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "insert into Category (CategoryName,wirehouse_id) values(@CategoryName,@wirehouse_id)  ";
                            cmd.Parameters.AddWithValue("@CategoryName",CategoryName);
                            cmd.Parameters.AddWithValue("@wirehouse_id", WireHouse.SelectedValue.ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lblResult.Text = "<div class='alert alert-success'><span>Sucessfully Add a Category.</span></div> ";
                            txtCategoryName.Text = "";

                        }
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>Already Category Name are there.</span></div> ";
                    }
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span>String Problem! Please Type Correctly. Don't Use any Sign.</span></div> ";
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Type Category Name.</span></div> ";
            }
        }

        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text != "")
            {
                string CategoryName = txtCategoryName.Text;
                if (_Anti.StringData(CategoryName))
                {
                    //DropDownList WireHouse = Master.FindControl("WireHouse") as DropDownList;
                    string Category_id = Request.QueryString["c_id"].ToString();
                    string WireHouse_ID = _chk.stringCheck("select wirehouse_id from Category where c_id='"+ Category_id + "' ");
                    _chk.ConfigarationName = "dbm";
                    if (_chk.int32Check("select count(*) from Category where CategoryName='" + CategoryName + "' and wirehouse_id='" + WireHouse_ID + "' ") == 0)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText = "update Category set CategoryName='"+txtCategoryName.Text+"' where c_id='"+ Category_id + "' and wirehouse_id='" + WireHouse_ID + "'   ";
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lblResult.Text = "<div class='alert alert-success'><span>Category Updated.</span></div> ";
                            //txtCategoryName.Text = "";
                        }
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>Already Category Name are there.</span></div> ";
                    }
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span>String Problem! Please Type Correctly. Don't Use any Sign.</span></div> ";
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Type Category Name.</span></div> ";
            }
        }

    }
}