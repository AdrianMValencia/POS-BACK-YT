using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces;

namespace POS.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeApplication _documentTypeApplication;

        public DocumentTypeController(IDocumentTypeApplication documentTypeApplication)
        {
            _documentTypeApplication = documentTypeApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListDocumentTypes()
        {
            var response = await _documentTypeApplication.ListDocumentTypes();
            return Ok(response);
        }
    }
}
