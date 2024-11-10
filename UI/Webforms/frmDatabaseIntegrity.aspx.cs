using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace UI.Webforms
{
    public partial class frmDatabaseIntegrity : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ObservableLanguage.Attach(this);
            }
        }

        protected void ButtonRestore_Click(object sender, EventArgs e)
        {
            if (FileUploadRestore.HasFile)
            {
                try
                {
                    // Guardar el archivo subido en el servidor
                    string fileName = Path.GetFileName(FileUploadRestore.PostedFile.FileName);
                    string savePath = Server.MapPath("~/Backups/") + fileName;
                    Directory.CreateDirectory(Server.MapPath("~/Backups/")); 
                    FileUploadRestore.SaveAs(savePath);

                    // Restaurar la base de datos usando el archivo de respaldo
                    DatabaseBackup.Restore(savePath);
                    TextBoxMessage.Text = "Restore successful.";
                }
                catch (Exception ex)
                {
                    TextBoxMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                TextBoxMessage.Text = "Please select a backup file to restore.";
            }
        }

        protected void ButtonRecalculate_Click(object sender, EventArgs e)
        {
            DatabaseIntegrity.RecalculateTables();
            WebformMessage.ShowMessage("Se recalcularon todas las tablas", this);
            TextBoxMessage.Text = "";
        }

        protected void ButtonVerify_Click(object sender, EventArgs e)
        {
            VerifyIntegrity();
        }

        private void VerifyIntegrity()
        {
            var tablesAndErrors = DatabaseIntegrity.HorizontalIntegrity();
            string errorMessage = "";
            foreach (var item in tablesAndErrors)
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
            TextBoxMessage.Text = errorMessage;
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

        protected void ButtonBackup_Click(object sender, EventArgs e)
        {
            string folderPath = TextBoxBackup.Text.Trim();
            if (Directory.Exists(folderPath))
            {
                try
                {
                    string fileName = "Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";
                    string backupFilePath = Path.Combine(folderPath, fileName);

                    DatabaseBackup.Backup(backupFilePath);
                    TextBoxMessage.Text = "Backup successful. File saved to: " + backupFilePath;
                }
                catch (Exception ex)
                {
                    TextBoxMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                TextBoxMessage.Text = "Please select a folder to save the backup.";
            }
        }
        
        public void Translate()
        {
            List<Control> controlList = Translation.GetAllWebControls(this);

            string webform = System.IO.Path.GetFileNameWithoutExtension(Server.MapPath(Page.AppRelativeVirtualPath));
            Dictionary<string, string> translations = Translation.GetTranslation(SessionManager.GetInstance.User.Language);

            foreach (Control control in controlList)
            {
                string key = $"{webform}_{control.ID}";
                if (translations.ContainsKey(key))
                {
                    if (control is Button)
                    {
                        ((Button)control).Text = translations[key];
                    }
                    else if (control is Label)
                    {
                        ((Label)control).Text = translations[key];
                    }
                    else if (control is Literal)
                    {
                        ((Literal)control).Text = translations[key];
                    }
                }
            }
        }
    }
}