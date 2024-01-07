using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zabota.Dtos;
using Zabota.Models;
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
        return _ticketService.GetAllTickets();
    }

    /**
     * Должен возвращать тикет с messages
     */
    
    [HttpGet]
    [Route("{id:int}")]
    public TicketDto GetTicket(int id)
    {
        return _ticketService.GetTicketById(id);
    }


    /**
     *  Изменяет статус выбранного тикета на какой-то
     */
    [HttpPost]
    [Route("{id:int}/status/change")]
    public void ChangeTicketStatus(int id, [FromForm] TicketStatus status)
    {
        _ticketService.ChangeTicketStatus(id, status);
    }

    /**
     * Изменяет департамент, а также должен поставить Worker = null в Ticket
     */
    [HttpPost]
    [Route("{id:int}/department/change")]
    public void ChangeDepartment(int id, [FromForm] Department department)
    {
        _ticketService.ChangeTicketDepartment(id, department);
    }

    [HttpGet]
    [Route("from-user")]
    [Authorize]
    public JsonResult GetAllTicketsByUser()
    {
        var userId = Convert.ToInt32(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value);
        var a = _ticketService.GetTicketsByUser(userId)[0].Worker;
        var user = new UserDto(1, "asdf", "asdf", "asdf", "asdf", "asdf", Department.BACK_OFFICE_SUPPORT);
        var res = new JsonResult(user);
        return res;
    }
    /**
     * можешь роут тут поменять
     *
     * Устанавливает Worker = данный юзер
     */
    [HttpPost]
    [Route("{ticketId:int}/start-work")]
    [Authorize]
    public void ChangeWorker(int ticketId)
    {
        var userId = Convert.ToInt32(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value);
        _ticketService.ChangeTicketUser(ticketId, userId);
    }
    
}