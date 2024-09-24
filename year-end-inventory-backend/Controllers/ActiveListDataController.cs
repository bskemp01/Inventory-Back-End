using Microsoft.AspNetCore.Mvc;
using year_end_inventory_backend.Models;

namespace year_end_inventory_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ActiveListDataController : Controller
{
    private readonly UnrestrictedTicketDbContext _context;

    public ActiveListDataController(UnrestrictedTicketDbContext context)
    {
        _context = context;
    }

    [HttpGet("getActiveListData")]
    [ProducesResponseType(200, Type = typeof(GetActiveListDataResponseModel))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult GetUnrestrictedTickets(int page = 1, int pageSize = 100)
    {
        try
        {
            // Calculate the number of records to skip based on the page and pageSize
            int skipAmount = (page - 1) * pageSize;

            // Query the UnrestrictedTickets table with pagination
            List<ActiveListData> activeListData = _context.ACTIVE_LIST_DATA
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList();

            var response = new
            {
                numberOfRows = activeListData.Count,
                currentPage = page,
                pageSize,
                totalPages = (int)Math.Ceiling((double)_context.ACTIVE_LIST_DATA.Count() / pageSize),
                data = activeListData
            };

            return Ok(response); // Return the paginated Active List Data Tickets as a JSON response
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log, or return an error response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}

