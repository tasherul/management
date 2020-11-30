using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Data;

namespace management.Invoice
{
    public partial class Barcode : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        management.settings settings = new management.settings();
        management.Barcodes barcode = new management.Barcodes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(Request.QueryString[""]!=null)
                {
                    string GenertID = Request.QueryString[""].ToString();
                    if(chk.int32Check("select count(*) from Barcode where GeneratID='"+GenertID+"'")>0)
                    {
                        int B_Width = settings.Get_InValue_Settings(17);
                        int B_Height = settings.Get_InValue_Settings(18);
                        int FontSize = settings.Get_InValue_Settings(19);
                        string PointX = settings.Get_StringValue_Settings(20);
                        string PointY = settings.Get_StringValue_Settings(21);
                        Color B_Color = FindColor(settings.Get_StringValue_Settings(22));
                        string FontName = settings.Get_StringValue_Settings(23);
                        bool PriceTag = settings.Get_BoolValue_Settings(24);
                        bool CompanyTag = settings.Get_BoolValue_Settings(24);

                        string BarCode_Col_MD = settings.Get_StringValue_Settings(26);
                        string BarCode_Image_width = settings.Get_StringValue_Settings(27);

                        bool PriceTagEnable = settings.Get_BoolValue_Settings(24);
                        bool CompanyTagEnable = settings.Get_BoolValue_Settings(25);
                        string ParLine = settings.Get_StringValue_Settings(26);
                        string Width_Size = settings.Get_StringValue_Settings(27);
                        int CompanyNameSize = settings.Get_InValue_Settings(28);
                        string CompanyPointX = settings.Get_StringValue_Settings(29);
                        string CompanyPointY = settings.Get_StringValue_Settings(30);
                        string CompanyFontName = settings.Get_StringValue_Settings(31);
                        int CompanyFontSize = settings.Get_InValue_Settings(32);
                        Color CompanyColor = FindColor(settings.Get_StringValue_Settings(33));
                        int PriceTagSize = settings.Get_InValue_Settings(34);
                        string PricePointX = settings.Get_StringValue_Settings(35);
                        string PriceFontName = settings.Get_StringValue_Settings(36);
                        int PriceFontSize = settings.Get_InValue_Settings(37);
                        Color PriceColor = FindColor(settings.Get_StringValue_Settings(38));
                        string CompanyName = settings.Get_StringValue_Settings(39);
                        string Price = settings.Get_StringValue_Settings(40);

                        barcode.BarcodeWidth = B_Width;
                        barcode.BarcodeHigth = B_Height;
                        barcode.BarcodeColor = B_Color;
                        barcode.BarcodeFontSize = FontSize;
                        barcode.FontName = FontName;
                        barcode.PointX =float.Parse(PointX.Replace("f",""));
                        barcode.PointY = float.Parse(PointY.Replace("f", ""));

                        barcode.Company_Color = CompanyColor;
                        barcode.Company_FontName = CompanyFontName;
                        barcode.Company_FontSize = CompanyFontSize;
                        barcode.Company_Name_Size = CompanyNameSize;
                        barcode.Company_PointX = float.Parse(CompanyPointX.Replace("f", ""));
                        barcode.Company_PointY = float.Parse(CompanyPointY.Replace("f", ""));

                        barcode.Price_Color = PriceColor;
                        barcode.Price_FontName = PriceFontName;
                        barcode.Price_FontSize = PriceFontSize;
                        barcode.Price_Name_Size = PriceTagSize;
                        barcode.Price_PointX = float.Parse(PricePointX.Replace("f", ""));

                        string show = "";
                        DataTable dt = chk.DataTable("select * from Barcode where GeneratID='"+GenertID+"' ");
                        foreach(DataRow dr in dt.Rows)
                        {
                            show += string.Format(@" <div class='{0} m-b-30 m-t-30'>
                                                <img src='{1}' width='{2}' />
                                            </div> ", BarCode_Col_MD,barcode.barCode(dr["BarCode"].ToString(), PriceTagEnable? Price.Replace("{##}",dr["Product_Price"].ToString()):"", CompanyTagEnable? CompanyName:""), BarCode_Image_width);
                        }
                        pnlShowBarcode.Controls.Add(new LiteralControl(show));
                    }
                    else
                    {
                        Response.Redirect("~/Error?=Barcode id is not found. Try again!");
                    }


                }

            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }

        private Color FindColor(string Color)
        {
            if (Color == "AliceBlue")
                return System.Drawing.Color.AliceBlue;
            else if (Color == "AntiqueWhite")
                return System.Drawing.Color.AntiqueWhite;
            else if (Color == "Aqua")
                return System.Drawing.Color.Aqua;
            else if (Color == "Aquamarine")
                return System.Drawing.Color.Aquamarine;
            else if (Color == "Azure")
                return System.Drawing.Color.Azure;
            else if (Color == "Beige")
                return System.Drawing.Color.Beige;
            else if (Color == "Bisque")
                return System.Drawing.Color.Bisque;
            else if (Color == "Black")
                return System.Drawing.Color.Black;
            else if (Color == "BlanchedAlmond")
                return System.Drawing.Color.BlanchedAlmond;
            else if (Color == "Blue")
                return System.Drawing.Color.Blue;
            else if (Color == "BlueViolet")
                return System.Drawing.Color.BlueViolet;
            else if (Color == "Brown")
                return System.Drawing.Color.Brown;
            else if (Color == "Black")
                return System.Drawing.Color.Black;
            else if (Color == "BurlyWood")
                return System.Drawing.Color.BurlyWood;
            else if (Color == "CadetBlue")
                return System.Drawing.Color.CadetBlue;
            else if (Color == "Chartreuse")
                return System.Drawing.Color.Chartreuse;
            else if (Color == "Chocolate")
                return System.Drawing.Color.Chocolate;
            else if (Color == "Coral")
                return System.Drawing.Color.Coral;
            else if (Color == "CornflowerBlue")
                return System.Drawing.Color.CornflowerBlue;
            else if (Color == "Cornsilk")
                return System.Drawing.Color.Cornsilk;
            else if (Color == "Crimson")
                return System.Drawing.Color.Crimson;
            else if (Color == "Cyan")
                return System.Drawing.Color.Cyan;
            else if (Color == "DarkBlue")
                return System.Drawing.Color.DarkBlue;
            else if (Color == "DarkCyan")
                return System.Drawing.Color.DarkCyan;
            else if (Color == "DarkGoldenrod")
                return System.Drawing.Color.DarkGoldenrod;
            else if (Color == "DarkGray")
                return System.Drawing.Color.DarkGray;
            else if (Color == "DarkGreen")
                return System.Drawing.Color.DarkGreen;
            else if (Color == "DarkKhaki")
                return System.Drawing.Color.DarkKhaki;
            else if (Color == "DarkMagenta")
                return System.Drawing.Color.DarkMagenta;
            else if (Color == "DarkOliveGreen")
                return System.Drawing.Color.DarkOliveGreen;
            else if (Color == "DarkOrange")
                return System.Drawing.Color.DarkOrange;
            else if (Color == "DarkOrchid")
                return System.Drawing.Color.DarkOrchid;
            else if (Color == "DarkRed")
                return System.Drawing.Color.DarkRed;
            else if (Color == "DarkSalmon")
                return System.Drawing.Color.DarkSalmon;
            else if (Color == "DarkSeaGreen")
                return System.Drawing.Color.DarkSeaGreen;
            else if (Color == "DarkSlateBlue")
                return System.Drawing.Color.DarkSlateBlue;
            else if (Color == "DarkSlateGray")
                return System.Drawing.Color.DarkSlateGray;
            else if (Color == "DarkTurquoise")
                return System.Drawing.Color.DarkTurquoise;
            else if (Color == "DarkViolet")
                return System.Drawing.Color.DarkViolet;
            else if (Color == "DeepPink")
                return System.Drawing.Color.DeepPink;
            else if (Color == "DeepSkyBlue")
                return System.Drawing.Color.DeepSkyBlue;
            else if (Color == "DimGray")
                return System.Drawing.Color.DimGray;
            else if (Color == "DodgerBlue")
                return System.Drawing.Color.DodgerBlue;
            else if (Color == "Firebrick")
                return System.Drawing.Color.Firebrick;
            else if (Color == "FloralWhite")
                return System.Drawing.Color.FloralWhite;
            else if (Color == "ForestGreen")
                return System.Drawing.Color.ForestGreen;
            else if (Color == "Fuchsia")
                return System.Drawing.Color.Fuchsia;
            else if (Color == "Gainsboro")
                return System.Drawing.Color.Gainsboro;
            else if (Color == "GhostWhite")
                return System.Drawing.Color.GhostWhite;
            else if (Color == "Gold")
                return System.Drawing.Color.Gold;
            else if (Color == "Goldenrod")
                return System.Drawing.Color.Goldenrod;
            else if (Color == "Gray")
                return System.Drawing.Color.Gray;
            else if (Color == "Green")
                return System.Drawing.Color.Green;
            else if (Color == "GreenYellow")
                return System.Drawing.Color.GreenYellow;
            else if (Color == "Honeydew")
                return System.Drawing.Color.Honeydew;
            else if (Color == "HotPink")
                return System.Drawing.Color.HotPink;
            else if (Color == "IndianRed")
                return System.Drawing.Color.IndianRed;
            else if (Color == "Indigo")
                return System.Drawing.Color.Indigo;
            else if (Color == "Ivory")
                return System.Drawing.Color.Ivory;
            else if (Color == "Khaki")
                return System.Drawing.Color.Khaki;
            else if (Color == "Lavender")
                return System.Drawing.Color.Lavender;
            else if (Color == "LavenderBlush")
                return System.Drawing.Color.LavenderBlush;
            else if (Color == "LawnGreen")
                return System.Drawing.Color.LawnGreen;
            else if (Color == "LemonChiffon")
                return System.Drawing.Color.LemonChiffon;
            else if (Color == "LightBlue")
                return System.Drawing.Color.LightBlue;
            else if (Color == "LightCoral")
                return System.Drawing.Color.LightCoral;
            else if (Color == "LightCyan")
                return System.Drawing.Color.LightCyan;
            else if (Color == "LightGoldenrodYellow")
                return System.Drawing.Color.LightGoldenrodYellow;
            else if (Color == "LightGray")
                return System.Drawing.Color.LightGray;
            else if (Color == "LightGreen")
                return System.Drawing.Color.LightGreen;
            else if (Color == "LightPink")
                return System.Drawing.Color.LightPink;
            else if (Color == "LightSalmon")
                return System.Drawing.Color.LightSalmon;
            else if (Color == "LightSeaGreen")
                return System.Drawing.Color.LightSeaGreen;
            else if (Color == "LightSkyBlue")
                return System.Drawing.Color.LightSkyBlue;
            else if (Color == "LightSlateGray")
                return System.Drawing.Color.LightSlateGray;
            else if (Color == "LightSteelBlue")
                return System.Drawing.Color.LightSteelBlue;
            else if (Color == "LightYellow")
                return System.Drawing.Color.LightYellow;
            else if (Color == "Lime")
                return System.Drawing.Color.Lime;
            else if (Color == "LimeGreen")
                return System.Drawing.Color.LimeGreen;
            else if (Color == "Linen")
                return System.Drawing.Color.Linen;
            else if (Color == "Magenta")
                return System.Drawing.Color.Magenta;
            else if (Color == "Maroon")
                return System.Drawing.Color.Maroon;
            else if (Color == "MediumAquamarine")
                return System.Drawing.Color.MediumAquamarine;
            else if (Color == "MediumOrchid")
                return System.Drawing.Color.MediumOrchid;
            else if (Color == "MediumPurple")
                return System.Drawing.Color.MediumPurple;
            else if (Color == "MediumSeaGreen")
                return System.Drawing.Color.MediumSeaGreen;
            else if (Color == "MediumSlateBlue")
                return System.Drawing.Color.MediumSlateBlue;
            else if (Color == "MediumSpringGreen")
                return System.Drawing.Color.MediumSpringGreen;
            else if (Color == "MediumTurquoise")
                return System.Drawing.Color.MediumTurquoise;
            else if (Color == "MediumVioletRed")
                return System.Drawing.Color.MediumVioletRed;
            else if (Color == "MidnightBlue")
                return System.Drawing.Color.MidnightBlue;
            else if (Color == "MintCream")
                return System.Drawing.Color.MintCream;
            else if (Color == "MistyRose")
                return System.Drawing.Color.MistyRose;
            else if (Color == "Moccasin")
                return System.Drawing.Color.Moccasin;
            else if (Color == "NavajoWhite")
                return System.Drawing.Color.NavajoWhite;
            else if (Color == "Navy")
                return System.Drawing.Color.Navy;
            else if (Color == "OldLace")
                return System.Drawing.Color.OldLace;
            else if (Color == "Olive")
                return System.Drawing.Color.Olive;
            else if (Color == "OliveDrab")
                return System.Drawing.Color.OliveDrab;
            else if (Color == "Orange")
                return System.Drawing.Color.Orange;
            else if (Color == "OrangeRed")
                return System.Drawing.Color.OrangeRed;
            else if (Color == "Orchid")
                return System.Drawing.Color.Orchid;
            else if (Color == "PaleGoldenrod")
                return System.Drawing.Color.PaleGoldenrod;
            else if (Color == "PaleGreen")
                return System.Drawing.Color.PaleGreen;
            else if (Color == "PaleTurquoise")
                return System.Drawing.Color.PaleTurquoise;
            else if (Color == "PaleVioletRed")
                return System.Drawing.Color.PaleVioletRed;
            else if (Color == "PapayaWhip")
                return System.Drawing.Color.PapayaWhip;
            else if (Color == "PeachPuff")
                return System.Drawing.Color.PeachPuff;
            else if (Color == "Peru")
                return System.Drawing.Color.Peru;
            else if (Color == "Pink")
                return System.Drawing.Color.Pink;
            else if (Color == "Plum")
                return System.Drawing.Color.Plum;
            else if (Color == "PowderBlue")
                return System.Drawing.Color.PowderBlue;
            else if (Color == "Purple")
                return System.Drawing.Color.Purple;
            else if (Color == "Red")
                return System.Drawing.Color.Red;
            else if (Color == "RosyBrown")
                return System.Drawing.Color.RosyBrown;
            else if (Color == "RoyalBlue")
                return System.Drawing.Color.RoyalBlue;
            else if (Color == "SaddleBrown")
                return System.Drawing.Color.SaddleBrown;
            else if (Color == "Salmon")
                return System.Drawing.Color.Salmon;
            else if (Color == "SandyBrown")
                return System.Drawing.Color.SandyBrown;
            else if (Color == "SeaGreen")
                return System.Drawing.Color.SeaGreen;
            else if (Color == "SeaShell")
                return System.Drawing.Color.SeaShell;
            else if (Color == "Sienna")
                return System.Drawing.Color.Sienna;
            else if (Color == "Silver")
                return System.Drawing.Color.Silver;
            else if (Color == "SkyBlue")
                return System.Drawing.Color.SkyBlue;
            else if (Color == "SlateBlue")
                return System.Drawing.Color.SlateBlue;
            else if (Color == "SlateGray")
                return System.Drawing.Color.SlateGray;
            else if (Color == "Snow")
                return System.Drawing.Color.Snow;
            else if (Color == "SpringGreen")
                return System.Drawing.Color.SpringGreen;
            else if (Color == "SteelBlue")
                return System.Drawing.Color.SteelBlue;
            else if (Color == "Tan")
                return System.Drawing.Color.Tan;
            else if (Color == "Teal")
                return System.Drawing.Color.Teal;
            else if (Color == "Thistle")
                return System.Drawing.Color.Thistle;
            else if (Color == "Tomato")
                return System.Drawing.Color.Tomato;
            else if (Color == "Transparent")
                return System.Drawing.Color.Transparent;
            else if (Color == "Turquoise")
                return System.Drawing.Color.Turquoise;
            else if (Color == "Violet")
                return System.Drawing.Color.Violet;
            else if (Color == "Wheat")
                return System.Drawing.Color.Wheat;
            else if (Color == "White")
                return System.Drawing.Color.White;
            else if (Color == "WhiteSmoke")
                return System.Drawing.Color.WhiteSmoke;
            else if (Color == "Yellow")
                return System.Drawing.Color.Yellow;
            else if (Color == "YellowGreen")
                return System.Drawing.Color.YellowGreen;
            else
                return System.Drawing.Color.Black;


        }



    }
}