using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement
{
    public partial class Login : System.Web.UI.Page
    {
        loginSecurity _Sec = new loginSecurity();
        Check _chk = new Check();
        AntiInjection _anti = new AntiInjection();
        string URL = "Default";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(
            Session["m_UserID"] != null &&
            Session["m_Type"] != null &&
            Session["m_Name"] != null &&
            Session["m_photo"] != null)
            {
                _Sec.UserID = Session["m_UserID"].ToString();
                if(_Sec.FullCheck())
                {
                    Response.Redirect(URL);
                }
            }


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //dfe3e9
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;
            lblResult.Text = "";
            txtUsername.BorderColor = System.Drawing.Color.FromName("dfe3e9");
            txtPassword.BorderColor = System.Drawing.Color.FromName("dfe3e9");


            if (UserName != "" && Password != "")
            {


                if (_anti.StringData(UserName))
                {
                    _anti.Password = true;
                    if (_anti.StringData(Password))
                    {
                        _chk.ConfigarationName = "dbm";
                        string Ui = " from m_login where Username='" + UserName + "' and Password='" + Password + "'";
                        if (_chk.int32Check("select count(*) "+Ui) == 1)
                        {
                            string Type = _chk.stringCheck("select Type " + Ui);
                            string Authority = _chk.stringCheck("select Authority " + Ui);
                            if (Type == "Administrator")
                            {
                                Session["m_UserID"] = _chk.stringCheck("select userid " + Ui);
                                Session["m_Type"] = _chk.stringCheck("select Type " + Ui);
                                Session["m_Name"] = _chk.stringCheck("select Name " + Ui);
                                Session["m_photo"] = _chk.stringCheck("select Photo " + Ui);
                                Response.Redirect(URL);
                            }
                            else
                            {
                                if(Authority=="True")
                                {
                                    Session["m_UserID"] = _chk.stringCheck("select userid " + Ui);
                                    Session["m_Type"] = _chk.stringCheck("select Type " + Ui);
                                    Session["m_Name"] = _chk.stringCheck("select Name " + Ui);
                                    Session["m_photo"] = _chk.stringCheck("select Photo " + Ui);
                                    Response.Redirect(URL);
                                }
                                else
                                {
                                    lblResult.Text = "Login Athority Failed. Can't Login!";
                                }
                            }
                            
                        }
                        else
                        {
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            lblResult.Text = "Invalid UserName/ Password!";
                        }
                    }
                    else
                        lblResult.Text = "Please Type Correctly";
                }
                else
                    lblResult.Text = "Please Type Correctly";
            }
            else
            {
                if (UserName == "")
                {
                    txtUsername.BorderColor = System.Drawing.Color.Red;
                    lblResult.Text += "* Empty Username <br/>";
                }
                if (Password == "")
                {
                    txtPassword.BorderColor = System.Drawing.Color.Red;
                    lblResult.Text += "&nbsp;&nbsp;&nbsp;&nbsp;* Empty Password";
                }
            }


            



        }
        private void go()
        {

        }


    }
}