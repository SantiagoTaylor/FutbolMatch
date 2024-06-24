using BE;
using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmReservas : System.Web.UI.Page
    {
        private BLL_Cancha canchaBLL = new BLL_Cancha();
        private BLL_Horario horarioBLL = new BLL_Horario();
        private BLL_Reserva reservaBLL = new BLL_Reserva();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCanchas();
                CargarHorarios(); // Cargar horarios para la primera cancha por defecto
            }
        }

        protected void ddlCanchas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int canchaID = int.Parse(ddlCanchas.SelectedValue);
            CargarHorarios(canchaID);
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            string fechaTexto = txtFecha.Text;
            DateTime fecha;

            // Verificar el valor de la fecha ingresada
            System.Diagnostics.Debug.WriteLine("Fecha ingresada: " + fechaTexto);

            bool isValidDate = DateTime.TryParseExact(fechaTexto, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);

            // Mostrar el resultado de la verificación
            System.Diagnostics.Debug.WriteLine("isValidDate: " + isValidDate);

            if (isValidDate)
            {
                BE_Reserva reserva = new BE_Reserva
                {
                    CanchaID = int.Parse(ddlCanchas.SelectedValue),
                    UsuarioID = SessionManager.GetInstance.User.Username, // Aquí debes obtener el ID del usuario actual
                    HorarioID = int.Parse(ddlHorarios.SelectedValue),
                    Fecha = fecha
                };

                reservaBLL.CrearReserva(reserva);
            }
            else
            {
                // Manejar el error de formato de fecha
                // Por ejemplo, mostrar un mensaje de error en la página
                // lblError.Text = "Formato de fecha incorrecto. Por favor, use el formato YYYY-MM-DD.";
            }
        }

        private void CargarCanchas()
        {
            List<BE_Cancha> canchas = canchaBLL.ObtenerCanchas();
            ddlCanchas.DataSource = canchas;
            ddlCanchas.DataTextField = "Nombre";
            ddlCanchas.DataValueField = "CanchaID";
            ddlCanchas.DataBind();

            // Cargar horarios para la primera cancha por defecto
            if (canchas.Count > 0)
            {
                int primeraCanchaID = canchas[0].CanchaID;
                CargarHorarios(primeraCanchaID);
            }
        }

        private void CargarHorarios(int canchaID = 0)
        {
            if (canchaID == 0 && ddlCanchas.Items.Count > 0)
            {
                canchaID = int.Parse(ddlCanchas.SelectedValue);
            }

            ddlHorarios.DataSource = horarioBLL.ObtenerHorarios(canchaID);
            ddlHorarios.DataTextField = "HoraInicio"; // Muestra la hora de inicio en el DropDownList
            ddlHorarios.DataValueField = "HorarioID";
            ddlHorarios.DataBind();
        }
    }
}