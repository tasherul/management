using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace ManagementApp
{
    /// <summary>
    /// Summary description for test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class test : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod]
        public void AddBrand(string emp)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("InsertBrandData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Brand",
                    Value = emp
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Wirehouse",
                    Value = "Null"
                });
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public string GetDetails(string name, int age)
        {
            return string.Format("Name: {0}{2}Age: {1}{2}TimeStamp: {3}", name, age, Environment.NewLine, DateTime.Now.ToString());
        }
        public class Brands
        {
            public string BrandName { get; set; }
            public string WireHouse { get; set; }
        }

        [WebMethod]
        [ScriptMethod]
        public void GetBrand()
        {
            List<Brands> listBrand = new List<Brands>();
            string cs = ConfigurationManager.ConnectionStrings["DBtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from brand";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Brands brand = new Brands();
                    brand.BrandName = dr["Brand"].ToString();
                    brand.WireHouse = dr["Wirehouse"].ToString();
                    listBrand.Add(brand);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listBrand));
        }


    }
}
