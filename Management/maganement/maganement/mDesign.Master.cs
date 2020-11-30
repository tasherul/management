using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management
{
    public partial class mDesign : System.Web.UI.MasterPage
    {
        Check chk = new Check();
        wirehouse wh = new wirehouse();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (
            Session["m_UserID"] != null &&
            Session["m_Type"] != null &&
            Session["m_Name"] != null &&
            Session["m_photo"] != null)
            {
                ProfilePhoto.ImageUrl = "~/image/"+ Session["m_photo"].ToString();
                lblName.Text = Session["m_Name"].ToString();
                logo.ImageUrl = "~/image/" + chk.stringCheck("select ValueString from Settings where id=7");
                WireHouse.Items.Clear();
                foreach (House h in wh.WireHouse(Session["m_UserID"].ToString()))
                {
                    WireHouse.Items.Add(new ListItem(h.Name, h.Value));
                }
            }
            else
            {
                Response.Redirect("~/Login");
            }



        }
        

    }
}