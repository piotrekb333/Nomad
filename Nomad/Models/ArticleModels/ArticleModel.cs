using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

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

        public ArticleModel(IPublishedContent content)
        {
            int idbanner = 0;
            int idbanner2 = 0;

            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            string imageInListPath = "";
            string imageInListAlt = "";
            string imageInListTitle = "";

            var imageList = (IList<IPublishedContent>)content.GetProperty("articleIcon")?.Value;
            if (imageList != null && imageList.Count > 0)
            {
                imageInListPath = int.TryParse(imageList[0].GetProperty("customMediaImage")?.Value?.ToString(), out idbanner2) ? umbracoHelper.Media(idbanner2).Url : "";
                imageInListAlt = imageList[0].GetProperty("customAlt")?.Value?.ToString();
                imageInListTitle = imageList[0].GetProperty("customTitle")?.Value?.ToString();

            }

            this.Body = content.GetProperty("articleBody")?.Value?.ToString();
            this.Title = content.GetProperty("articleBody")?.Value?.ToString();
            this.ImagePath = int.TryParse(content.GetProperty("articleBanner")?.Value?.ToString(), out idbanner) ? umbracoHelper.Media(idbanner).Url : "";
            this.DatePublished = content.GetProperty("articlePublishedDate").HasValue ? DateTime.Parse(content.GetProperty("articlePublishedDate")?.Value?.ToString()) : new DateTime?();
            this.SiteUrl = content.GetProperty("articleBody")?.Value?.ToString();
            this.ImageInListPath = imageInListPath;
            this.ImageInListAlt = imageInListAlt;
            this.ImageInListTitle = imageInListTitle;

        }

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