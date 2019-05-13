using Nomad.Models.CasinoModels;
using Nomad.Models.Contact;
using Nomad.Services.Implementations;
using Nomad.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Mvc;


namespace Nomad.Controllers
{
    public class ContactController : SurfaceController
    {
        private readonly IMessageService _messageService;
        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            try
            {
                var res=_messageService.Add(new ContactViewModel
                {
                    Body = model.Body,
                    Email = model.Email,
                    Title = model.Title
                });
                if (res)
                    ViewBag.WasSent = true;
                return CurrentUmbracoPage();
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Contact error", ex);
            }
            return View();
        }
    }
}