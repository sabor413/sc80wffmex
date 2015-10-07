namespace sc80wffmexviews.Helpers
{
    using System;
    using System.IO;
    using System.Web.UI;
    using Sitecore.Web.UI.WebControls;

    public class EditFrameRendering : IDisposable
    {
        private readonly EditFrame _editFrame;
        private readonly HtmlTextWriter _htmlWriter;

        public EditFrameRendering(TextWriter writer, string dataSource, string buttons)
        {
            this._htmlWriter = new HtmlTextWriter(writer);
            this._editFrame = new EditFrame { DataSource = dataSource, Buttons = buttons };
            this._editFrame.RenderFirstPart(this._htmlWriter);
        }


        public void Dispose()
        {
            this._editFrame.RenderLastPart(this._htmlWriter);
            this._htmlWriter.Dispose();
        }
    }
}