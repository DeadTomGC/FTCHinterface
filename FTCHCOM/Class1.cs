using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCTH_Descriptor;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FTCHpy
{
    public class FTCHcalc
    {
        double[] FCTHTable = new double[192];
        int[,] img;
        //int count = 0; for debugging
        public void setImageSize(int i, int j)
        {
            img = new int[i,j];

        }
        public void setVal(int i, int j, int color)
        {
            img[i,j] = color;

        }
        public int calc(){
            try
            {
                FCTH_Descriptor.FCTH get = new FCTH_Descriptor.FCTH();
                Bitmap bmp = new Bitmap(img.GetLength(0), img.GetLength(1));

                for (int i = 0; i < img.GetLength(0); i++)
                {
                    for (int j = 0; j < img.GetLength(1); j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(img[i, j]));
                    }
                }
                //count++; //following 2 lines were used for debugging the image data transfer
                
                //bmp.Save("shirt" + count + ".bmp",System.Drawing.Imaging.ImageFormat.Jpeg);
                FCTHTable = get.Apply(bmp, 2);
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public double result(int i)
        {
            return FCTHTable[i];
        }
    }
}
