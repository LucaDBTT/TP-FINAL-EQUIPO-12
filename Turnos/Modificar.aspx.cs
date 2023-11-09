﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Turnos
{
    public partial class Modificar : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            if (!IsPostBack)
            {
                CargarSedes();
                CargarEspecialidades();
            }
        }

        private void CargarSedes()
        {
            SedeNegocio sedeNegocio = new SedeNegocio();
            ddlSedes.DataSource = sedeNegocio.ListarSedes();
            ddlSedes.DataTextField = "nombreSede";  // Nombre de la propiedad a mostrar en el DropDownList
            ddlSedes.DataValueField = "IdSede";      // Nombre de la propiedad para el valor de las opciones
            ddlSedes.DataBind();
        }

        private void CargarEspecialidades()
        {
            EspecialidadesNegocio especialidadNegocio = new EspecialidadesNegocio();
            ddlEspecialidades.DataSource = especialidadNegocio.ListarEspecialidades();
            ddlEspecialidades.DataTextField = "Nombre";  // Nombre de la propiedad a mostrar en el DropDownList
            ddlEspecialidades.DataValueField = "Id";      // Nombre de la propiedad para el valor de las opciones
            ddlEspecialidades.DataBind();
        }

        protected void BTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnElminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

     
    }
}