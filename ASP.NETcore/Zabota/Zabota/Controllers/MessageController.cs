using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Services;

namespace Zabota.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MessageController : ControllerBase
{
    private MessageService _messageService { get; set; }

    public MessageController(MessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    [Route("ticket/message/{id:int}")]
    public JsonResult GetMessage(int id)
    {
        // return _MessageService.GetMessage(id);
        return null;
    }

    [HttpGet]
    [Route("ticket/{id:int}/messages/all")]
    public IResult GetAllMessagesByTicket(int id)
    {
        // return _MessageService.GetAllMessagesByTicket(id);
        return null;
    }

    [HttpPost]
    [Route("ticket/message")]
    public IResult AddMessage(MessageDto message)
    {
        // return _MessageService.PostMessage(message);
        return null;
    }
}