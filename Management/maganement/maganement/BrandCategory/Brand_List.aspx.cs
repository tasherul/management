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
    public partial class Brand_List : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                //btnUpdateBrand.Visible = false;
                if (!IsPostBack)
                {
                    ShowWirehouse();
                    ShowData();
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
            { ShowCategory(ddlWirehouse.SelectedValue.ToString()); }
        }
        protected void ddlCategory_TextChanged(object sender, EventArgs e)
        {
            if(ddlCategory.SelectedValue!="0")
            { ShowSubCategory(ddlCategory.SelectedValue.ToString()); }
        }
        private void ShowData()
        {
            pnlDataShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT
 Brand.b_id,Brand.BrandName,
 SubCategory.Sub_Category_Name,
 Category.CategoryName,
 wirehouse.WirehouseName

  FROM 
  wirehouse,
  Category,
  SubCategory,
  Brand

  where 
  Brand.SubCategory_id = SubCategory.s_id and 
  SubCategory.Category_id=Category.c_id and
  Category.wirehouse_id = wirehouse.w_id";
            con.Open();
            string show = "";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Sub_ID = dr["b_id"].ToString();
                string Sub_Name = dr["Sub_Category_Name"].ToString();
                string Cat_Name = dr["CategoryName"].ToString();
                string WireHouseName = dr["WirehouseName"].ToString();
                string BrandName = dr["BrandName"].ToString();
                show += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td>{2}</td>
                                            <td>{3}</td>
                                            <td>{4}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../BrandCategory/Brand?b_id={0}'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
														<li><a href='../BrandCategory/Brand?d_b_id={0}'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", Sub_ID, BrandName, Cat_Name, Sub_Name, WireHouseName);

            }
            con.Close();
            pnlDataShow.Controls.Add(new LiteralControl(show));
        }
        private void ShowData(string Wirehouse,string Category,string SubCategory)
        {
            pnlDataShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT
 Brand.b_id,Brand.BrandName,
 SubCategory.Sub_Category_Name,
 Category.CategoryName,
 wirehouse.WirehouseName

  FROM 
  wirehouse,
  Category,
  SubCategory,
  Brand

  where 
  Brand.SubCategory_id = SubCategory.s_id and 
  SubCategory.Category_id=Category.c_id and
  Category.wirehouse_id = wirehouse.w_id and

  Category.wirehouse_id='" + Wirehouse + "' and SubCategory.Category_id='" + Category + "' and Brand.SubCategory_id='" + SubCategory + "' ";
            con.Open();
            string show = "";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Sub_ID = dr["b_id"].ToString();
                string Sub_Name = dr["Sub_Category_Name"].ToString();
                string Cat_Name = dr["CategoryName"].ToString();
                string WireHouseName = dr["WirehouseName"].ToString();
                string BrandName = dr["BrandName"].ToString();
                show += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td>{2}</td>
                                            <td>{3}</td>
                                            <td>{4}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../BrandCategory/Brand?b_id={0}'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
														<li><a href='../BrandCategory/Brand?d_b_id={0}'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", Sub_ID, BrandName, Cat_Name, Sub_Name, WireHouseName);

            }
            con.Close();
            pnlDataShow.Controls.Add(new LiteralControl(show));
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if(ddlWirehouse.SelectedValue!="0" && ddlSubCategory.SelectedValue!="0" && ddlCategory.SelectedValue!="0")
            {
                ShowData(ddlWirehouse.SelectedValue.ToString(),ddlCategory.SelectedValue.ToString(),ddlSubCategory.SelectedValue.ToString());
            }
        }
    }
}