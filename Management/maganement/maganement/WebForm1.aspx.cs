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
            //Calendar cal = new Calendar();
            //string Today_Week = cal.TodaysDate.DayOfWeek.ToString();

            //Response.Write( Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath));
            //Response.Write("<br/>");
            //Response.Write(Server.MapPath(Page.AppRelativeVirtualPath));
            //var page = (Page)HttpContext.Current.CurrentHandler;
            //string url = page.AppRelativeVirtualPath;
            //Response.Write("<br/>");
            //DateTime d1 = DateTime.Now;
            //DateTime d2 = DateTime.Parse("8/10/2019 6:31:20 AM");

            //TimeSpan t = d1 - d2;
            //double NrOfDays = t.TotalDays;

            // Response.Write(NrOfDays);
            //Response.Write(NrOfDays);
            //Response.Write(DateTime.Now.ToString());
            //Response.Write(Path.GetFileName(Request.Url.AbsolutePath));

            student[] li = new student[] {  
            };

            
            //listStudent.Add(new student() { Name = "Ador", Roll = "20171002011" });
            for(int i=0;i<10;i++)
            {
                listStudent.Add(new student() { Name = "Piash"+i+1, Roll = "2017100"+i+1+"011" });
            }
            listStudent.RemoveAt(5);
            foreach (student st in listStudent)
            {
                //Response.Write("Name: "+st.Name+" and Roll: "+st.Roll+"<br/>");
            }
            Response.Write(RemoveQueryStringByKey(@"http://www.domain.com/uk_pa/PostDetail.aspx?hello=hi&xpid=4578", "xpid"));

        }

        private string RemoveQueryStringByKey(string url, string key)
        {
            var indexOfQuestionMark = url.IndexOf("?");
            if (indexOfQuestionMark == -1)
            {
                return url;
            }

            var result = url.Substring(0, indexOfQuestionMark);
            var queryStrings = url.Substring(indexOfQuestionMark + 1);
            var queryStringParts = queryStrings.Split(new[] { '&' });
            var isFirstAdded = false;

            for (int index = 0; index < queryStringParts.Length; index++)
            {
                var keyValue = queryStringParts[index].Split(new char[] { '=' });
                if (keyValue[0] == key)
                {
                    continue;
                }

                if (!isFirstAdded)
                {
                    result += "?";
                    isFirstAdded = true;
                }
                else
                {
                    result += "&";
                }

                result += queryStringParts[index];
            }

            return result;
        }

        public static List<student> listStudent = new List<student>();
        public class student
        {
            public string Name;
            public string Roll;
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