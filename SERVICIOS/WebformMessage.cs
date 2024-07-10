using System.Web.UI;

namespace SERVICES
{
    public static class WebformMessage
    {
        public static void ShowMessage(string message, Control control)
        {
            string script = $"alert('{message}');";
            ScriptManager.RegisterStartupScript(control, control.GetType(), "ShowMessageScript", script, true);
        }
    }
}
    