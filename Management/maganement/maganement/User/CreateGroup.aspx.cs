using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.User
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateGroup_Click(object sender, EventArgs e)
        {
            _Chk.ConfigarationName = "dbm";
            lblCreateGroup.Text = "";
            string GroupName = txtGroupName.Text;
            if(txtGroupName.Text!="")
            {
                string Query = "select count(*) from m_UserGroup where GroupName='" + GroupName + "'";
                bool a= ((_Chk.int32Check(Query) == 0) ? true : false);


           
            }
            else
            {
                lblCreateGroup.Text = "<div class='alert alert-success'><span> Type a Group Name </span></div> ";
            }


            foreach (GridViewRow row in GridView_Create.Rows)
            {
                CheckBox status = (row.Cells[1].FindControl("CheckBox1") as CheckBox);
                Label rollno = (row.Cells[0].FindControl("Label1") as Label);
                if (status.Checked)
                {
                    lblCreateGroup.Text += "True "+ rollno.Text+", ";
                    // updaterow(rollno, "true");
                }
                else
                {
                    lblCreateGroup.Text += "False " + rollno.Text + ", ";
                    //updaterow(rollno, "false");

                }
            }

        }



   }

}