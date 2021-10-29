using QRCoder;
using System.Drawing;
using System.IO;

namespace Template.CC.Utils
{
    public static class ExtensionMethods
    {
        public static Bitmap GenerateImage(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCode = new QRCode(qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q));

            return qrCode.GetGraphic(10);
        }

        public static byte[] GenerateByteArray(string url)
        {
            return ImageToByte(GenerateImage(url));
        }

        private static byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();

            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return stream.ToArray();
        }
    }
}
