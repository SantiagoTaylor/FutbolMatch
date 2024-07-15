using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmCreateEstablishment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    LoadDataEstablishment(Request.QueryString["id"].ToString());
                    ButtonRegister.Text = "Modificar";
                }
            }
        }
        private void LoadDataEstablishment(string id)
        {
            BE_Establishment est = BLL_Establishment.GetEstablishment(id);
            TextBoxName.Text = est.Name;
            TextBoxEmail.Text = est.Email;
            TextBoxPhone.Text = est.Phone;
            TextBoxAdress.Text = est.Adress;
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            BE_Establishment s = new BE_Establishment(TextBoxName.Text, TextBoxEmail.Text, TextBoxPhone.Text, TextBoxAdress.Text);
            if (ButtonRegister.Text == "Modificar")
            {
                s.Id = int.Parse(Request.QueryString["id"].ToString());
                if (BLL_Establishment.UpdateEstablishment(s)) Server.Transfer("frmEstablishments.aspx");
            }
            else
            {
                if (BLL_Establishment.RegisterEstablishment(s)) Server.Transfer("frmEstablishments.aspx");
            }
        }
    }
}