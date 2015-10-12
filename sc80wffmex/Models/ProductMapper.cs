using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace sc80wffmex.Models
{
    [SitecoreType(TemplateId = "{D1019B40-C5DE-4607-BB0C-34D27C9A6E30}", AutoMap = true)]
    public class ProductMapper
    {
        [SitecoreId]
        public virtual Guid Id { get; set; }

        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Price { get; set; }
        public virtual string CanUSeeMe { get; set; }
    }
}