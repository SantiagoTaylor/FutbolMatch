using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SERVICES.Languages
{
    public static class Translation
    {
        public static Dictionary<string, string> GetTranslation(int language)
        {
            //pasar de table a diccionario
            //CLAVE: webform_id
            //VALOR: la traduccion en ese idioma especifico
            DataTable table = DAL.DAL_Language.GetTranslation(language);
            Dictionary<string, string> translations = new Dictionary<string, string>();

            foreach (DataRow row in table.Rows)
            {
                string key = $"{row["webformName"].ToString()}_{row["controlName"].ToString()}";
                string value = row[table.Columns.Count - 1].ToString();
                translations[key] = value;
            }

            return translations;
        }

        public static DataTable GetTranslationTable()
        {
            return DAL.DAL_Language.GetTranslationTable();
        }

        public static void SaveTranslation(DataTable table)
        {
            DAL.DAL_Language.SaveTranslations(table);
        }

        public static List<Control> GetAllWebControls(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control control in parent.Controls)
            {
                if (control is WebControl)
                {
                    WebControl webControl = (WebControl)control;
                    controls.Add(webControl);
                }
                if (control.HasControls())
                {
                    controls.AddRange(GetAllWebControls(control));
                }
            }
            return controls;
        }
    }
}
