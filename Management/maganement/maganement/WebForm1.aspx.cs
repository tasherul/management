using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement
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
            Response.Write("<img src="+barcode.barCode("9813556987", "BDT: 650৳ + Vat", "____APitSoft Development___") +" />");
        }
    }
}