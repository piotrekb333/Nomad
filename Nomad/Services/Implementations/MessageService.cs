using Nomad.Models.Contact;
using Nomad.Services.Interfaces;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public bool Add(ContactViewModel model)
        {
            _messageRepository.Insert(new DAL.Entities.Message
            {
                Body=model.Body,
                Email=model.Email,
                Title=model.Title
            });
            return true;
        }
    }
}