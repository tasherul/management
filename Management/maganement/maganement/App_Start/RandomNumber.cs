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
using System.Text;

namespace maganement
{
    public class RandomNumber
    {
        private int CountData = 10;
        private string ConnectionString = "dbm";
        private bool _Number;
        private bool _CapitalLetter;
        private bool _SmallLetter;
        
        public bool Number
        {
            set { _Number = value; }
        }
        public bool CapitalLetter
        {
            set { _CapitalLetter = value; }
        }
        public bool SmallLetter
        {
            set { _SmallLetter = value; }
        }
        public int HowMuchNumber
        {
            get { return CountData; }
            set { CountData = value; }
        }
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string _RandomString(string Details)
        {
            string input="";
            if (_Number)
                input += "1234567890";
            else if (_CapitalLetter)
                input += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            else if (_SmallLetter)
                input += "abcdefghijklmnopqrstuvwyz";
            else
                input = "abcdefghijklmnopqrstuvwyz01234567890ABCDEFGIJKLMNOPQRSTUVWXYZ";


            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < CountData; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return check(builder.ToString(), Details);
        }
        private string check(string randomnumber, string Details)
        {
            Check chk = new Check();
            chk.ConfigarationName = ConnectionString;
            if (chk.int32Check("select count(*) from Random where RandomString='" + randomnumber + "'") == 0)
            {
                return InsertDatabase(randomnumber, Details);
            }
            else
            {
                return _RandomString(Details);
            }
        }
        private string InsertDatabase(string randomnumber, string Details)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Random (RandomString,Details) values(@RandomString,@Details)";
                cmd.Parameters.AddWithValue("@RandomString", randomnumber);
                cmd.Parameters.AddWithValue("@Details", Details);
                cmd.ExecuteNonQuery().ToString();
                cn.Close();
                return randomnumber;
            }
        }
        public string RandomStringNumber(string Details)
        {
            return _RandomString(Details);
        }

    }
}