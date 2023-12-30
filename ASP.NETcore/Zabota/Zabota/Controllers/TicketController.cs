using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Models.Enums;
using Zabota.Services;

namespace Zabota.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private TicketService _ticketService { get; set; }

    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public int CreateTicket(TicketDto ticket)
    {
        return _ticketService.CreateTicket(ticket);
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
     *  Изменяет статус выбранного тикета на какой-то
     */
    [HttpPost]
    [Route("{id:int}/status/change")]
    public void ChangeTicketStatus(int id, TicketStatus status)
    {
        
    }

    /**
     * Изменяет департамент, а также должен поставить Worker = null в Ticket
     */
    [HttpPost]
    [Route("{id:int}/department/change")]
    public void ChangeDepartment(int id, [FromBody] Department department)
    {
        
    }

    /**
     * можешь роут тут поменять
     *
     * Устанавливает Worker = данный юзер
     */
    [HttpPost]
    [Route("{id:int}/start-work")]
    public void ChangeWorker()
    {
        
    }
    
}