using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maganement
{
    public class RandomGenarator
    {
        private int CountData = 10;
        private static string _Symbol = "~!@#$%^&*-=+;.,/";
        private static string _Number = "0123456789";
        private static string _ApperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private static string _Hexadecimal = "0123456789ABCDEF";
        private static string _Binary = "01";
        private string ConnectionString = "dbm";

        private bool __Symbol;
        private bool __Number;
        private bool __ApperCase;
        private bool __LowerCase;
        private bool __Hexadecimal;
        private bool __Binary;
        private bool __DatabaseEntry = true;
        private Exception _ErrorMessenge;
        public Exception ErrorMessenge { get { return _ErrorMessenge; } }
        public bool Symbol { set { __Symbol = value; } }
        public bool Number { set { __Number = value; } }
        public bool ApperCase { set { __ApperCase = value; } }
        public bool LowerCase { set { __LowerCase = value; } }
        public bool Hexadecimal { set { __Hexadecimal = value; } }
        public bool Binary { set { __Binary = value; } }
        public bool DatabaseEntry { set { __DatabaseEntry = value; } }
        public int TotalString
        {
            set { CountData = value; }
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string _RandomString(string Details)
        {
            string input = "";
            if (__Symbol)
                input += _Symbol;
            if (__Number)
                input += _Number;
            if (__ApperCase)
                input += _ApperCase;
            if (__LowerCase)
                input += _LowerCase;
            if (__Hexadecimal)
                input += _Hexadecimal;
            if (__Binary)
                input += _Binary;

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
            if (chk.int32Check("select count(*) from Random where RandomString='" + randomnumber + "' and Details='" + Details + "'") == 0)
            {
                if (__DatabaseEntry)
                    return InsertDatabase(randomnumber, Details);
                else
                    return randomnumber;
            }
            else
            {
                return _RandomString(Details);
            }
        }
        private string InsertDatabase(string randomnumber, string Details)
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
        public string RandomStringNumber(string Details)
        {
            return _RandomString(Details);
        }
        public string RandomStringNumber(string Details, int Separate)//3
        {
            string RandomString = _RandomString(Details);
            int ValueLength = RandomString.Length;//9
            int c = 0;
            string ReturnString = "";
            for (int i = 0; i < ValueLength; i++)
            {//8
                c++;//3
                ReturnString += RandomString[i];//0,1,2 - 3,4,5 - 6,7,8 += [8]
                if (c == Separate && i != ValueLength - 1)//t
                {
                    ReturnString += " ";
                    c = 0;
                }
            }
            return ReturnString;
        }
        public string RandomStringNumber(string Details, int Separate, char SepaeateChar)
        {
            string RandomString = _RandomString(Details);
            int ValueLength = RandomString.Length;//5
            int c = 0;
            string ReturnString = "";
            for (int i = 0; i < ValueLength; i++)
            {//1
                c++;//2
                ReturnString += RandomString[i];//0,1 += [1]
                if (c == Separate && i != ValueLength - 1)//t
                {
                    ReturnString += SepaeateChar;
                    c = 0;
                }
            }
            return ReturnString;
        }
    }

}