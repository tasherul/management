using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlPath = Request.Url.AbsolutePath;
            FileInfo fileInfo = new FileInfo(urlPath);
            string pageName = fileInfo.Name;
            Response.Write(pageName+" "+urlPath);
            
        }
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}