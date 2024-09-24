using Microsoft.AspNetCore.Mvc;
using year_end_inventory_backend.Models;

namespace year_end_inventory_backend.Controllers;
[Route("api/[controller]")]
[ApiController]

public class UnrestrictedZmmTableController : ControllerBase
{
    private readonly UnrestrictedTicketDbContext _context;

    public UnrestrictedZmmTableController(UnrestrictedTicketDbContext context)
    {
        _context = context;
    }

    [HttpGet("getZMMTable")]
    [ProducesResponseType(200, Type = typeof(GetUnrestrictedZmmTableDataResponseModel))]
    [ProducesResponseType(500)]
    public IActionResult GetZMMTable(int page = 1, int pageSize = 100)
    {
        try
        {
            int skipAmount = (page - 1) * pageSize;

            List<UnrestrictedZmmModel> zmmTableData = _context.ZMM_ALL
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList();

            if (zmmTableData.Count == 0)
            {
                return NotFound("No ZMM Table Data found.");
            }

            var response = new
            {
                numberOfRows = zmmTableData.Count,
                currentPage = page,
                pageSize,
                totalPages = (int)Math.Ceiling((double)_context.ZMM_ALL.Count() / pageSize),
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

    [HttpGet("getZMMTableRow/{material}")]
    [ProducesResponseType(200, Type = typeof(UnrestrictedZmmModel))]
    [ProducesResponseType(500)]
    public IActionResult GetZMMRow(string material)
    {
        try
        {
            
            var zmmRow = _context.ZMM_ALL.Find(material);

            if (zmmRow == null)
            {
                return NotFound($"ZMM Row with Material '{material}' not found.");
            }

            return Ok(zmmRow);
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log, or return an error response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}

