using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Globalization;

namespace management
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Barcodes barcode = new Barcodes();
        protected void Page_Load(object sender, EventArgs e)
        {
            barcode.BarcodeWidth = 170;
            barcode.BarcodeHigth = 60;
            barcode.BarcodeFontSize = 12;
            barcode.PointX = 2f;
            barcode.PointY = 2f;
            //Response.Write("<img src="+barcode.barCode("9813556987", "BDT: 650৳ + Vat", "____APitSoft Development___") +" />");

            var bytes = Encoding.GetEncoding("ucs-2").GetBytes("SomeString");

            System.Text.Encoding encoding = System.Text.Encoding.BigEndianUnicode;
            StreamReader reader = new StreamReader(Server.MapPath("~/1111.txt"), encoding);
            string line = reader.ReadLine();
            while (line != null)
            {
                //Console.WriteLine(line);
                Response.Write(line);
                line = reader.ReadLine();
            }

            byte[] bt = Encoding.GetEncoding("ucs-2").GetBytes("SomeString");
            foreach (byte b in bt)
            {
                Console.Write(b);
            }

            var str2 = Encoding.Unicode.GetString(bt);

            Console.WriteLine("\n" + str2);


        }
    }
}