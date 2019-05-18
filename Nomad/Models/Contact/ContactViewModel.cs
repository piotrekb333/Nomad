using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomad.Models.Contact
{
    public class ContactViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]

        public string Body { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}