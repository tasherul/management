using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maganement
{
    public class AntiInjection
    {
        private string Default_Key = "~!#$%^&@.~*(){}[]_/'\"-+=,?:<>;\\ ";
        private string Symbol_key;


        private bool FullName_;
        private bool Email_;
        private bool Password_;
        private bool Url_;
        private bool Symbol_key_;
        private bool Default_key_;
        private bool Address_;
        public bool Address { set { Address_ = value; } }
        //public bool DefaultKey { set { Default_key_ = value; } }
        public bool FullName { set { FullName_ = value; } }
        public bool Email { set { Email_ = value; } }
        public bool Password { set { Password_ = value; } }
        public bool Url { set { Url_ = value; } }
        public bool Symbol { set { Symbol_key_ = value; } }
        public string Symbol_Key { set { Symbol_key = value; } }
        private bool Genarate(string Data)
        {
            if (Data != string.Empty)
            {
                if (FullName_)
                {
                    Default_Key = Default_Key.Replace(".", "");
                    Default_Key = Default_Key.Replace(" ", "");
                }
                if (Address_)
                {
                    Default_Key = Default_Key.Replace(".", "");
                    Default_Key = Default_Key.Replace(" ", "");
                    Default_Key = Default_Key.Replace(",", "");
                    Default_Key = Default_Key.Replace("-", "");
                    Default_Key = Default_Key.Replace("/", "");
                }
                if (Email_)
                {
                    Default_Key = Default_Key.Replace(".", "");
                    Default_Key = Default_Key.Replace("@", "");
                }
                if (Password_)
                {
                    Default_Key = Default_Key.Replace("!", "");
                    Default_Key = Default_Key.Replace("#", "");
                    Default_Key = Default_Key.Replace("$", "");
                    Default_Key = Default_Key.Replace("&", "");
                    Default_Key = Default_Key.Replace("@", "");
                    Default_Key = Default_Key.Replace(" ", "");
                }
                if (Symbol_key_)
                {
                    if (Symbol_key != string.Empty)
                    {
                        Default_Key = Symbol_key;
                    }
                }
                if (Url_)
                {
                    Default_Key = Default_Key.Replace("!", "");
                    Default_Key = Default_Key.Replace("/", "");
                    Default_Key = Default_Key.Replace("+", "");
                    Default_Key = Default_Key.Replace("@", "");
                    Default_Key = Default_Key.Replace(",", "");
                    Default_Key = Default_Key.Replace(".", "");
                    Default_Key = Default_Key.Replace("&", "");
                    Default_Key = Default_Key.Replace("#", "");
                    Default_Key = Default_Key.Replace("=", "");
                    Default_Key = Default_Key.Replace("%", "");
                    Default_Key = Default_Key.Replace("-", "");
                    Default_Key = Default_Key.Replace("[", "");
                    Default_Key = Default_Key.Replace("]", "");
                    Default_Key = Default_Key.Replace("(", "");
                    Default_Key = Default_Key.Replace(")", "");
                    Default_Key = Default_Key.Replace("_", "");
                    Default_Key = Default_Key.Replace("*", "");
                    Default_Key = Default_Key.Replace(":", "");
                    Default_Key = Default_Key.Replace("'", "");
                }
                bool Input_Check = true;
                for (int i = 0; i < Data.Length; i++)
                {
                    for (int j = 0; j < Default_Key.Length; j++)
                    {
                        if (Data[i] == Default_Key[j])
                        {
                            Input_Check = false;
                            break;
                        }
                        int ii = i + 1;
                        if (ii < Data.Length)
                        {
                            if (Data[i] == '-' && Data[ii] == '-')
                            {
                                Input_Check = false;
                                break;
                            }
                        }
                    }
                    if (!Input_Check)
                    {
                        break;
                    }
                }
                return Input_Check;
            }
            else
            {
                return false;
            }


        }
        public bool StringData(string Data){return Genarate(Data);}


    }
}