using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using year_end_inventory_backend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace year_end_inventory_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UnrestrictedTicketsController : ControllerBase
{
    private readonly UnrestrictedTicketDbContext _context;

    public UnrestrictedTicketsController(UnrestrictedTicketDbContext context)
    {
        _context = context;
    }

    [HttpGet("getUnrestrictedTickets")]
    [ProducesResponseType(200, Type = typeof(GetUnrestrictedTicketsResponseModel))]
    [ProducesResponseType(500)]
    public IActionResult GetUnrestrictedTickets(int page = 1, int pageSize = 100)
    {
        try
        {
            // Calculate the number of records to skip based on the page and pageSize
            int skipAmount = (page - 1) * pageSize;

            // Query the UnrestrictedTickets table with pagination
            List<UnrestrictedTicketModel> unrestrictedTickets = _context.UNRESTRICTED_TICKETS
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList();

            if (unrestrictedTickets.Count == 0)
            {
                return NotFound("No Unrestricted Tickets found.");
            }

            var response = new
            {
                numberOfTickets = unrestrictedTickets.Count,
                currentPage = page,
                pageSize,
                totalPages = (int)Math.Ceiling((double)_context.UNRESTRICTED_TICKETS.Count() / pageSize),
                data = unrestrictedTickets
            };

            return Ok(response); // Return the paginated Unrestricted Tickets as a JSON response
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log, or return an error response
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPost("addUnrestrictedTicket")]
    [ProducesResponseType(201, Type = typeof(string))]
    [ProducesResponseType(500)]
    public IActionResult AddUnrestrictedTicket([FromBody] UnrestrictedTicketModel newUnrestrictedTicket)
    {
        try
        {
            if (newUnrestrictedTicket == null)
            {
                return BadRequest("Invalid Unrestricted Ticket data.");
            }

            string insertSql = @"
            INSERT INTO UNRESTRICTED_TICKETS 
            ([Ticket Number], [Part Number], [Storage Location], [Description], [Unit of Measure], Quantity, [Plant Location], [Area Location], [User Entered])
            VALUES
            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})";

            _context.Database.ExecuteSqlRaw(insertSql,
                newUnrestrictedTicket.TicketNumber!,
                newUnrestrictedTicket.PartNumber!,
                newUnrestrictedTicket.StorageLocation!,
                newUnrestrictedTicket.Description!,
                newUnrestrictedTicket.UnitOfMeasure!,
                newUnrestrictedTicket.Quantity!,
                newUnrestrictedTicket.PlantLocation!,
                newUnrestrictedTicket.AreaLocation!,
                newUnrestrictedTicket.UserEntered!);

            // Return a successful response
            return Ok($"Unrestricted Ticket# {newUnrestrictedTicket.TicketNumber} added successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut("updateUnrestrictedTicket")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(500)]
    public IActionResult UpdateUnrestrictedTicket([FromBody] UnrestrictedTicketModel updatedUnrestrictedTicket)
    {
        try
        {
            if (updatedUnrestrictedTicket == null)
            {
                return BadRequest("Invalid Unrestricted Ticket data.");
            }


            string updateSql = @"
            UPDATE UNRESTRICTED_TICKETS 
            SET 
                [Part Number] = {1}, 
                [Storage Location] = {2},                
                [Description] = {3}, 
                [Unit of Measure] = {4}, 
                Quantity = {5}, 
                [Plant Location] = {6}, 
                [Area Location] = {7}
            WHERE 
                [Ticket Number] = {0}";

            _context.Database.ExecuteSqlRaw(updateSql,
                updatedUnrestrictedTicket.TicketNumber!,
                updatedUnrestrictedTicket.PartNumber!,
                updatedUnrestrictedTicket.StorageLocation!,
                updatedUnrestrictedTicket.Description!,
                updatedUnrestrictedTicket.UnitOfMeasure!,
                updatedUnrestrictedTicket.Quantity!,
                updatedUnrestrictedTicket.PlantLocation!,
                updatedUnrestrictedTicket.AreaLocation!
            );

            // Return the updated SOS Ticket
            return Ok($"Unrestricted Ticket# {updatedUnrestrictedTicket.TicketNumber} updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("getUnrestrictedTicket/{ticketNumber}")]
    [ProducesResponseType(200, Type = typeof(UnrestrictedTicketModel))]
    [ProducesResponseType(500)]
    public IActionResult GetUnrestrictedTicket(double ticketNumber)
    {
        try
        {
            var unrestrictedTicket = _context.UNRESTRICTED_TICKETS.Find(ticketNumber);

            if (unrestrictedTicket == null)
            {
                return NotFound($"Unrestricted Ticket with TicketNumber {ticketNumber} not found.");
            }

            return Ok(unrestrictedTicket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}

