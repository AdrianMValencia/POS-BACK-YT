using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces;

namespace POS.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherDocumentTypeController : ControllerBase
    {
        private readonly IVoucherDocumentTypeApplication _voucherDocumentTypeApplication;

        public VoucherDocumentTypeController(IVoucherDocumentTypeApplication voucherDocumentTypeApplication)
        {
            _voucherDocumentTypeApplication = voucherDocumentTypeApplication;
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectVoucherDocumentTypes()
        {
            var response = await _voucherDocumentTypeApplication.ListSelectVoucherDocumentTypes();
            return Ok(response);
        }
    }
}
