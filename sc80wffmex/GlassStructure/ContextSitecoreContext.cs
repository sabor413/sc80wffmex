using System;
using System.Collections.Specialized;
using Glass.Mapper.Sc;
using Sitecore.Mvc.Presentation;
using Sitecore.Web;

namespace sc80wffmex.GlassStructure
{
    public class ContextSitecoreContext : SitecoreContext, IControllerSitecoreContext
    {
        //private readonly IGlassHtml _glassHtml;
 
        //public ContextSitecoreContext(IGlassHtml glassHtml)
        //{
        //    this._glassHtml = glassHtml;
        //}

        public T GetDataSource<T>() where T : class
        {
            string dataSource = RenderingContext.CurrentOrNull.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                return default(T);
            }
            if (dataSource.StartsWith("query:"))
            {
                string query = dataSource.Remove(0, 6);
                var item = PageContext.Current.Item.Axes.SelectSingleItem(query);
                if (item != null)
                    return item.GlassCast<T>();
                else
                    return default(T);
            }
            else
            {
                Guid dataSourceId;
                return Guid.TryParse(dataSource, out dataSourceId)

                    ? GetItem<T>(dataSourceId)

                    : GetItem<T>(dataSource);
            }
        }

        public NameValueCollection GetRenderingParameters()
        {
            NameValueCollection parameters = WebUtil.ParseUrlParameters(RenderingContext.CurrentOrNull.Rendering["Parameters"]);
            if (parameters == null)
            {
                return null;
            }

            return parameters;
        }
    }
}