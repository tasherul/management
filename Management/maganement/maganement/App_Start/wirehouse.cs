using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace management
{
    public class wirehouse
    {
        Check chk = new Check();
        public string Session{ get; set; }

        public List<House> WireHouse()
        {
            string UserID = Session;
            string Type = chk.stringCheck("select Type from m_login where userid='"+ UserID + "' ");
            List<House> WH = new List<House>();
            if(Type== "Administrator")
            {
                DataTable dt = chk.DataTable("select * from wirehouse");
                foreach(DataRow dr in dt.Rows)
                {
                    WH.Add(new House(dr["WirehouseName"].ToString(), dr["w_id"].ToString()));
                }
                return WH;
            }
            else
            {
                DataTable dt = chk.DataTable(@"SELECT mWH.w_id as Value ,mWH.WirehouseName as Name
  FROM m_users_wirehouse as uWH, wirehouse as mWH
  where mWH.w_id = uWH.w_id and uWH.userid='"+UserID+"' ");
                foreach (DataRow dr in dt.Rows)
                {
                    WH.Add(new House(dr["Name"].ToString(), dr["Value"].ToString()));
                }
                return WH;
            }

            
        }
        public List<House> WireHouse(string Session)
        {
            string UserID = Session;
            string Type = chk.stringCheck("select Type from m_login where userid='" + UserID + "' ");
            List<House> WH = new List<House>();
            if (Type == "Administrator")
            {
                DataTable dt = chk.DataTable("select * from wirehouse");
                foreach (DataRow dr in dt.Rows)
                {
                    WH.Add(new House(dr["WirehouseName"].ToString(), dr["w_id"].ToString()));
                }
                return WH;
            }
            else
            {
                DataTable dt = chk.DataTable(@"SELECT mWH.w_id as Value ,mWH.WirehouseName as Name
  FROM m_users_wirehouse as uWH, wirehouse as mWH
  where mWH.w_id = uWH.w_id and uWH.userid='" + UserID + "' ");
                foreach (DataRow dr in dt.Rows)
                {
                    WH.Add(new House(dr["Name"].ToString(), dr["Value"].ToString()));
                }
                return WH;
            }


        }
    }
    public class House
    {
        public  House(string Name,string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}