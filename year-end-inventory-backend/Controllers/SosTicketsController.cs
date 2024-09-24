using Microsoft.AspNetCore.Mvc;
using year_end_inventory_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace year_end_inventory_backend.Controllers;
[Route("api/[controller]")]
[ApiController]

public class SosTicketsController : ControllerBase
{
    private readonly SosTicketDbContext _context;

    public SosTicketsController(SosTicketDbContext context)
    {
        _context = context;
    }

    [HttpGet("getSOSTickets")]
    [ProducesResponseType(200, Type = typeof(GetSOSTicketsResponseModel))]
    [ProducesResponseType(500)]
    public IActionResult GetSOSTickets(int page = 1, int pageSize = 100)
    {
        try
        {
            // Calculate the number of records to skip based on the page and pageSize
            int skipAmount = (page - 1) * pageSize;

            //Console.WriteLine(_context.SosTickets);  // Use the correct DbSet name
            // Use Entity Framework Core to query the SosTickets table and retrieve all records
            List<SosTicketModel> sosTickets = _context.SOS_TICKETS
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList();

            if (sosTickets.Count == 0)
            {
                return NotFound("No SOS Tickets found.");
            }

            var response = new
            {
                numberOfTickets = sosTickets.Count,
                data = sosTickets
            };

            return Ok(response); // Return the SOS Tickets as a JSON response
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log, or return an error response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }


    [HttpPost("addSOSTicket")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(500)]
    public IActionResult AddSOSTicket([FromBody] SosTicketModel newSosTicket)
    {
        try
        {
            if (newSosTicket == null)
            {
                return BadRequest("Invalid SOS Ticket data.");
            }

            string insertSql = @"
            INSERT INTO SOS_TICKETS 
            ([Ticket Number], [Plant Location], [Storage Location], [Sales Order], [Line Item], Material, Description, Quantity, [Area Location], [User Entered])
            VALUES
            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})";

            _context.Database.ExecuteSqlRaw(insertSql,
                newSosTicket.TicketNumber!,
                newSosTicket.PlantLocation!,
                newSosTicket.StorageLocation!,
                newSosTicket.SalesOrder!,
                newSosTicket.LineItem!,
                newSosTicket.Material!,
                newSosTicket.Description!,
                newSosTicket.Quantity!,
                newSosTicket.AreaLocation!,
                newSosTicket.UserEntered!);

            // Return a successful response
            return Ok($"SOS Ticket# {newSosTicket.TicketNumber} added successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut("updateSOSTicket")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(500)]
    public IActionResult UpdateSOSTicket([FromBody] SosTicketModel updatedSosTicket)
    {
        try
        {
            if (updatedSosTicket == null)
            {
                return BadRequest("Invalid SOS Ticket data.");
            }

            string updateSql = @"
            UPDATE SOS_TICKETS 
            SET 
                [Plant Location] = {0}, 
                [Storage Location] = {1}, 
                Material = {2}, 
                Description = {3}, 
                Quantity = {4}, 
                [Area Location] = {5}
            WHERE 
                [Ticket Number] = {6} AND 
                [Sales Order] = {7} AND 
                [Line Item] = {8}";

            _context.Database.ExecuteSqlRaw(updateSql,
                updatedSosTicket.PlantLocation!,
                updatedSosTicket.StorageLocation!,
                updatedSosTicket.Material!,
                updatedSosTicket.Description!,
                updatedSosTicket.Quantity!,
                updatedSosTicket.AreaLocation!,
                updatedSosTicket.TicketNumber!,
                updatedSosTicket.SalesOrder!,
                updatedSosTicket.LineItem!
            );

            // Return the updated SOS Ticket
            return Ok($"SOS Ticket# {updatedSosTicket.TicketNumber} updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("getSOSTicket")]
    [ProducesResponseType(200, Type = typeof(SosTicketModel))]
    [ProducesResponseType(500)]
    public IActionResult GetSOSTicket([FromQuery] SosTicketModel searchCriteria)
    {
        try
        {
            // Find the SOS Ticket based on the provided search criteria
            var sosTicket = _context.SOS_TICKETS
                .FirstOrDefault(t => t.TicketNumber == searchCriteria.TicketNumber
                                       && t.SalesOrder == searchCriteria.SalesOrder
                                       && t.LineItem == searchCriteria.LineItem);

            if (sosTicket == null)
            {
                return NotFound($"SOS Ticket not found with provided search criteria.");
            }

            return Ok(sosTicket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("getLineItemsBySalesOrder/{salesOrder}")]
    [ProducesResponseType(200, Type = typeof(List<string>))]
    [ProducesResponseType(500)]
    public IActionResult GetLineItemsBySalesOrder(decimal salesOrder)
    {
        try
        {
            // Find line items based on the provided sales order
            var lineItems = _context.SOS_TICKETS
                .Where(t => t.SalesOrder == salesOrder)
                .Select(t => t.LineItem.ToString())
                .Distinct()
                .ToList();

            if (lineItems.Count == 0)
            {
                return NotFound($"No line items found for SalesOrder {salesOrder}.");
            }

            return Ok(lineItems);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}

