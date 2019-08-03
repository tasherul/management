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
    public partial class Brand : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        string ErrorPage = "~/Error";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                btnUpdateBrand.Visible = false;
                if (!IsPostBack)
                {
                    ShowWirehouse();
                }
                if (Request.QueryString["d_b_id"] != null)
                {
                    string ID = Request.QueryString["d_b_id"].ToString();
                    if (_chk.int32Check("select count(*) from Brand where b_id='" + ID + "'") == 1)
                    {
                        _chk.stringCheck("delete from Brand where b_id='" + ID + "'");
                        pnlUpdate.Visible = false;
                        btnBrand.Visible = false;
                        btnUpdateBrand.Visible = false;
                        txtBrandName.Visible = false;
                        lblResult.Text = "<div class='alert alert-success'><span>Brand Deleted.</span></div> ";
                    }
                    else
                    {
                        Response.Redirect(ErrorPage + "?=Brand id Not Found. Not Delete");
                    }
                }
                if (Request.QueryString["b_id"] !=null)
                {
                    string ID = Request.QueryString["b_id"].ToString();
                    if(_chk.int32Check("select count(*) from Brand where b_id='"+ID+"'")==1)
                    {
                        //ddlCategory.Visible = false;
                        //ddlSubCategory.Visible = false;
                       // ddlWirehouse.Visible = false;
                        if(!IsPostBack)
                        {
                            txtBrandName.Text = _chk.stringCheck("select BrandName from Brand where b_id='" + ID + "'");
                        }
                        btnUpdateBrand.Visible = true;
                        btnBrand.Visible = false;
                        pnlUpdate.Visible = false;

                    }
                    else
                    {
                        Response.Redirect(ErrorPage + "?=Brand id Not Found.");
                    }

                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        private void ShowWirehouse()
        {

            ddlWirehouse.Items.Clear();
            con.Open();
            SqlCommand Show = new SqlCommand();
            Show.Connection = con;
            Show.CommandText = @"select WirehouseName,w_id from wirehouse order by WirehouseName";
            SqlDataReader DATA;
            DATA = Show.ExecuteReader();
            ddlWirehouse.Items.Add(new ListItem("Select Wirehouse", "0"));
            while (DATA.Read())
            {
                ListItem new_Item = new ListItem();
                new_Item.Text = DATA["WirehouseName"].ToString();
                new_Item.Value = DATA["w_id"].ToString();
                ddlWirehouse.Items.Add(new_Item);
            }
            con.Close();

        }
        private void ShowCategory(string WireHouse)
        {
            ddlCategory.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Category where wirehouse_id='" + WireHouse + "' ";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlCategory.Items.Add(new ListItem("Select Category", "0"));
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["CategoryName"].ToString();
                li.Value = dr["c_id"].ToString();
                ddlCategory.Items.Add(li);
            }
            con.Close();
            //ddlWirehouse.SelectedValue = "0";

        }

        private void ShowSubCategory(string Category)
        {
            ddlSubCategory.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from SubCategory where Category_id='" + Category + "' ";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlSubCategory.Items.Add(new ListItem("Select Sub Category", "0"));
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Sub_Category_Name"].ToString();
                li.Value = dr["s_id"].ToString();
                ddlSubCategory.Items.Add(li);
            }
            con.Close();
        }

        protected void ddlWirehouse_TextChanged(object sender, EventArgs e)
        {
            if(ddlWirehouse.SelectedValue!="0")
            {
                ShowCategory(ddlWirehouse.SelectedValue.ToString());
            }
        }

        protected void ddlCategory_TextChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "0")
            {
                ShowSubCategory(ddlCategory.SelectedValue.ToString());
            }
        }

        AntiInjection _Anti = new AntiInjection();
        Check _chk = new Check();
        protected void btnBrand_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "0" && ddlWirehouse.SelectedValue != "0" && txtBrandName.Text != "" && ddlSubCategory.SelectedValue!="0")
            {
                string CategoryName = txtBrandName.Text;
                if (_Anti.StringData(CategoryName))
                {
                    if (_chk.int32Check("select count(*) from Brand where SubCategory_id='" + ddlSubCategory.SelectedValue.ToString() + "' and BrandName='" + txtBrandName.Text + "'  ") == 0)
                    {
                        
                        _chk.stringCheck("insert into Brand (BrandName,SubCategory_id) values('" + txtBrandName.Text + "','" + ddlSubCategory.SelectedValue.ToString() + "')");
                        lblResult.Text = "<div class='alert alert-success'><span>Brand Added.</span></div> ";
                        txtBrandName.Text = "";
                        
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span> Sub Category Name Already are there. </span></div> ";
                    }
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span> typing error please type correctly. </span></div> ";
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span> Select Wirehouse, Category, Sub Category and Brand Name</span></div>";
            }
        }

        protected void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            string ID = Request.QueryString["b_id"].ToString();
            if(txtBrandName.Text!="")
            {
                _chk.stringCheck("update Brand set BrandName='"+txtBrandName.Text+"' where b_id="+ID);
                lblResult.Text = "<div class='alert alert-success'><span>Brand Updated.</span></div> ";
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Type Brand Name.</span></div> ";
            }
        }
    }
}