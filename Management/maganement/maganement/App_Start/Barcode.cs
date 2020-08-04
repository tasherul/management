using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing.Text;



namespace maganement
{
    public class Barcodes
    {
        
        private int __Barcode_Width=40;
        private int __Barcode_Higth = 150;
        private int __Barcode_Font_Size = 20;
        private float __Point_X = 2f;
        private float __Point_Y = 2f;
        private Color __Barcode_Color = Color.Black;
        private int __Image_Height;
        private int __Image_Width;
        private string __Font_Name = "IDAutomationHC39M";

        public int BarcodeWidth { set { __Barcode_Width = value; } }
        public int BarcodeHigth { set { __Barcode_Higth = value; } }
        public int BarcodeFontSize { set { __Barcode_Font_Size = value; } }
        public float PointX { set { __Point_X = value; } }
        public float PointY { set { __Point_Y = value; } }
        public Color BarcodeColor { set { __Barcode_Color = value; } }
        public int ImageHeigth { get { return __Image_Height; } }
        public int ImageWidth { get { return __Image_Width; } }
        public string FontName { set { __Font_Name = value; } }

        public string BarcodeGenerator(string Code)
        {
            return PrivateImageGenerator(Code);
        }

        private string PrivateImageGenerator(string code)
        {
            string barcode = code;
            Bitmap bitmap = new Bitmap(__Barcode_Width, __Barcode_Higth);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                Font oFont = new System.Drawing.Font(__Font_Name, __Barcode_Font_Size);
                PointF point = new PointF(__Point_X, __Point_Y);
                SolidBrush black = new SolidBrush(__Barcode_Color);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphic.DrawString(barcode, oFont, black, point);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                __Image_Height = bitmap.Height;
                __Image_Width = bitmap.Width;
                var base64Data = Convert.ToBase64String(ms.ToArray());
                return "data:image/gif;base64," + base64Data;
            }


        }




        private int __Company_Name_Size = 13;
        private float __Company_PointX = 2f;
        private float __Company_PointY = 2f;
        private string __Company_FontName = "Arial";
        private int __Company_FontSize = 8;
        private Color __Company_Color = Color.Blue;

        public int Company_Name_Size { set { __Company_Name_Size = value; } }
        public float Company_PointX { set { __Company_PointX = value; } }
        public float Company_PointY { set { __Company_PointY = value; } }
        public string Company_FontName { set { __Company_FontName = value; } }
        public int Company_FontSize { set { __Company_FontSize = value; } }
        public Color Company_Color { set { __Company_Color = value; } }

        private int __Price_Tag_Size = 13;
        private float __Price_PointX = 5f;
        private string __Price_Font_Name = "Arial";
        private int __Price_FontSize = 8;
        private Color __Price_Color = Color.Blue;

        public int Price_Name_Size { set { __Price_Tag_Size = value; } }
        public float Price_PointX { set { __Price_PointX = value; } }
        public string Price_FontName { set { __Price_Font_Name = value; } }
        public int Price_FontSize { set { __Price_FontSize = value; } }
        public Color Price_Color { set { __Price_Color = value; } }

        public string barCode (string code,string price,string CompanyName)
        {
            
            int CompanyNameSize = __Company_Name_Size;
            float CompanyPointX = __Company_PointX;
            float CompanyPointY = __Company_PointY;
            string Company_FontName = __Company_FontName;
            int Company_FontSize = __Company_FontSize;
            Color Company_Color = __Company_Color;

            int PriceSize = __Price_Tag_Size;
            float PricePointX = __Price_PointX;
            string Price_FontName = __Price_Font_Name;
            int Price_FontSize = __Price_FontSize;
            Color Price_Color = __Price_Color;

            if (price=="")
            {
                PriceSize = 0;
            }
            if(CompanyName=="")
            {
                CompanyNameSize = 0;
            }


            string barcode = code;
            Bitmap bitmap = new Bitmap(__Barcode_Width, CompanyNameSize + __Barcode_Higth+ PriceSize);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                Font oFont = new System.Drawing.Font(__Font_Name, __Barcode_Font_Size);
                PointF point = new PointF(__Point_X, __Point_Y+ CompanyNameSize-1);
                SolidBrush Bcolor = new SolidBrush(__Barcode_Color);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);

                PointF pointCompany = new PointF(CompanyPointX, CompanyPointY);
                Font oFontCompany = new System.Drawing.Font(Company_FontName, Company_FontSize);
                SolidBrush CompanyColor = new SolidBrush(Company_Color);
                graphic.DrawString(CompanyName, oFontCompany, CompanyColor, pointCompany);

                graphic.DrawString(barcode, oFont, Bcolor, point);

