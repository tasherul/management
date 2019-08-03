using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write( Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath));
            //Response.Write("<br/>");
            //Response.Write(Server.MapPath(Page.AppRelativeVirtualPath));
            //var page = (Page)HttpContext.Current.CurrentHandler;
            //string url = page.AppRelativeVirtualPath;
            //Response.Write("<br/>");
            //Response.Write(url);
            //Response.Write("<br/>");
            //Response.Write(Path.GetFileName(Request.Url.AbsolutePath));
            if (!IsPostBack)
            { ShowWirehouse(); }

        }
        private void ShowCategory(string WireHouse)
        {

            ddlCategory.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Category where wirehouse_id='" + WireHouse + "' ";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //ddlWirehouse.Items.Add(new ListItem("Select Wirehouse", "0"));
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
            ddlWirehouseSub.Items.Clear();
            con.Open();
            SqlCommand Show = new SqlCommand();
            Show.Connection = con;
            Show.CommandText = @"select WirehouseName,w_id from wirehouse order by WirehouseName";
            SqlDataReader DATA;
            DATA = Show.ExecuteReader();
            ddlWirehouseSub.Items.Add(new ListItem("Select Wirehouse", "0"));
            while (DATA.Read())
            {
                ListItem new_Item = new ListItem();
                new_Item.Text = DATA["WirehouseName"].ToString();
                new_Item.Value = DATA["w_id"].ToString();
                ddlWirehouseSub.Items.Add(new_Item);
            }
            con.Close();

        }

        protected void ddlWirehouseSub_TextChanged(object sender, EventArgs e)
        {
            if(ddlWirehouseSub.SelectedValue!="0")
            {
                ShowCategory(ddlWirehouseSub.SelectedValue.ToString());
            }
        }
    }
}