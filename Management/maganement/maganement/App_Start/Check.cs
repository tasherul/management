
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
        private string ConfigName="dbm";
        private string BoolError;
        private int Int32Check;
        private string Int32CheckError;



        public string BoolSecurityErrorMessege
        {
            get { return BoolError; }
        }
        public int Int32SecurityCheck
        {
            get { return Int32Check; }
        }
        public string Int32SecurityCheckError
        {
            get { return Int32CheckError; }
        }
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
                int ReturnValue =  Convert.ToInt32(newCmd.ExecuteScalar().ToString());
                Conn.Close();
                return ReturnValue;
            }
        }
        public int int32Check(string CommandText)
        {
            return int_Check_PV(CommandText);
        }
        public bool int32CheckSecurity(string CommandText,int CountNumber)
        {
            AntiInjection _Anti = new AntiInjection();
            _Anti.Address = true; 
            _Anti.Email = true;
            _Anti.FullName = true;
            _Anti.Password = true;
            _Anti.Url = true;
            if(_Anti.StringData(CommandText))
            {
                Int32Check = int_Check_PV(CommandText);
                if(Int32Check==CountNumber)
                {
                    Int32CheckError = "Successful";
                    return true;                    
                }
                else
                {
                    Int32CheckError = "Not Match";
                    return false;                    
                }
            }
            else
            {
                Int32CheckError = "Error: String is not Secure.";
                return false;                
            }

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

        public DataTable DataTable(string CommandText)
        {
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigName].ConnectionString))
            {
                Conn.Open();
                SqlCommand newCmd = new SqlCommand();
                newCmd.Connection = Conn;
                newCmd.CommandText = CommandText;
                //try
                //{
                DataTable _dt = new DataTable();
                SqlDataAdapter _SqlAdaper = new System.Data.SqlClient.SqlDataAdapter(CommandText, Conn);
                //_SqlAdaper.SelectCommand = new SqlCommand(CommandText,Conn);
                _SqlAdaper.Fill(_dt);
                Conn.Close();
                //}
                //catch (Exception error)
                //{
                //    Conn.Close();
                //    SqlDataReader dr;
                //    return ;
                //}
                return _dt;
            }
        }


        public string stringCheck(string CommandText)
        {
            return string_Check_PV(CommandText);
        }
        AntiInjection _Anti = new AntiInjection();
        private string Pr_Security_Ck(string CommandText)
        {
            _Anti.Address = true; _Anti.Email = true; _Anti.FullName = true; _Anti.Password = true;
            _Anti.Url = true;
            if (_Anti.StringData(CommandText))
            {
                using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigName].ConnectionString))
                {
                    Conn.Open();
                    SqlCommand newCmd = new SqlCommand();
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CommandText;
                    try
                    {
                        string returnValue = "Sucessfully";// newCmd.ExecuteScalar().ToString();
                        newCmd.ExecuteNonQuery();
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
            else
                return "Unauthorized Symbol.";
            
        }
        private bool Pr_Security_Ck_bool(string CommandText)
        {
            _Anti.Address = true; _Anti.Email = true; _Anti.FullName = true; _Anti.Password = true;
            _Anti.Url = true;
            if (_Anti.StringData(CommandText))
            {
                using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigName].ConnectionString))
                {
                    Conn.Open();
                    SqlCommand newCmd = new SqlCommand();
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CommandText;
                    try
                    {
                        //string returnValue = 
                        newCmd.ExecuteNonQuery().ToString();
                        Conn.Close();
                        BoolError = "Sucessfully";// returnValue;
                        return true;
                    }
                    catch (Exception er)
                    {
                        Conn.Close();
                        BoolError = er.Message;
                        return false;
                    }

                }
            }
            else
            {
                BoolError = "Unauthorized Symbol.";
                return false;
            }
        }
        public string StringSecurityCheck(string CMD)
        {
            return Pr_Security_Ck(CMD);
        }
        public bool BoolSecurityCheck(string CMD)
        {
            return Pr_Security_Ck_bool(CMD);
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