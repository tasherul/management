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
            Bitmap bitmap = new Bitmap(barcode.Length * __Barcode_Width, __Barcode_Higth);
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
    }
}