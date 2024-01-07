using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Mapper;
using Zabota.Models;
using Zabota.Models.Enums;
using Zabota.Repositories.Interfaces;
using Zabota.Repositories.Implimentations;

namespace Zabota.Services
{
    public class MessageService
    {
        private TicketRepository _Tickets { get; set; }
        private IBaseRepository<Message> _Messages { get; set; }
        private readonly HttpClient _Client = new ();
        private readonly IMapper<Message, MessageDto> MessageMapper;

        public MessageService(TicketRepository ticketRepository, IBaseRepository<Message> messages, IMapper<Message, MessageDto> messageMapper)
        {
            _Tickets = ticketRepository;
            _Messages = messages;
            MessageMapper = messageMapper;
        }

        public JsonResult GetMessage(int id)
        {
            return new JsonResult(_Messages.Get(id));
        }

        public IResult GetAllMessagesByTicket(int id)
        {
            var ticket = _Tickets.Get(id);
            if (ticket != null)
            {
                return Results.Json(ticket.Messages);
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }

        public IResult CreateMessage(MessageDto messageDto)
        {
            var ticket = _Tickets.Get(messageDto.TicketId);
            if (ticket == null)
                return Results.NotFound(new { message = "Заявка не найдена" });

            var message = MessageMapper.ToModel(messageDto);
            
            if (message.Sender.Type.Equals(SenderType.EMPOLYEE_ZABOTA))
            {
                _Client.PostAsync(ticket.Webhook, JsonContent
                    .Create("{\"ticket\": " + ticket.Id + ",\"action\": \"NEW_MESSAGE\",\"data\": {\"text\": \"" + message.Text + "\"}}"));
            }
            
            message.Ticket = ticket;
            message.Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            _Messages.Create(message);
            
            return Results.Json("ОК");
        }
    }
}