                PointF pointPrice = new PointF(PricePointX, CompanyNameSize+__Barcode_Higth );
                Font oFontPrice = new System.Drawing.Font(Price_FontName, Price_FontSize);
                SolidBrush PriceColor = new SolidBrush(Price_Color);
                graphic.DrawString(price, oFontPrice, PriceColor, pointPrice);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                __Image_Height = bitmap.Height;
                __Image_Width = bitmap.Width;
                var base64Data = Convert.ToBase64String(ms.ToArray());
                return "data:image/gif;base64," + base64Data;
            }
        }


        public string[] BarcodeAllColor = new string[]
        {
         //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF0F8FF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "AliceBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFAEBD7.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "AntiqueWhite",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00FFFF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Aqua",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF7FFFD4.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Aquamarine",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF0FFFF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Azure",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF5F5DC.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Beige",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFE4C4.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Bisque",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF000000.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Black",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFEBCD.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "BlanchedAlmond",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF0000FF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Blue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF8A2BE2.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "BlueViolet",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFA52A2A.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Brown",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDEB887.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "BurlyWood",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF5F9EA0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "CadetBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF7FFF00.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Chartreuse",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFD2691E.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Chocolate",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF7F50.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Coral",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF6495ED.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "CornflowerBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFF8DC.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Cornsilk",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDC143C.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Crimson",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00FFFF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Cyan",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00008B.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF008B8B.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkCyan",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFB8860B.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkGoldenrod",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFA9A9A9.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkGray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF006400.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFBDB76B.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkKhaki",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF8B008B.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkMagenta",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF556B2F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkOliveGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF8C00.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkOrange",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF9932CC.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkOrchid",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF8B0000.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkRed",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFE9967A.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkSalmon",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF8FBC8F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkSeaGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF483D8B.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkSlateBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF2F4F4F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkSlateGray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00CED1.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkTurquoise",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF9400D3.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DarkViolet",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF1493.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DeepPink",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00BFFF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DeepSkyBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF696969.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DimGray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF1E90FF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "DodgerBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFB22222.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Firebrick",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFAF0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "FloralWhite",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF228B22.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "ForestGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF00FF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Fuchsia",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDCDCDC.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Gainsboro",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF8F8FF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "GhostWhite",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFD700.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Gold",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDAA520.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Goldenrod",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF808080.
        //
        // Returns:
        //     A System.Drawing.Color strcture representing a system-defined color.
       "Gray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF008000.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Green",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFADFF2F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "GreenYellow",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF0FFF0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Honeydew",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF69B4.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "HotPink",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFCD5C5C.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "IndianRed",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF4B0082.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Indigo",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFFF0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Ivory",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF0E68C.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Khaki",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFE6E6FA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Lavender",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFF0F5.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LavenderBlush",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF7CFC00.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LawnGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFACD.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LemonChiffon",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFADD8E6.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF08080.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightCoral",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFE0FFFF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightCyan",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFAFAD2.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightGoldenrodYellow",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFD3D3D3.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightGray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF90EE90.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFB6C1.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightPink",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFA07A.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightSalmon",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF20B2AA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightSeaGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF87CEFA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightSkyBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF778899.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightSlateGray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFB0C4DE.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightSteelBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFFE0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LightYellow",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00FF00.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Lime",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF32CD32.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "LimeGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFAF0E6.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Linen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF00FF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Magenta",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF800000.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Maroon",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF66CDAA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumAquamarine",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF0000CD.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFBA55D3.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumOrchid",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF9370DB.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumPurple",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF3CB371.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumSeaGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF7B68EE.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumSlateBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00FA9A.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumSpringGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF48D1CC.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumTurquoise",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFC71585.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MediumVioletRed",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF191970.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MidnightBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF5FFFA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MintCream",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFE4E1.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "MistyRose",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFE4B5.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Moccasin",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFDEAD.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "NavajoWhite",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF000080.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Navy",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFDF5E6.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "OldLace",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF808000.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Olive",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF6B8E23.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "OliveDrab",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFA500.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Orange",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF4500.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "OrangeRed",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDA70D6.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Orchid",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFEEE8AA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PaleGoldenrod",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF98FB98.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PaleGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFAFEEEE.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PaleTurquoise",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDB7093.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PaleVioletRed",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFEFD5.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PapayaWhip",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFDAB9.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PeachPuff",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFCD853F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Peru",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFC0CB.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Pink",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFDDA0DD.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Plum",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFB0E0E6.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "PowderBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF800080.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Purple",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF0000.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Red",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFBC8F8F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "RosyBrown",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF4169E1.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "RoyalBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF8B4513.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SaddleBrown",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFA8072.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Salmon",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF4A460.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SandyBrown",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF2E8B57.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SeaGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFF5EE.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SeaShell",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFA0522D.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Sienna",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFC0C0C0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Silver",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF87CEEB.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SkyBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF6A5ACD.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SlateBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF708090.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SlateGray",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFAFA.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Snow",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF00FF7F.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SpringGreen",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF4682B4.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "SteelBlue",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFD2B48C.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Tan",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF008080.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Teal",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFD8BFD8.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Thistle",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFF6347.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Tomato",
        //
        // Summary:
        //     Gets a system-defined color.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Transparent",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF40E0D0.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Turquoise",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFEE82EE.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Violet",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF5DEB3.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Wheat",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFFFF.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "White",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFF5F5F5.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "WhiteSmoke",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FFFFFF00.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "Yellow",
        //
        // Summary:
        //     Gets a system-defined color that has an ARGB value of #FF9ACD32.
        //
        // Returns:
        //     A System.Drawing.Color representing a system-defined color.
       "YellowGreen"
    };



    }
    
}