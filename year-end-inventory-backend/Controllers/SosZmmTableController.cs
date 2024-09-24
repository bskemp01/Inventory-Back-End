using Microsoft.AspNetCore.Mvc;
using year_end_inventory_backend.Models;

namespace year_end_inventory_backend.Controllers;
[Route("api/[controller]")]
[ApiController]

public class SosZmmTableController : ControllerBase
{
    private readonly SosTicketDbContext _context;

    public SosZmmTableController(SosTicketDbContext context)
    {
        _context = context;
    }
    //2810
    [HttpGet("getZMMTable")]
    [ProducesResponseType(200, Type = typeof(GetSosZmmTableDataResponseModel))]
    [ProducesResponseType(500)]
    public IActionResult GetZMMTable()
    {
        try
        {

            List<SosZmmModel> zmmTableData = _context.ZMM_ALL.ToList();

            if (zmmTableData == null)
            {
                return NotFound("No ZMM Table Data found.");
            }

            if (zmmTableData.Count == 0)
            {
                return NotFound("No ZMM Table Data found.");
            }

            var response = new
            {
                numberOfRows = zmmTableData.Count,
                data = zmmTableData
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log, or return an error response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("getZMMTable/{SalesDocument}")]
    [ProducesResponseType(200, Type = typeof(GetSosZmmSalesOrderResponseModel))]
    [ProducesResponseType(500)]
    public IActionResult GetZMMRow(decimal SalesDocument)
    {
        try
        {

            // Filter the rows based on SalesDocument
            List<SosZmmModel> zmmTableData = _context.ZMM_ALL
                .Where(row => row.SalesDocument == SalesDocument)
                .ToList();


            var response = new
            {
                numberOfRows = zmmTableData.Count,
                data = zmmTableData
            };

            if (response.numberOfRows == 0)
            {
                return NotFound($"Sales Document '{SalesDocument}' not found. Please Try again.");
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log, or return an error response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}

