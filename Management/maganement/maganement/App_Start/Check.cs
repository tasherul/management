
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

namespace maganement
{
    public class Check
    {
        private int _Count;
        private string ConfigName;

        public string ConfigarationName
        {
            get { return ConfigName; }
            set { ConfigName = value; }
        }
        
        public int BoolCount
        {
            get { return _Count; }
            set { _Count = value; }
        }
        private int int_Check_PV(string CommandText)
        {
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigName].ConnectionString))
            {
                Conn.Open();
                SqlCommand newCmd = new SqlCommand();
                newCmd.Connection = Conn;
                newCmd.CommandText = CommandText;
                int ReturnValue = Convert.ToInt32(newCmd.ExecuteScalar().ToString());
                Conn.Close();
                return ReturnValue;
            }
        }
        public int int32Check(string CommandText)
        {
            return int_Check_PV(CommandText);
        }
        private string string_Check_PV(string CommandText)
        {
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigName].ConnectionString))
            {
                Conn.Open();
                SqlCommand newCmd = new SqlCommand();
                newCmd.Connection = Conn;
                newCmd.CommandText = CommandText;
                try
                {
                    string returnValue = newCmd.ExecuteScalar().ToString();
                    Conn.Close();
                    return returnValue;
                }
                catch (Exception error)
                {
                    Conn.Close();
                    return error.Message;
                }

            }
        }
        public string stringCheck(string CommandText)
        {
            return string_Check_PV(CommandText);
        }
        private bool _bool_Check(string CMD)
        {
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigName].ConnectionString))
            {
                try
                {
                    Conn.Open();
                    SqlCommand newCmd = new SqlCommand();
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CMD;
                    int ReturnValue = Convert.ToInt32(newCmd.ExecuteScalar().ToString());
                    Conn.Close();
                    if (ReturnValue == _Count)
                    { return true; }
                    else { return false; }


                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool boolCheck(string CommandText)
        {
            return _bool_Check(CommandText);
        }


    }
}