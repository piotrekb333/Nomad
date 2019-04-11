using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomad.Models.ArticleModels
{
    public class ArticleImportModel
    {
        public string title { get; set; }
        public string introtext { get; set; }
        public int catid { get; set; }
    }
}