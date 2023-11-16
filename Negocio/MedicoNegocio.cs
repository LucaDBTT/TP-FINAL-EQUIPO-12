﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Dominio;

namespace Negocio
{
    public class MedicoNegocio
    {
        public List<Medico> ListarMedicos(string legajo = "")
        {
            List<Medico> Lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearQuery("select p.legajo, p.apellido, p.nombre, e.idEspecialidad, e.nombreEspecialidad, s.idSede, s.nombreSede, H.idHorario ,H.diaSemana, H.horaInicio, H.horaFin, p.Contraseña, p.estado \r\nfrom Profesionales p  \r\ninner join Especialidades e on e.idEspecialidad = p.idEspecialidad \r\ninner join Sede s on s.idSede = p.idSede \r\ninner join HorarioLaboral H on p.idHorario = H.idHorario\r\nwhere p.estado=1 ");
                if (legajo != "")
                    datos.Comando.CommandText += "and p.legajo=" + legajo;
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    Medico aux = new Medico();

                    aux.Legajo = (long)datos.lector["legajo"];
                    aux.Nombre = (string)datos.lector["nombre"];
                    aux.Apellido = (string)datos.lector["apellido"];
                  
                    aux.Estado = (bool)datos.lector["estado"];
                    aux.Contraseña = (string)datos.lector["Contraseña"];

                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<MedicoPorEspecialidad> ListarMedicosPorEspecialidad(string legajo = "")
        {
            List<MedicoPorEspecialidad> Lista = new List<MedicoPorEspecialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearQuery("select M.legajo, p.apellido, p.nombre, p.Contraseña, M.idEspecialidad, E.nombreEspecialidad, M.idSede, S.nombreSede, M.idHorario, H.diaSemana, H.horaInicio, H.horaFin, P.estado\r\nfrom MedicoPorEspecialidad AS M inner join Profesionales AS P ON M.legajo = P.legajo inner join Especialidades as E ON M.idEspecialidad = E.idEspecialidad inner join Sede as S ON S.idSede = M.idSede inner join HorarioLaboral as H ON M.idHorario = H.idHorario WHERE P.estado = 1");
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    MedicoPorEspecialidad aux = new MedicoPorEspecialidad();
                    aux.medico = new Medico();
                    aux.medico.Legajo = (long)datos.lector["legajo"];
                    aux.medico.Apellido = (string)datos.lector["apellido"];
                    aux.medico.Contraseña = (string)datos.lector["Contraseña"];
                    aux.medico.Estado = (bool)datos.lector["estado"];

                    // Crear la instancia de Especialidad y asignar valores
                    aux.Especialidades = new Especialidad
                    {
                        id = (long)datos.lector["idEspecialidad"],
                        Nombre = (string)datos.lector["nombreEspecialidad"]
                    };

                    // Crear la instancia de Sede y asignar valores
                    aux.Sede = new Sede
                    {
                        IdSede = (long)datos.lector["idSede"],
                        NombreSede = (string)datos.lector["nombreSede"]
                    };

                    // Crear la instancia de HorarioLaboral y asignar valores
                    aux.HorariosLaborales = new HorarioLaboral
                    {
                        IdHorario = (long)datos.lector["idHorario"],
                        DiaSemana = (string)datos.lector["diaSemana"],
                        HoraInicio = (TimeSpan)datos.lector["horaInicio"],
                        HoraFin = (TimeSpan)datos.lector["horaFin"]
                    };

                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarMedico(Medico nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {

                    Datos.SetearQuery("INSERT INTO Profesionales ( nombre, apellido, idEspecialidad, idSede, contraseña, estado) VALUES ( @Nombre, @Apellido, @IdEspecialidad, @IdSede, @Contraseña, @Estado)");


                    Datos.setearParametros("@Nombre", nuevo.Nombre);
                    Datos.setearParametros("@Apellido", nuevo.Apellido);
                    //Datos.setearParametros("@IdEspecialidad", nuevo.Especialidades.id);
                    //Datos.setearParametros("@IdSede", nuevo.Sede.IdSede);
                    Datos.setearParametros("@Contraseña", nuevo.Contraseña);
                    Datos.setearParametros("@Estado", nuevo.Estado);

                    Datos.ejecutarAccion();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Modificar(Medico nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearQuery("UPDATE PROFESIONALES SET nombre = @nombre, apellido = @apellido, idEspecialidad = @idEspecialidad,idSede = @idSede,contraseña = @contraseña, estado = @estado WHERE legajo = @legajo");

                Datos.setearParametros("@nombre", nuevo.Nombre);
                Datos.setearParametros("@apellido", nuevo.Apellido);
                //Datos.setearParametros("@idEspecialidad", nuevo.Especialidades.id);
                //Datos.setearParametros("@idSede", nuevo.Sede.IdSede);
                Datos.setearParametros("@contraseña", nuevo.Contraseña);
                Datos.setearParametros("@legajo", nuevo.Legajo);
                Datos.setearParametros("estado", nuevo.Estado);
                Datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void bajaFisica(int legajo)
        {
            AccesoDatos datos = new AccesoDatos();
            // DialogResult dialogo = MessageBox.Show("Esta seguro que desea eliminar el articulo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                //if (dialogo == DialogResult.Yes)

                datos.SetearQuery("delete from Profesionales where legajo = @legajo");
                datos.setearParametros("@legajo", legajo);
                datos.ejecutarAccion();
                // MessageBox.Show("Articulo eliminado con exito");


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }




        public void bajaLogica(int legajo)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {


                datos.SetearQuery("update Profesionales set estado=0 where legajo =@legajo");
                datos.setearParametros("@legajo", legajo);
                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Medico> filtrar(string campo, string criterio, string filtroAvanzado, string estado)
        {
            List<Medico> Medicos = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT p.legajo, p.apellido, p.nombre, e.idEspecialidad, e.nombreEspecialidad, s.idSede, s.nombreSede, p.Contraseña, p.estado FROM Profesionales p INNER JOIN Especialidades e ON e.idEspecialidad = p.idEspecialidad INNER JOIN Sede s ON s.idSede = p.idSede ";

                if (campo == "Especialidad")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "WHERE e.nombreEspecialidad LIKE '" + filtroAvanzado + "%'";
                            break;

                        case "Termina con":
                            consulta += "WHERE e.nombreEspecialidad LIKE '%" + filtroAvanzado + "'";
                            break;

                        case "Contiene":
                            consulta += "WHERE e.nombreEspecialidad LIKE '%" + filtroAvanzado + "%'";
                            break;
                    }
                }
                else if (campo == "Sede")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "WHERE s.nombreSede LIKE '" + filtroAvanzado + "%'";
                            break;

                        case "Termina con":
                            consulta += "WHERE s.nombreSede LIKE '%" + filtroAvanzado + "'";
                            break;

                        case "Contiene":
                            consulta += "WHERE s.nombreSede LIKE '%" + filtroAvanzado + "%'";
                            break;
                    }
                }

                if (estado == "Activo")
                    consulta += " AND p.estado = 1";
                else if (estado == "Inactivo")
                    consulta += " AND p.estado = 0";

                datos.SetearQuery(consulta);
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Medico aux = new Medico();

                    aux.Nombre = (string)datos.lector["nombre"];
                    aux.Apellido = (string)datos.lector["apellido"];
                    //aux.Sede = new Sede();
                    //aux.Sede.NombreSede = (string)datos.lector["nombreSede"];
                    //aux.Especialidades= new Especialidad();
                    //aux.Especialidades.Nombre = (string)datos.lector["nombreEspecialidad"];

                    Medicos.Add(aux); // Agregar el medico a la lista
                }
                return Medicos; // Devolver la lista fuera del bucle
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

    }
}


