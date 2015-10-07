namespace sc80wffmexviews.Helpers
{
    using System.Web.Mvc;

    public static class HtmlExtensions
    {
        /// <summary>
        /// Method for edit frame
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="dataSource"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static EditFrameRendering BeginEditFrame<T>(this HtmlHelper<T> helper, string dataSource, string buttons)
        {
            var frame = new EditFrameRendering(helper.ViewContext.Writer, dataSource, buttons);
            return frame;
        }
    }
}