using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Services;

namespace Zabota.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TicketController : ControllerBase
{
    private TicketService _ticketService { get; set; }

    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    /**
     * Должен возвращать список тикетов без messages
     */
    [HttpGet]
    [Route("all")]
    public List<TicketDto> GetAllTickets()
    {
        // return _TicketService.GetAllTickets();
        return null;
    }

    /**
     * Должен возвращать тикет с messages
     */
    
    [HttpGet]
    [Route("{id:int}")]
    public TicketDto GetTicket(int id)
    {
        // return _TicketService.GetTicket(id);
        return null;
    }

    /**
     * Создаёт тикет и возвращает id 
     */
    [HttpPost]
    public JsonResult CreateTicket(TicketDto ticket)
    {
        // return _TicketService.PostTicket(ticket);
        return null;
    }
    
}