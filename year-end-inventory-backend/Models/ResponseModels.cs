using year_end_inventory_backend.Models;

namespace year_end_inventory_backend.Models;

public class GetSOSTicketsResponseModel
{
    public int NumberOfTickets { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public List<SosTicketModel> Data { get; set; }
}

public class GetUnrestrictedTicketsResponseModel
{
    public int NumberOfTickets { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public List<UnrestrictedTicketModel> Data { get; set; }
}

public class GetActiveListDataResponseModel
{
    public int NumberOfRows { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public List<ActiveListData> Data { get; set; }
}

public class GetUnrestrictedZmmTableDataResponseModel
{
    public int NumberOfRows { get; set; }
    public List<UnrestrictedZmmModel> Data { get; set; }
}

public class GetSosZmmTableDataResponseModel
{
    public int NumberOfRows { get; set; }
    public List<SosZmmModel> Data { get; set; }
}

public class GetSosZmmSalesOrderResponseModel
{
    public int NumberOfRows { get; set; }
    public List<SosZmmModel> Data { get; set; }
}