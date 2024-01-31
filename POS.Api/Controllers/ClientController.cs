using Microsoft.AspNetCore.Mvc;
using POS.Application.Commons.Bases.Request;
using POS.Application.Dtos.Client.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public ClientController(IClientApplication clientApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _clientApplication = clientApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListClients([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _clientApplication.ListClient(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnsClients();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }

            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectClients()
        {
            var response = await _clientApplication.ListSelectClients();
            return Ok(response);
        }

        [HttpGet("{clientId:int}")]
        public async Task<IActionResult> ClientById(int clientId)
        {
            var response = await _clientApplication.ClientById(clientId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterClient([FromBody] ClientRequestDto requestDto)
        {
            var response = await _clientApplication.RegisterClient(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{clientId:int}")]
        public async Task<IActionResult> EditClient(int clientId, [FromBody] ClientRequestDto requestDto)
        {
            var response = await _clientApplication.EditClient(clientId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{clientId:int}")]
        public async Task<IActionResult> RemoveClient(int clientId)
        {
            var response = await _clientApplication.RemoveClient(clientId);
            return Ok(response);
        }
    }
}
