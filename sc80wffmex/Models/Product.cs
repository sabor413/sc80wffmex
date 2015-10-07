using System.Web;

namespace sc80wffmex.Models
{
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web.UI.WebControls;

    public class Product : RenderingModel
    {
        public HtmlString Title { get { return new HtmlString(FieldRenderer.Render(Item, "Title")); } }
        public HtmlString Description { get { return new HtmlString(FieldRenderer.Render(Item, "Description")); } }
        public HtmlString Price { get { return new HtmlString(FieldRenderer.Render(Item, "Price")); } }

        //public HtmlString MainImage { get { return new HtmlString(FieldRenderer.Render(Item, "SomeImageField")); } }
        //public HtmlString MainDate { get { return new HtmlString(FieldRenderer.Render(Item, "SomeDateField")); } }
        //public string ProductURL { get { return LinkManager.GetItemUrl(Item); } }
        //public string ProductId { get { return Item.ID.ToString(); } }
        //public Item productItem { get { return Item; } }
    }
}