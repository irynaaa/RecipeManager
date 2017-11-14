using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace RecipeManager.Helpers
{
    public class WorkWithImage
    {
        public static Bitmap CreateImage(HttpPostedFileBase hpf, int maxWidth, int maxHeight)
        {
            if (hpf != null && hpf.ContentLength != 0 && hpf.ContentLength <= 10048576)
            {
                try
                {
                    using (Bitmap originalPic = new Bitmap(hpf.InputStream, true))
                    {
                        int originalWidth = originalPic.Width;
                        int originalHeight = originalPic.Height;
                        float rationX = (float)maxWidth / (float)originalWidth;
                        float rationY = (float)maxHeight / (float)originalHeight;
                        float ration = Math.Min(rationX, rationY);
                        int width = (int)Math.Round(originalWidth * ration);
                        int height = (int)Math.Round(originalHeight * ration);
                        using (Bitmap outBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                        {
                            using (Graphics oGraphics = Graphics.FromImage(outBmp))//graph pero in c#
                            {
                                oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                oGraphics.DrawImage(originalPic, 0, 0, width, height);

                                return new Bitmap(outBmp);
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            return null;
        }
    }
}