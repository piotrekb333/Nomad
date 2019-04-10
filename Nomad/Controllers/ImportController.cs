using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Services;
using Nomad.Models.ArticleModels;

namespace Nomad.Controllers
{
    public class ImportController : SurfaceController
    {
        [HttpGet]
        public ActionResult ImportArticle(string parentId, int userId)
        {
            try
            {                
                var path = Server.MapPath("/articles.csv");
                var listOfObjects = System.IO.File.ReadLines(path).Select(line => new ArticleModel(line)).ToList();

                foreach (var item in listOfObjects)
                {
                    IContentService cs = ApplicationContext.Services.ContentService;
                    Guid parent = Guid.Parse(parentId);
                    var content = cs.CreateContent(item.Title, parent, "article", userId);
                    content.SetValue("articleTitle", item.Title);
                    content.SetValue("articleBody", item.Body);
                    content.SetValue("articlePublishedDate", item.DatePublished);
                    //cs.SaveAndPublishWithStatus(content);
                }
            }
            catch (Exception ex)
            {
                return Content(ex?.Message ?? " inner :" + ex?.InnerException?.Message ?? "");
            }

            return Content("OK");
        }
    }
}