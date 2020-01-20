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
                IEnumerable<ArticleModel> newsList = new List<ArticleModel>();
                newsList = CurrentPage?.Children.Where(m => !m.IsDraft).Select(z => new ArticleModel(z)).ToList();
                return PartialView("Articles/_Articles",newsList);
            }
            catch(Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Article error", ex);
            }
            return Content("");
        }
    }
}