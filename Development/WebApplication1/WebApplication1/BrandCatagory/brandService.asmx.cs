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

namespace WebApplication1.BrandCatagory
{
    /// <summary>
    /// Summary description for brandService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Brands
    {
        public string BrandName { get; set; }
        public string WireHouse { get; set; }
    }
    public class brandService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod]
        public string getMessage(string name)
        {
            return "Hello " + name;
        }

        [WebMethod]
        [ScriptMethod]
        public void AddBrand(String emp)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("InsertBrandData",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Brand",
                    Value = emp
                });
                cmd.Parameters.Add(new SqlParameter() {
                    ParameterName = "@Wirehouse",
                    Value = "Null"
                });
                con.Open();
                cmd.ExecuteNonQuery();
            }
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
                while(dr.Read())
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
