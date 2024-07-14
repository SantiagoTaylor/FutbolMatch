using BLL;
using SERVICES;
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
                tr.CssClass = "tablerow";
                tr.Cells.Add(new TableCell { Text = r["idEstablishment"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["establishmentName"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["direction"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["phone"].ToString() });
                tr.Cells.Add(new TableCell { Text = r["email"].ToString() });

                TableCell actionCell = new TableCell();
                LinkButton editButton = new LinkButton
                {
                    Text = "<i class='bi bi-pencil-square'></i>",
                    CommandArgument = r["idEstablishment"].ToString()
                };
                editButton.Command += EditButton_Command;
                editButton.CommandName = "Edit";
                LinkButton deleteButton = new LinkButton
                {
                    Text = "<i class='bi bi-trash3-fill'></i>",
                    CommandArgument = r["idEstablishment"].ToString(),
                    OnClientClick = $"return confirmAction('delete', '{r["establishmentName"]}');"
                };
                deleteButton.Command += DeleteButton_Command;
                editButton.CommandName = "Delete";

                actionCell.Controls.Add(editButton);
                actionCell.Controls.Add(deleteButton);
                tr.Cells.Add(actionCell);
                TableEstablishments.Rows.Add(tr);
            }
        }

        private void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            BLL_Establishment.DeleteEstablishment(e.CommandArgument.ToString());
            Response.Redirect(Request.RawUrl);
        }

        private void EditButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"frmCreateEstablishment.aspx?id={e.CommandArgument.ToString()}");
        }

        protected void ButtonRegisterEstablishment_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateEstablishment.aspx");
        }
    }
}