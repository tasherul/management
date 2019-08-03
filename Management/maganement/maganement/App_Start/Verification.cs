using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace maganement
{
    public class Verification
    {
        Check _chk = new Check();
        public bool Check (string PageName, string UserID)
        {
            return VR(PageName, UserID);
        }
        private bool VR(string PageName, string UserID)
        {
            _chk.ConfigarationName = "dbm";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                string St = " from m_login where userid = '"+UserID+"'";
                if (_chk.int32Check("select count(*) " +St)==1)
                {
                    string Type = _chk.stringCheck("select Type "+St);
                    if(Type== "Administrator")
                    {
                        return true;
                    }
                    else
                    {
                        string GroupName = _chk.stringCheck("select GroupName "+St);
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = @"SELECT m_UserGroup.GroupName,m_page.PageName FROM m_page,m_UserGroup where m_UserGroup.Page_id=m_page.m_id and m_UserGroup.GroupName='"+GroupName+"' ";
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        int i=0;
                        while(dr.Read())
                        {
                            if(PageName==dr["PageName"].ToString())
                            {
                                i++;   
                            }
                        }
                        con.Close();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


    }
}