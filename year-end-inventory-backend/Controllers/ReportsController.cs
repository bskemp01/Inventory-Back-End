using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace year_end_inventory_backend.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ReportsController : ControllerBase
{
    private readonly string sosConnectionString = "Server=10.122.2.96;Database=SalesOrderSpecificDB;User Id=AppUser;Password=@ppUser1!;TrustServerCertificate=True";
    private readonly string unrConnectionString = "Server=10.122.2.96;Database=UnrestrictedInventoryDB;User Id=AppUser;Password=@ppUser1!;TrustServerCertificate=True";
    
    [HttpGet("UploadReport/{database}/{plant}")]
    [ProducesResponseType(200, Type = typeof(List<string>))]
    [ProducesResponseType(500)]
    public IActionResult UploadReport(string database, int plant)
    {
        var connectionString = "";
        List<Dictionary<string, object>> uploadReport = new List<Dictionary<string, object>>();
        if (database == "SOS") 
        {
            connectionString = sosConnectionString;
        }

        if (database == "UNR")
        {
            connectionString = unrConnectionString;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("Upload_Report", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Plant", SqlDbType.Int) { Value = plant });

                try
                {
                    connection.Open();

                    // Execute the stored procedure
                    SqlDataReader reader = command.ExecuteReader();

                    List<string> columnNames = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        foreach (string columnName in columnNames)
                        {
                            row.Add(columnName, reader[columnName].ToString()!);
                        }

                        uploadReport.Add(row);
                    }

                    if (uploadReport.Count > 0)
                    {
                        return Ok(uploadReport);
                    }
                    else
                    {
                        return NotFound("No data found");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error: " + ex.Message);
                }
            }
        }
    }

    [HttpGet("AllTicketEntriesReport/{database}/{plant}")]
    [ProducesResponseType(200, Type = typeof(List<string>))]
    [ProducesResponseType(500)]
    public IActionResult AllTicketEntriesReport(string database, int plant)
    {
        var connectionString = "";
        if (database == "SOS")
        {
            connectionString = sosConnectionString;
        }

        if (database == "UNR")
        {
            connectionString = unrConnectionString;
        }
        List<Dictionary<string, object>> allTicketEntriesReport = new List<Dictionary<string, object>>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("All_Ticket_Entries_Report", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Plant", SqlDbType.Int) { Value = plant });

                try
                {
                    connection.Open();

                    // Execute the stored procedure
                    SqlDataReader reader = command.ExecuteReader();

                    List<string> columnNames = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        foreach (string columnName in columnNames)
                        {
                            row.Add(columnName, reader[columnName].ToString()!);
                        }

                        allTicketEntriesReport.Add(row);
                    }

                    if (allTicketEntriesReport.Count > 0)
                    {
                        return Ok(allTicketEntriesReport);
                    }
                    else
                    {
                        return NotFound("No data found");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error: " + ex.Message);
                }
            }
        }
    }

    [HttpGet("DifferenceReport/{database}/{plant}")]
    [ProducesResponseType(200, Type = typeof(List<string>))]
    [ProducesResponseType(500)]
    public IActionResult DifferenceReport(string database, int plant)
    {
        var connectionString = "";
        if (database == "SOS")
        {
            connectionString = sosConnectionString;
        }

        if (database == "UNR")
        {
            connectionString = unrConnectionString;
        }
        List<Dictionary<string, object>> differeneceReport = new List<Dictionary<string, object>>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("Difference_Report", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Plant", SqlDbType.Int) { Value = plant });

                try
                {
                    connection.Open();

                    // Execute the stored procedure
                    SqlDataReader reader = command.ExecuteReader();

                    List<string> columnNames = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        foreach (string columnName in columnNames)
                        {
                            row.Add(columnName, reader[columnName].ToString()!);
                        }

                        differeneceReport.Add(row);
                    }

                    if (differeneceReport.Count > 0)
                    {
                        return Ok(differeneceReport);
                    }
                    else
                    {
                        return NotFound("No data found");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error: " + ex.Message);
                }
            }
        }
    }

    [HttpGet("MissingTicketReport/{database}/{plant}/min={min}max={max}")]
    [ProducesResponseType(200, Type = typeof(List<string>))]
    [ProducesResponseType(500)]
    public IActionResult MissingTicketReport(string database, int plant, int min, int max)
    {
        var connectionString = "";
        if (database == "SOS")
        {
            connectionString = sosConnectionString;
        }

        if (database == "UNR")
        {
            connectionString = unrConnectionString;
        }
        List<Dictionary<string, object>> missingTicketReport = new List<Dictionary<string, object>>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("Missing_Ticket_Report", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Min", SqlDbType.Int) { Value = min });
                command.Parameters.Add(new SqlParameter("@Max", SqlDbType.Int) { Value = max });

                try
                {
                    connection.Open();

                    // Execute the stored procedure
                    SqlDataReader reader = command.ExecuteReader();

                    List<string> columnNames = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        foreach (string columnName in columnNames)
                        {
                            row.Add(columnName, reader[columnName].ToString()!);
                        }

                        missingTicketReport.Add(row);
                    }

                    if (missingTicketReport.Count > 0)
                    {
                        return Ok(missingTicketReport);
                    }
                    else
                    {
                        return NotFound("No data found");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error: " + ex.Message);
                }
            }
        }
    }
}

