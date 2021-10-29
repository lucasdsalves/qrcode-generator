using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;

namespace Template.Controllers
{
    [ApiController]
    [Route("qrcode")]
    public class QrCodeController : ControllerBase
    {
        private IQrCodeAppService _qrCodeService;

        public QrCodeController(IQrCodeAppService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpGet("generate")]
        public async Task<FileResult> GenerateQrCode(string url)
        {
            return File(await _qrCodeService.GenerateQrCodeFile(url), "image/png");
        }
    }
}
