using System.Web.UI;

namespace SERVICES
{
    public static class WebformMessage
    {
        public static void ShowMessage(string message, Control control, string jsonOk = null)
        {
            string script = $"alert('{message}');";
            if (!string.IsNullOrEmpty(jsonOk))
            {
                script += $" {jsonOk}";
            }
            ScriptManager.RegisterStartupScript(control, control.GetType(), "ShowMessageScript", script, true);
        }
    }
}
