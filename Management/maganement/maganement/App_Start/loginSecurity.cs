using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace management
{
    public class loginSecurity
    {
        private string _UserID;
        Check _chk = new Check();
        public string UserID { set { _UserID = value; }  }


        private bool P_Validation()
        {
            _chk.ConfigarationName = "dbm";
            _chk.BoolCount = 1;
            return _chk.boolCheck("select count(*) from m_login where userid='"+ _UserID + "' ");
        }
        public bool Validation()
        {
            return P_Validation();
        }
        private bool P_Authority()
        {
            _chk.ConfigarationName = "dbm";
            return (_chk.stringCheck("select Authority from m_login where userid='" + _UserID + "' ")== "True"?true:false);
        }
        public bool Authority()
        {
            return P_Authority();
        }
        private bool P_FullCheck()
        {
            return (P_Validation() == P_Authority() ? true : false);
        }
        public bool FullCheck()
        {
            return P_FullCheck();
        }




        
        


    }
}