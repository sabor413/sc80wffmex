namespace sc80wffmexviews
{
    using System.Web.Mvc;

    public class CustomRazorViewEngine : RazorViewEngine
    {
        public static void Initialize()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomRazorViewEngine());
        }

        public CustomRazorViewEngine()
        {
            var viewLocations = new[]
			{
				"~/Views/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
				"~/Views/Menu/{0}.cshtml",
				//"~/Views/Carlos/{1}/{0}.cshtml", 
				//"~/Views/Carlos/Shared/{0}.cshtml",
			};
            this.ViewLocationFormats = viewLocations;
            this.PartialViewLocationFormats = viewLocations;

            #region AREAs
            //var areaViewLocations = new[]
            //{
            //    "~/Views/Carlos/{1}/{0}.cshtml", 
            //    "~/Views/Carlos/Shared/{0}.cshtml",
            //    "~/Views/{2}/{1}/{0}.cshtml",	// Coping with Area's
            //    "~/Views/{2}/Shared/{0}.cshtml"
            //};

            //this.AreaPartialViewLocationFormats = areaViewLocations;
            //this.AreaViewLocationFormats = areaViewLocations;
            #endregion
        }

    }
}