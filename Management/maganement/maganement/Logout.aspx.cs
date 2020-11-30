using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["m_UserID"] = null;
            Session["m_Type"] = null;
            Session["m_Name"] = null;
            Session["m_photo"] = null;
            Response.Redirect("~/Login");
        }
    }
}