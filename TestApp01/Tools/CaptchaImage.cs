using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace TestApp01.Tools
{
    public class CaptchaImage
    {
        public const string CaptchaValueKey = "CaptchaImageText";
        private string text;
        private Bitmap image;
        private int width;
        private int height;
        private string familyName;
        private Random random = new Random();

        public string Text { get { return text; } }
        public Bitmap Image { get { return image; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public CaptchaImage(string s, int width, int height)
        {
            text = s;
            SetDimensions(width, height);
            GenerateImage();
        }
        public CaptchaImage(string s, int width, int height, string familyName)
        {
            text = s;
            SetDimensions(width, height);
            GenerateImage();
            SetFamilyName(familyName);
        }
        ~CaptchaImage()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        { 
            if(disposing)
            {
                image.Dispose();
            }
        }
        private void SetDimensions(int awidth, int aheight)
        {
            if (awidth <= 0)
            {
                throw new ArgumentOutOfRangeException("awidth", awidth, "Argument out of range, must be greater then zero");
            }
            if (aheight <= 0)
            {
                throw new ArgumentOutOfRangeException("aheight", aheight, "Argument out of range, must be greater then zero");
            }
            width = awidth;
            height = aheight;
        }
        private void SetFamilyName(string aFamilyName)
        {
            try
            {
                Font font = new Font(aFamilyName, 12);
                familyName = aFamilyName;
                font.Dispose();
            }
            catch (Exception)
            {
                familyName = FontFamily.GenericSerif.Name;
            }
        }
        private void GenerateImage()
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, width, height);

            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
            g.FillRectangle(hatchBrush, rect);

            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;
            do
            {
                fontSize--;
                font = new Font(familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(text, font);
            } while (size.Width > rect.Width);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 4f;
            PointF[] points = 
            {
                new PointF(random.Next(rect.Width)/v, random.Next(rect.Height)/v),
                new PointF(rect.Width - random.Next(rect.Width)/v, random.Next(rect.Height)/v),
                new PointF(random.Next(rect.Width)/v, rect.Height - random.Next(rect.Height)/v),
                new PointF(rect.Width - random.Next(rect.Width)/v, rect.Height - random.Next(rect.Height)/v)
            };
            Matrix matrix = new Matrix();
            matrix.Translate(0f, 0f);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0f);

            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.White);
            g.FillPath(hatchBrush, path);

            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width*rect.Height/30f); i++)
            {
                int x = random.Next(rect.Width);
                int y = random.Next(rect.Height);
                int w = random.Next(m/50);
                int h = random.Next(m/50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            image = bitmap;
        }
    }
}