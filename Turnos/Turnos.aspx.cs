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
    public partial class Turnos : System.Web.UI.Page
    {
       public List<Especialidad> listaEspecialidades { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] is Dominio.usuarios usuario && usuario.TipoUsuario == Dominio.TipoUsuarios.paciente))
            {
                Session.Add("Error", "No eres un paciente");
                Response.Redirect("Login.aspx", false);
            }


            if (!IsPostBack)
            {
                EspecialidadesNegocio negocio = new EspecialidadesNegocio();
                listaEspecialidades = negocio.ListarEspecialidades();
                repRepeater.DataSource = listaEspecialidades;
                repRepeater.DataBind();
            }

            if (Request.QueryString["idEspecialidad"] != null && listaEspecialidades.Count > 0)
            {
                string idEspecialidades = Request.QueryString["idEspecialidad"];
            }
        }

    }
}