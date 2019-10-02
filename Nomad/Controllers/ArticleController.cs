using Nomad.Models.ArticleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace Nomad.Controllers
{
    public class ArticleController : SurfaceController
    {
        public ActionResult RenderArticles()
        {
            try
            {
                List<ArticleModel> newsList = new List<ArticleModel>();
                var list=CurrentPage?.Children.Where(m=>!m.IsDraft).ToList();
                if (list != null)
                {
                    list.ForEach(m =>
                    {
                        int idbanner2 = 0;

                        string imageInListPath ="";
                        string imageInListAlt = "";
                        string imageInListTitle = "";

                        var imageList = (IList<IPublishedContent>)m.GetProperty("articleIcon")?.Value;
                        if(imageList!=null && imageList.Count > 0)
                        {
                            imageInListPath = int.TryParse(imageList[0].GetProperty("customMediaImage")?.Value?.ToString(), out idbanner2) ? Umbraco.TypedMedia(idbanner2).Url : "";
                            imageInListAlt = imageList[0].GetProperty("customAlt")?.Value?.ToString();
                            imageInListTitle = imageList[0].GetProperty("customTitle")?.Value?.ToString();

                        }
                        int idbanner = 0;

                        newsList.Add(new ArticleModel {
                            Body = m.GetProperty("articleBody")?.Value?.ToString(),
                            Title = m.GetProperty("articleTitle")?.Value?.ToString(),
                            ImagePath = int.TryParse(m.GetProperty("articleBanner")?.Value?.ToString(), out idbanner) ? Umbraco.TypedMedia(idbanner).Url : "",
                            DatePublished = m.GetProperty("articlePublishedDate").HasValue ? DateTime.Parse(m.GetProperty("articlePublishedDate")?.Value?.ToString()) : new DateTime?(),
                            SiteUrl = m?.Url,
                            ImageInListPath = imageInListPath,
                            ImageInListAlt = imageInListAlt,
                            ImageInListTitle = imageInListTitle
                        });
                    });
                    //newsList = newsList.OrderByDescending(m => m.DatePublished).ToList();
                }
                return PartialView("Articles/_Articles",newsList);
            }
            catch(Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "News error", ex);
            }
            return Content("");
        }
    }
}