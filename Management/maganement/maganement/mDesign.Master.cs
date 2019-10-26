using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement
{
    public partial class mDesign : System.Web.UI.MasterPage
    {
        Check chk = new Check();
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
            }
            else
            {
                Response.Redirect("~/Login");
            }



        }
        

    }
}