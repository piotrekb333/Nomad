using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Models.ArticleModels
{
    public class ArticleModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DatePublished { get; set; }
        public string SiteUrl { get; set; }
    }
}