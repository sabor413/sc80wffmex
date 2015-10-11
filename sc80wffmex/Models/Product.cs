using System.Collections.Specialized;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Web;

namespace sc80wffmex.Models
{
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web.UI.WebControls;

    public class Product : RenderingModel
    {
        public HtmlString Title { get { return new HtmlString(FieldRenderer.Render(Item, "Title")); } }
        public HtmlString Description { get { return new HtmlString(FieldRenderer.Render(Item, "Description")); } }
        public HtmlString Price { get { return new HtmlString(FieldRenderer.Render(Item, "Price")); } }
        public NameValueCollection Parameters { get { return WebUtil.ParseUrlParameters(RenderingContext.Current.Rendering["Parameters"]); } }
        public Item CurrentItem { get { return PageItem; } }

        #region COMMENTED OUT PROPERTIES
        //public HtmlString MainImage { get { return new HtmlString(FieldRenderer.Render(Item, "SomeImageField")); } }
        //public HtmlString MainDate { get { return new HtmlString(FieldRenderer.Render(Item, "SomeDateField")); } }
        //public string ProductURL { get { return LinkManager.GetItemUrl(Item); } }
        //public string ProductId { get { return Item.ID.ToString(); } }
        //public Item productItem { get { return Item; } }
        #endregion
    }
}