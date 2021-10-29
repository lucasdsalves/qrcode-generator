using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.CC.Utils;

namespace Template.Application.Services
{
    public class QrCodeAppService : IQrCodeAppService
    {
        public Task<byte[]> GenerateQrCodeFile(string url)
        {
            return Task.FromResult(ExtensionMethods.GenerateByteArray(url));
        }
    }
}
