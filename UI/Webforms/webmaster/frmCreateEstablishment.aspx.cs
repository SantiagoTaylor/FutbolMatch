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

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            BE_Establishment s = new BE_Establishment(TextBoxName.Text,TextBoxEmail.Text,TextBoxPhone.Text,TextBoxAdress.Text);
            BLL_Establishment.RegisterEstablishment(s);
        }
    }
}