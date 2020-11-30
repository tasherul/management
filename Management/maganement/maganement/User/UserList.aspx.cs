using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management.User
{
    public partial class UserList : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                ShowData();
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }

        }
        private void ShowData()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                string Show = "";
                pnlData.Controls.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from m_login";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    string Name = dr["Name"].ToString();
                    string Email = dr["Email"].ToString();
                    string Number = dr["Number"].ToString();
                    string GroupName = dr["GroupName"].ToString();
                    string Authority = dr["Authority"].ToString();
                    string UserID = dr["userid"].ToString();
                    string Auth_Show = "";
                    if(Authority=="True")
                    {
                        Auth_Show = "<td><span class='label label-success-border'>Enable</span></td>";
                    }
                    else
                    {
                        Auth_Show = "<td><span class='label label-danger-border'>Disable</span></td>";
                    }
                    string Type = dr["Type"].ToString();
                    string Type_Show = "";
                    string Administrator_ = "";
                    if (Session["m_Type"] != null && Session["m_UserID"]!=null)
                    {
                        if (Session["m_Type"].ToString() == "Administrator")
                        {
                            if (Type == "Administrator")
                            {
                                Administrator_ = @" <li><a> No Change Administrator Account</a></li> ";
                            }
                            else
                            {
                                Administrator_ = string.Format(@" <li><a href='../User/AddUser?ed_id={0}' ><i class='fa fa-pencil m-r-5'></i>Edit</a></li>
										    <li><a href='../User/AddUser?de_id={0}' ><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
                                            <li><a href='../User/AddUser?cng_id={0}&ad_id={1}'><i class='fa fa-user-secret m-r-5'></i>Administrator</a></li>", UserID,Session["m_UserID"].ToString());
                            }

                        }
                        else
                        {
                            if (Type == "Administrator")
                            {
                                Administrator_ = @" <li> <a>You Can't Change Administrator</a></li>";
                            }
                            else
                            {
                                Administrator_ = string.Format(@" <li><a href='../User/AddUser?ed_id={0}'><i class='fa fa-pencil m-r-5'></i>Edit</a></li>
										    <li><a href='../User/AddUser?de_id={0}' ><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>",UserID);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("../Login");
                    }
                    if (Type== "Administrator")
                    {
                        Type_Show = "<span class='label label-danger-border'>Administrator</span>";

                    }
                    else
                    {
                        Type_Show = "<span class='label label-info-border'>Group</span>";
                    }
                    string Title_Number = Name.Substring(0, 1).ToUpper();                    
                    Show += string.Format(@"<tr><td>
												<a href='{0}' class='avatar'>{1}</a>
												<h2><a href='{0}'>{2} <span>{3}</span></a></h2>
											</td>
											<td>{4}</td>
											<td>{5}</td>
											{6}
											<td>
												{7}
											</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
                                                         {8}														
													</ul>
												</div>
											</td>
										</tr>","Show?="+ UserID,  Title_Number,Name, GroupName,Email,Number, Auth_Show,Type_Show,Administrator_);

                }
                con.Close();
                pnlData.Controls.Add(new LiteralControl(Show));
            }
        }


    }
}