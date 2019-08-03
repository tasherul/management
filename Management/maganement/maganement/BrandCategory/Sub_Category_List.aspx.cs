using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.BrandCategory
{
    public partial class Sub_Category_List : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { ShowWirehouse(); ShowAll(); }

        }
        private void ShowAll()
        {
            pnlDataShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT SubCategory.s_id
            ,SubCategory.Sub_Category_Name
            ,Category.CategoryName
            FROM SubCategory,Category
        where SubCategory.Category_id = Category.c_id";
            con.Open();
            string show = "";
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string Sub_ID = dr["s_id"].ToString();
                string Sub_Name = dr["Sub_Category_Name"].ToString();
                string Cat_Name = dr["CategoryName"].ToString();

                show += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td>{2}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../BrandCategory/Sub_Category?sc_id={0}'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
														<li><a href='../BrandCategory/Sub_Category?d_sc_id={0}'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", Sub_ID, Sub_Name,Cat_Name);

            }
            con.Close();
            pnlDataShow.Controls.Add(new LiteralControl(show));
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

        protected void ddlWirehouse_TextChanged(object sender, EventArgs e)
        {
            if (ddlWirehouse.SelectedValue != "0")
                ShowCategory(ddlWirehouse.SelectedValue.ToString());
            else
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Add(new ListItem("Select Category", "0"));
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if(ddlCategory.SelectedValue!="0" && ddlWirehouse.SelectedValue!="0")
            {
                Scarch_Data(ddlWirehouse.SelectedValue.ToString(), ddlCategory.SelectedValue.ToString());
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span> Select Category and Wirehouse. </span></div>";
            }
        }

        private void Scarch_Data(string Wirehouse, string Category)
        {
            pnlDataShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT SubCategory.s_id
            ,SubCategory.Sub_Category_Name
            ,Category.CategoryName
            FROM SubCategory,Category
        where SubCategory.Category_id = Category.c_id  
        and Category.wirehouse_id='"+ Wirehouse + "' and Category.c_id="+Category;
            con.Open();
            string show = "";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Sub_ID = dr["s_id"].ToString();
                string Sub_Name = dr["Sub_Category_Name"].ToString();
                string Cat_Name = dr["CategoryName"].ToString();

                show += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td>{2}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../BrandCategory/Sub_Category?sc_id={0}'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
														<li><a href='../BrandCategory/Sub_Category?d_sc_id={0}'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", Sub_ID, Sub_Name, Cat_Name);

            }
            con.Close();
            pnlDataShow.Controls.Add(new LiteralControl(show));
        }
    }
}