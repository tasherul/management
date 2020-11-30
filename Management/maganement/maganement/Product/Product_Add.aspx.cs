using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace management.Product
{
    public partial class Product_Add : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        AntiInjection _Anti = new AntiInjection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                btnUpdate.Visible = false;
                if (!IsPostBack)
                {
                    Brand();
                }
                if(Request.QueryString["ed_id"]!=null)
                {
                    string ID = Request.QueryString["ed_id"].ToString();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;                    
                    if(_chk.int32CheckSecurity("select count(*) from ProductAdd where p_id="+ID,1))
                    {
                        string st = " from ProductAdd where  p_id=" + ID;
                        if(!IsPostBack)
                        {
                            txtBuingPrice.Text = _chk.stringCheck("select BuingPrice " + st);
                            txtDescription.Text = _chk.stringCheck("select Description " + st);
                            txtProductName.Text = _chk.stringCheck("select Name " + st);
                            txtSellingPrice.Text = _chk.stringCheck("select SellingPrice " + st);
                            ddlBrand.SelectedValue = _chk.stringCheck("select b_id" + st);
                            ddlUnit.SelectedValue = _chk.stringCheck("select Unit" + st);
                        }

                    }
                    else
                    {
                        pnlDelete.Visible = false;
                        btnSave.Visible = false;
                        btnUpdate.Visible = false;
                        lblResult.Text = "<div class='alert alert-danger'><span>" + _chk.Int32SecurityCheckError + "</span></div> ";
                    }
                }
                if(Request.QueryString["de_id"]!=null)
                {
                    string ID = Request.QueryString["de_id"].ToString();
                    pnlDelete.Visible = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    if (_chk.int32CheckSecurity("select count(*) from ProductAdd where p_id=" + ID, 1))
                    {
                        _chk.stringCheck("delete from ProductAdd where p_id=" + ID);
                        lblResult.Text = "<div class='alert alert-success'><span> Product Deleted </span></div> ";
                    }
                    else
                    {
                        pnlDelete.Visible = false;
                        btnSave.Visible = false;
                        btnUpdate.Visible = false;
                        lblResult.Text = "<div class='alert alert-danger'><span>" + _chk.Int32SecurityCheckError + "</span></div> ";
                    }
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        private void Brand()
        {
            ddlBrand.Items.Clear();
            ddlBrand.Items.Add(new ListItem("Select Brand", "0"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @" select 
            Brand.b_id, 
            Brand.BrandName, 
            SubCategory.Sub_Category_Name,
            Category.CategoryName,
            wirehouse.WirehouseName
                    
            FROM Brand,SubCategory,Category,wirehouse

            where

            Brand.SubCategory_id = SubCategory.s_id and
            SubCategory.Category_id = Category.c_id and
            Category.wirehouse_id = wirehouse.w_id";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["BrandName"] + " - " + dr["Sub_Category_Name"] + " - " + dr["CategoryName"] + " - " + dr["WirehouseName"];
                li.Value = dr["b_id"].ToString();
                ddlBrand.Items.Add(li);
            }
            con.Close();


        }
        Check _chk = new Check();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtProductName.Text!="" && txtBuingPrice.Text!="" && txtSellingPrice.Text!="" && ddlUnit.SelectedValue!="0" && ddlBrand.SelectedValue!="0")
            {
                if (_chk.int32Check("select count(*) from ProductAdd where Name='" + txtProductName.Text + "' ") == 0)
                {
                    if (_chk.BoolSecurityCheck(string.Format(@"insert into ProductAdd (Name,BuingPrice,SellingPrice,Unit,b_id,Brand,Description,InputDateTime,InputDate,userid) values('{0}',{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}')", txtProductName.Text, txtBuingPrice.Text, txtSellingPrice.Text, ddlUnit.SelectedValue.ToString(), ddlBrand.SelectedValue.ToString(), ddlBrand.SelectedItem.ToString(), txtDescription.Text, DateTime.Now.ToString(), DateTime.Now.ToString("dd MMMM yyyy"), Session["m_UserID"].ToString())))
                    {
                        txtProductName.Text = "";
                        txtBuingPrice.Text = "";
                        txtDescription.Text = "";
                        txtSellingPrice.Text = "";
                        ddlBrand.SelectedValue = "0";
                        ddlUnit.SelectedValue = "0";
                        lblResult.Text = "<div class='alert alert-success'><span>Product Add</span></div> ";
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>" + _chk.BoolSecurityErrorMessege + "</span></div> ";
                    }
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span>Already Insert This Product. Try Another!</span></div> ";
                }

            }
            else
            {              
                lblResult.Text = "<div class='alert alert-danger'><span>You Can not Empty Field where (*) is Avaiable.</span></div> ";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text != "" && txtBuingPrice.Text != "" && txtSellingPrice.Text != "" && ddlUnit.SelectedValue != "0" && ddlBrand.SelectedValue != "0")
            {
                string ID = Request.QueryString["ed_id"].ToString();
                if (_chk.int32Check("select count(*) from ProductAdd where Name='" + txtProductName.Text + "' and p_id!="+ID) == 0)
                {
                    if (_chk.BoolSecurityCheck(string.Format(@"update ProductAdd set Name='{0}',BuingPrice={1},SellingPrice={2},Unit='{3}',b_id='{4}',Brand='{5}',Description='{6}',InputDateTime='{7}',InputDate='{8}',userid='{9}' where p_id={10}", txtProductName.Text, txtBuingPrice.Text, txtSellingPrice.Text, ddlUnit.SelectedValue.ToString(), ddlBrand.SelectedValue.ToString(), ddlBrand.SelectedItem.ToString(), txtDescription.Text, DateTime.Now.ToString(), DateTime.Now.ToString("dd MMMM yyyy"), Session["m_UserID"].ToString(),ID)))
                    {
                        txtProductName.Text = "";
                        txtBuingPrice.Text = "";
                        txtDescription.Text = "";
                        txtSellingPrice.Text = "";
                        ddlBrand.SelectedValue = "0";
                        ddlUnit.SelectedValue = "0";
                        lblResult.Text = "<div class='alert alert-success'><span>Product Add</span></div> ";
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>" + _chk.BoolSecurityErrorMessege + "</span></div> ";
                    }
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span>Already Insert This Product. Try Another!</span></div> ";
                }

            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>You Can not Empty Field where (*) is Avaiable.</span></div> ";
            }
        }


    }
}