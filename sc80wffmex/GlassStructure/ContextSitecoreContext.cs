namespace sc80wffmex.GlassStructure
{
    using System;
    using System.Collections.Specialized;

    using Glass.Mapper.Sc;

    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    public class ContextSitecoreContext : IControllerSitecoreContext
    {
        private readonly ISitecoreContext _sitecoreContext;

        public ContextSitecoreContext(ISitecoreContext sitecoreContext)
        {
            this._sitecoreContext = sitecoreContext;
        }

        public T GetDataSource<T>() where T : class
        {
            string dataSource = RenderingContext.CurrentOrNull.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                return this._sitecoreContext.GetCurrentItem<T>(); //default(T);
            }
            if (dataSource.StartsWith("query:"))
            {
                string query = dataSource.Remove(0, 6);
                var item = PageContext.Current.Item.Axes.SelectSingleItem(query);
                if (item != null)
                    return item.GlassCast<T>();
                else
                    return this._sitecoreContext.GetCurrentItem<T>();  //default(T);
            }
            else
            {
                Guid dataSourceId;
                return Guid.TryParse(dataSource, out dataSourceId)

                    ? this._sitecoreContext.GetItem<T>(dataSourceId)

                    : this._sitecoreContext.GetItem<T>(dataSource);
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