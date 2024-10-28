using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmTranslations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LanguageLoad();
            }
        }

        private DataTable languages = BLL_Language.GetLanguages();
        private void LanguageLoad()
        {
            DropDownListFromLanguage.DataTextField = "languageDisplay";
            DropDownListFromLanguage.DataValueField = "idLanguage";
            DropDownListFromLanguage.DataSource = languages;
            DropDownListFromLanguage.DataBind();
            //las 2 ddl
            DropDownListToLanguage.DataTextField = "languageDisplay";  
            DropDownListToLanguage.DataValueField = "idLanguage";
            DropDownListToLanguage.DataSource = languages;
            DropDownListToLanguage.DataBind();
            DropDownListFromLanguage.SelectedIndex = -1;
        }

        protected void DropDownListFromLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageLoad();
            DropDownListToLanguage.Items.Remove(DropDownListFromLanguage.SelectedItem.Text);
        }

        protected void DropDownListToLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvLanguage.DataSource = SERVICES.Languages.Translation.GetTranslationTable();//metodo para traer los 2 idiomas, todo en la misma tabla
            //a lo sumo si ADO desc no lo permite, traigo todo y lo oculto desde el dv; más pesado al pedo
            gvLanguage.DataBind();
        }

        protected void gvLanguage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLanguage.EditIndex = e.NewEditIndex;
        }

        protected void gvLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLanguage.EditIndex = -1;
        }

        protected void gvLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener las claves primarias de la fila que se está actualizando
            int clave1 = Convert.ToInt32(gvLanguage.DataKeys[e.RowIndex].Values["controlName"]);
            int clave2 = Convert.ToInt32(gvLanguage.DataKeys[e.RowIndex].Values["webformName"]);

            // Obtener los nuevos valores de los campos editables
            GridViewRow row = gvLanguage.Rows[e.RowIndex];
            string nuevoNombre = ((TextBox)row.Cells[2].Controls[0]).Text;
            string nuevaDescripcion = ((TextBox)row.Cells[3].Controls[0]).Text;

            DataTable table = (DataTable)gvLanguage.DataSource;
            
            DataRow[] filas = table.Select("columnaClave1 = " + clave1 + " AND columnaClave2 = " + clave2);
            if (filas.Length > 0)
            {
                filas[0]["Nombre"] = nuevoNombre;//cambiar
                filas[0]["Descripcion"] = nuevaDescripcion;
            }
            //llamar al metodo y pasar la table
            
            gvLanguage.EditIndex = -1;
        }
    }
}