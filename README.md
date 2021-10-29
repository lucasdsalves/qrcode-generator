This API project shows how to generate a QRCode from a URL using QRCoder package.

# Used packages
```
dotnet add package QRCoder
```

# QRCode generate
<b><i>ExtensionMethods.cs </b></i>
```csharp
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
```

<b><i>QrCodeAppService.cs </b></i>
```csharp
        public Task<byte[]> GenerateQrCodeFile(string url)
        {
            return Task.FromResult(ExtensionMethods.GenerateByteArray(url));
        }
```

<b><i>QrCodeController.cs </b></i>
```csharp
        [HttpGet("generate")]
        public async Task<FileResult> GenerateQrCode(string url)
        {
            return File(await _qrCodeService.GenerateQrCodeFile(url), "image/png");
        }
```
##

Result available through API swagger endpoint /qrcode/generate