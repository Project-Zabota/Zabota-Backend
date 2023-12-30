using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Services;

namespace Zabota.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private MessageService MessageService { get; set; }

    public MessageController(MessageService messageService)
    {
        MessageService = messageService;
    }
    
    [HttpGet]
    [Route("all/ticket/{id:int}")]
    public IResult GetAllMessagesByTicket(int id)
    {
        // return _MessageService.GetAllMessagesByTicket(id);
        return null;
    }

    [HttpPost]
    [Route("add")]
    public IResult AddMessage(MessageDto message)
    {
        return MessageService.CreateMessage(message);
    }
}