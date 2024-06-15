using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmDatabaseIntegrity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRestore_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonRecalculate_Click(object sender, EventArgs e)
        {
            DatabaseIntegrity.RecalculateDigits();
        }

        protected void ButtonVerify_Click(object sender, EventArgs e)
        {
            var prueba = DatabaseIntegrity.HorizontalIntegrity();
            foreach (var item in prueba)
            {
                if (item.Value == false)
                {
                    WebformMessage.ShowMessage($"Error en la tabla {item.Key.Item1}", this);
                    break;
                }
            }
        }
    }
}