using Nomad.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Services.Interfaces
{
    public interface INewsletterService
    {
        SaveToNewsletterResponse SaveToNewsletter(string email);
    }
}