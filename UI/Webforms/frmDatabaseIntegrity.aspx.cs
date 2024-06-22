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
            string errorMessage = "";
            foreach (var item in prueba)
            {
                if (item.Value == false)
                {
                    errorMessage += $"Error en la tabla {item.Key.Item1}\n";
                }
            }
            if (errorMessage == "")
            {
                errorMessage = "No hay errores en la base de datos.";
            }
            WebformMessage.ShowMessage(errorMessage, this);
        }
    }
}