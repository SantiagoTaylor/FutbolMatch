using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmEstablishments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEstablishments();
        }

        private void LoadEstablishments()
        {
            foreach (DataRow r in BLL_Establishment.GetEstablishments().Rows)
            {
                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell { Text = r["idEstablishment"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["establishmentName"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["direction"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["phone"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["email"].ToString() });
                TableCell actionCell = new TableCell();
                LinkButton editButton = new LinkButton { Text = "<i class='bi bi-pencil-square'></i>"};
                LinkButton deleteButton = new LinkButton { Text = "<i class='bi bi-trash3-fill'></i>" };
                actionCell.Controls.Add(editButton);
                actionCell.Controls.Add(deleteButton);
                tr.Cells.Add(actionCell);
                TableEstablishments.Rows.Add(tr);
            }
        }

        protected void ButtonRegisterEstablishment_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateEstablishment.aspx");
        }
    }
}