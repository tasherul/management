using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management.BrandCategory
{
    public partial class Sub_Category : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        //Check _chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownList WireHouse = Master.FindControl("WireHouse") as DropDownList;
            //ShowCategory(WireHouse.SelectedValue.ToString());
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                btnUpdateSubCategory.Visible = false;
                if(!IsPostBack)
                {
                    ShowWirehouse();
                }
                if(Request.QueryString["sc_id"] !=null)
                {
                    string ID = Request.QueryString["sc_id"].ToString();
                    if(_chk.int32Check("select count(*) from SubCategory where s_id='"+ID+"' ")==1)
                    {
                        pnlUpdate.Visible = false;
                        btnAddSubCategory.Visible = false;
                        btnUpdateSubCategory.Visible = true;
                        if(!IsPostBack)
                        txtSubCategoryName.Text = _chk.stringCheck("select Sub_Category_Name from SubCategory where s_id='" + ID + "'");
                    }
                    else
                    {
                        Response.Redirect("Error?=SubCategoty ID Not Found.");
                    }
                }
                if (Request.QueryString["d_sc_id"] != null)
                {
                    string ID = Request.QueryString["d_sc_id"].ToString();
                    if (_chk.int32Check("select count(*) from SubCategory where s_id='" + ID + "' ") == 1)
                    {
                        pnlUpdate.Visible = false;
                        btnAddSubCategory.Visible = false;
                        btnUpdateSubCategory.Visible = false;
                        txtSubCategoryName.Visible = false;
                       _chk.stringCheck("delete from SubCategory where s_id='" + ID + "'");
                        lblResult.Text = "<div class='alert alert-success'><span>Sub Category Update.</span></div> ";
                    }
                    else
                    {
                        Response.Redirect("Error?=SubCategoty ID Not Found.");
                    }
                }
            }        
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
               

        }
        private void ShowCategory(string WireHouse)
        {
            ddlCategory.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Category where wirehouse_id='"+WireHouse+"' ";
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


        AntiInjection _Anti = new AntiInjection();
        Check _chk = new Check();
        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue!="0" && ddlWirehouse.SelectedValue!="0" && txtSubCategoryName.Text != "")
            {
                string CategoryName = txtSubCategoryName.Text;
                if (_Anti.StringData(CategoryName))
                {
                    if (_chk.int32Check("select count(*) from SubCategory where Category_id='" + ddlCategory.SelectedValue.ToString() + "' and Sub_Category_Name='" + txtSubCategoryName.Text + "'  ") == 0)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
                        {
                            _chk.stringCheck("insert into SubCategory (Category_id,Sub_Category_Name) values('" + ddlCategory.SelectedValue.ToString()+"','"+txtSubCategoryName.Text+"')");
                            lblResult.Text = "<div class='alert alert-success'><span>Sucessfully Sub Category Added.</span></div> ";
                            txtSubCategoryName.Text = "";
                        }
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
                lblResult.Text = "<div class='alert alert-danger'><span> Select Category and type sub categoty name. </span></div> ";
            }

        }
        protected void ddlWirehouse_TextChanged(object sender, EventArgs e)
        {
            if(ddlWirehouse.SelectedValue!="0")
            { ShowCategory(ddlWirehouse.SelectedValue.ToString()); }
        }

        protected void btnUpdateSubCategory_Click(object sender, EventArgs e)
        {
            if(txtSubCategoryName.Text!="")
            {
                string ID = Request.QueryString["sc_id"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update SubCategory set Sub_Category_Name='"+txtSubCategoryName.Text+"' where s_id='"+ID+"' ";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblResult.Text = "<div class='alert alert-success'><span>Sub Category Update.</span></div> ";
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span> Type Subcategory Name. </span></div> ";
            }
        }


    }
}