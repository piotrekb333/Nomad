using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Services;
using Nomad.Models.ArticleModels;
using Newtonsoft.Json;

namespace Nomad.Controllers
{
    public class ImportController : SurfaceController
    {
        [HttpGet]
        public ActionResult ImportArticle(string parentId, int userId,int catid)
        {
            try
            {
                

                var path = Server.MapPath("/articles.json");
                List<ArticleImportModel> articles = JsonConvert.DeserializeObject<List<ArticleImportModel>>(System.IO.File.ReadAllText(path));
                //var listOfObjects = System.IO.File.ReadLines(path).Select(line => new ArticleModel(line)).ToList();
                foreach (var item in articles)
                {
                    if (item.catid != catid)
                        continue;
                    IContentService cs = ApplicationContext.Services.ContentService;
                    Guid parent = Guid.Parse(parentId);
                    var content = cs.CreateContent(item.title, parent, "article", userId);
                    content.SetValue("articleTitle", item.title);
                    content.SetValue("articleBody", item.introtext);
                    content.SetValue("articlePublishedDate", DateTime.UtcNow);
                    cs.SaveAndPublishWithStatus(content);
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