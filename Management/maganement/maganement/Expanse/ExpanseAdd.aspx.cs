using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maganement.Expanse
{
    public partial class ExpanseAdd : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (!IsPostBack)
                { Show(); showData(); }
                if(Request.QueryString["id"]!=null && Request.QueryString["St"]!=null)
                {
                    string ID = Request.QueryString["id"].ToString();
                    string Status = Request.QueryString["St"].ToString();
                    if(Status=="1")
                    {
                        Status = "Approved";
                    }
                    else
                    {
                        Status = "Pending";
                    }
                    if(Chk.BoolSecurityCheck("update Expanse set Status='"+Status+ "',InputDateTime='"+DateTime.Now.ToString()+"' where e_id=" + ID)&& Chk.int32CheckSecurity("select count(*) from Expanse where e_id="+ID,1))
                    {
                        Response.Redirect("../Expanse/ExpanseAdd");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege 1: " + Chk.BoolSecurityErrorMessege + " \n Messege 2:"+Chk.Int32SecurityCheckError+"');", true);
                    }
                }
                if(Request.QueryString["eid"]!=null)
                {
                    string ID = Request.QueryString["id"].ToString();
                    if (Chk.BoolSecurityCheck("delete from Expanse where e_id=" + ID) && Chk.int32CheckSecurity("select count(*) from Expanse where e_id=" + ID, 1))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege : Delete Successfully');", true);
                        Response.Redirect("../Expanse/ExpanseAdd");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege 1: " + Chk.BoolSecurityErrorMessege + " \n Messege 2:" + Chk.Int32SecurityCheckError + "');", true);
                    }
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }

        }

        private void showData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT e_id
              ,ExpanseCategory.CategoryName
              ,Schedule
              ,PaidBy
              ,Price
              ,From_
              ,To_
              ,m_login.Name	  
              ,Remark
              ,InputDate
              ,Status
                FROM Expanse,m_login,ExpanseCategory
                where m_login.userid = Expanse.userid and ExpanseCategory.ex_id = Expanse.ex_id";

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 1;string show = "";
            while(dr.Read())
            {
                string e_id = dr["e_id"].ToString();
                string CategoryName = dr["CategoryName"].ToString();
                string Schedule = dr["Schedule"].ToString();
                string PaidBy = dr["PaidBy"].ToString();
                string Price = dr["Price"].ToString();
                string From_ = dr["From_"].ToString();
                string To_ = dr["To_"].ToString();
                string Name = dr["Name"].ToString();
                string Remark = dr["Remark"].ToString();
                string InputDate = dr["InputDate"].ToString();
                string Status = dr["Status"].ToString();
                string S_Class = "";string S_Next = "";
                if (Status == "Pending") 
                {
                    S_Class = "text-danger";
                    S_Next = "<li><a href='../Expanse/ExpanseAdd?id="+ e_id + "&St=1'><i class='fa fa-dot-circle-o text-success'></i> Approved</a></li>";
                }
                else
                {
                    S_Class = "text-success";
                    S_Next = "<li><a href='../Expanse/ExpanseAdd?id=" + e_id + "&St=0'><i class='fa fa-dot-circle-o text-danger'></i> Pending</a></li>";
                }
                show += string.Format(@"<tr>
											<td>
												<strong>{0}</strong>
											</td>
											<td>{1}</td>
											<td>{2}</td>
											<td>{3}</td>
											<td>{4}</td>
											<td>{5}</td>
                                            <td>{6}</td>
											<td class='text-center'>
												<div class='dropdown action-label'>
													<a class='btn btn-white btn-sm rounded dropdown-toggle' href='#' data-toggle='dropdown' aria-expanded='false'>
														<i class='fa fa-dot-circle-o {7}'></i> {8} <i class='caret'></i>
													</a>
													<ul class='dropdown-menu pull-right'>
														{9}
													</ul>
												</div>
											</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
                                                      
														<li><a href='../Expanse/ExpanseAdd?eid={10}' title='Delete'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>	
                                        	
                                        ", i,CategoryName,InputDate,Schedule,Price,PaidBy,Remark,S_Class, Status, S_Next,e_id);i++;
            }//  <li><a href='../invoice/?eid={10}' title='Edit' ><i class='fa fa-pencil m-r-5'></i> Invoice</a></li>
            con.Close();
            pnlShowData.Controls.Clear();
            pnlShowData.Controls.Add(new LiteralControl(show));
        }

        private void Show()
        {
            ddlClient.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from m_login";
            ddlClient.Items.Add(new ListItem("Select Client", "Null"));
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["userid"].ToString();
                ddlClient.Items.Add(li);
            }
            con.Close();
        }
        Check Chk = new Check();
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtPrice.Text != "")
            {
                if(Chk.BoolSecurityCheck(@"insert into Expanse (CategoryName,ex_id,Schedule,PaidBy,Price,From_,To_,userid,Remark,InputDateTime,InputDate,Status,InputID) values('" + ddlCategory.SelectedItem.ToString()+"',"+ddlCategory.SelectedValue.ToString()+",'"+ddlSchedule.SelectedItem.ToString()+"','"+ddlPaidBy.SelectedValue.ToString()+"',"+Convert.ToDouble(txtPrice.Text)+",'"+txtFrom.Text+"','"+txtTo.Text+"','"+ddlClient.SelectedValue.ToString() +"','"+txtRemark.Text+"','"+DateTime.Now.ToString()+"','"+DateTime.Now.ToString("dd MMMM yyyy")+ "','Pending','"+Session["m_UserID"] +"') "))
                {
                    txtPrice.Text = "";
                    txtRemark.Text = "";
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    showData();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege: "+Chk.BoolSecurityErrorMessege+"');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege: Requride Product Price.');", true);
            }
        }







    }
}