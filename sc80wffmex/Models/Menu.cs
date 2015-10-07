namespace sc80wffmex.Models
{
    using System.Collections.Generic;
    using Sitecore.Data.Items;
    using Sitecore.Links;

    public class Menu
    {
        public List<MenuElement> All
        {
            get
            {
                var menuElements = new List<MenuElement>();

                menuElements.Add(new MenuElement {Title = HomeItem.DisplayName, Url= LinkManager.GetItemUrl(HomeItem)});

                foreach (Item element in HomeItem.GetChildren())
                {
                    var myElement = new MenuElement
                    {
                        Title = element["Title"],
                        Url = Sitecore.Links.LinkManager.GetItemUrl(
                              Sitecore.Context.Database.GetItem(element.ID.ToString()))
                    };
                    menuElements.Add(myElement);
                }
                return menuElements;
            }
        }

        public Item HomeItem
        {
            get
            {
                return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            }
        }


    }
}