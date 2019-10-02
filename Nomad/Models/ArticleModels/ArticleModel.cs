using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Models.ArticleModels
{
    public class ArticleModel
    {
        public ArticleModel(string line)
        {
            var split = line.Split(',');
            int catid = 0;
            int.TryParse(split[6], out catid);
            Title = split[2];
            Body = split[4];
            DatePublished = DateTime.UtcNow;
            CategoryId = catid;
        }
        public ArticleModel() { }


        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DatePublished { get; set; }
        public string SiteUrl { get; set; }
        public int CategoryId { get; set; }
        public string ImageInListPath { get; set; }
        public string ImageInListTitle { get; set; }
        public string ImageInListAlt { get; set; }

    }
}