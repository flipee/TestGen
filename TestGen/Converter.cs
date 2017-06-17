using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TestGen
{
    public static class Converter
    {
        public static Image ByteArrayToImage(byte[] imageinbytes)
        {
            Image image = null;

            if (imageinbytes != null)
            {
                using (var ms = new MemoryStream(imageinbytes))
                {
                    image = Image.FromStream(ms);
                }
            }

            return image;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            byte[] imageinbytes = null;

            if (image != null)
            {
                using (var ms = new MemoryStream())
                {
                    Image img = new Bitmap(image);

                    img.Save(ms, ImageFormat.Jpeg);
                    imageinbytes = ms.ToArray();
                }
            }

            return imageinbytes;
        }

    }
}
