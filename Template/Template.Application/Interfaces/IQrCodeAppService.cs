using System.Threading.Tasks;

namespace Template.Application.Interfaces
{
    public interface IQrCodeAppService
    {
        Task<byte[]> GenerateQrCodeFile(string url);
    }
}
