using Nomad.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Services.Interfaces
{
    public interface IMessageService
    {
        bool Add(ContactViewModel model);
    }
}