namespace CustomAction.SaveAction
{
    using Sitecore.Data;
    using Sitecore.Form.Submit;

    public class CustomAction : ISaveAction
    {
        public void Execute(Sitecore.Data.ID formid, Sitecore.Form.Core.Client.Data.Submit.AdaptedResultList fields, params object[] data)
        {
            //throw new NotImplementedException();

            var master = Sitecore.Configuration.Factory.GetDatabase("master");
            var producttwo = master.GetItem(new ID("{2D9304C0-9CA7-484A-BD45-4AB664AFAFE3}"));
            producttwo.Editing.BeginEdit();
            producttwo.Fields["Price"].Value = "20.00";
            producttwo.Editing.EndEdit();
        }
    }
}