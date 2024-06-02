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
    public partial class frmEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in BLL_Employee.GetEmployees().Rows) {
                TableRow tr = new TableRow();
                foreach (var item in row.ItemArray) { 
                    TableCell cell = new TableCell();
                    cell.Text=item.ToString();
                    tr.Cells.Add(cell);
                }
                TableEmployees.Rows.Add(tr);
            }
        }

        protected void ButtonRegisterEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRegister.aspx");
        }
    }
}