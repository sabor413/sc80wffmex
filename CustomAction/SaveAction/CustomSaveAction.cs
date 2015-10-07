namespace CustomAction.SaveAction
{
    using Sitecore.Globalization;
    using Sitecore.Publishing;
    using Sitecore.SecurityModel;
    using Sitecore.Data;
    using Sitecore.Form.Submit;

    /// <summary>
    /// This class is meant to demonstrate how to create a custom action attached to the Save Action set of a WFFM form
    /// </summary>
    public class CustomAction : ISaveAction
    {
        /// <summary>
        /// Executes the specified formid.
        /// </summary>
        /// <param name="formid">The formid.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="data">The data.</param>
        public void Execute(Sitecore.Data.ID formid, Sitecore.Form.Core.Client.Data.Submit.AdaptedResultList fields,
            params object[] data)
        {
            var master = Sitecore.Configuration.Factory.GetDatabase("master");

            var producttwo = master.GetItem(new ID("{2D9304C0-9CA7-484A-BD45-4AB664AFAFE3}"));
            using (new SecurityDisabler())
            {
                producttwo.Editing.BeginEdit();
                producttwo.Fields["Price"].Value = "$20.00";
                producttwo.Editing.EndEdit();
            }

            var web = new[] {Sitecore.Configuration.Factory.GetDatabase("web")};
            var english = new[] {Language.Current};
            PublishManager.PublishItem(producttwo, web, english, false, false);
        }
    }
}