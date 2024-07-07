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
            WebformMessage.ShowMessage("Se recalcularon todas las tablas", this);
            LabelMessage.Text = "";
        }

        protected void ButtonVerify_Click(object sender, EventArgs e)
        {
            var prueba = DatabaseIntegrity.HorizontalIntegrity();
            string errorMessage = "";
            foreach (var item in prueba)
            {
                if (item.Value.Count != 0)
                {
                    errorMessage += $"{RowsErrorMessage(item)}\n";
                }
            }
            if (errorMessage == "")
            {
                errorMessage = "No hay errores en la base de datos.";
            }
            LabelMessage.Text = errorMessage;
            WebformMessage.ShowMessage(errorMessage, this);
        }

        private string RowsErrorMessage(KeyValuePair<(string, string), List<string>> errorList)
        {
            string errorMessage = "";
            foreach (var error in errorList.Value)
            {
                errorMessage += $"ERROR: TABLA {errorList.Key.Item1} - FILA: {error}\n";
            }
            return errorMessage;
        }
    }
}