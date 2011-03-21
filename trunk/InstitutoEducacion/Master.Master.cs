using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BussinesObjects.BussinesObjects;

namespace InstitutoEducacion
{
    public partial class Master : System.Web.UI.MasterPage
    {
        BussinesObjects.BussinesObjects.Persona _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (BussinesObjects.BussinesObjects.Persona)Session["usuario"];
            //LblUsuario.Text = user.Nombre;
            if (!IsPostBack)
            {
                generarMenu();
            }
        }

        private void generarMenu()
        {
            if (_user.Perfil.Numero == Convert.ToInt32(PerfilesEnum.Admin))
            {

                MenuItem itPersonas = new MenuItem("Personas");


                MenuItem itA = new MenuItem("Alumnos");
                itA.Value = "AlumnosVer";
                itA.NavigateUrl = "Alumnos.aspx";
                itPersonas.ChildItems.Add(itA);


                MenuItem itP = new MenuItem("Profesores");
                itP.Value = "ProfesoresVer";
                itP.NavigateUrl = "Profesores.aspx";
                itPersonas.ChildItems.Add(itP);

                Menu1.Items.Add(itPersonas);

            }





            MenuItem itMaterias = new MenuItem("Materias");

            if (_user.Perfil.Numero == Convert.ToInt32(PerfilesEnum.Admin))
            {

                MenuItem itM = new MenuItem("Ver Materias");
                itM.Value = "MateriasVer";
                itM.NavigateUrl = "Materias.aspx";
                itMaterias.ChildItems.Add(itM);

                MenuItem itMA = new MenuItem("Asignar Profesor a Materia");
                itMA.Value = "Asignacion";
                itMA.NavigateUrl = "AsignacionMateria.aspx";
                itMaterias.ChildItems.Add(itMA);
                Menu1.Items.Add(itMaterias);
            }

            if (_user.Perfil.Numero == Convert.ToInt32(PerfilesEnum.Alumno))
            {
                MenuItem itMI = new MenuItem("Inscripciones");
                itMI.Value = "Inscripciones";
                itMI.NavigateUrl = "Inscripcion.aspx";
                itMaterias.ChildItems.Add(itMI);
                Menu1.Items.Add(itMaterias);
            }



            MenuItem itExamenes = new MenuItem("Examenes");

            if (_user.Perfil.Numero == Convert.ToInt32(PerfilesEnum.Alumno))
            {
                MenuItem itEv = new MenuItem("Ver Examenes");
                itEv.Value = "ExamenesVer";
                itEv.NavigateUrl = "VerExamenes.aspx";
                itExamenes.ChildItems.Add(itEv);
                Menu1.Items.Add(itExamenes);

            }
            if (_user.Perfil.Numero == Convert.ToInt32(PerfilesEnum.Profesor))
            {
                MenuItem itEc = new MenuItem("Cargar Examenes");
                itEc.Value = "ExamenEdit";
                itEc.NavigateUrl = "ExamenEdit.aspx";
                itExamenes.ChildItems.Add(itEc);

                Menu1.Items.Add(itExamenes);
            }

            MenuItem itDatos = new MenuItem("Mis Datos");
            MenuItem itMD = new MenuItem("Editar");
            itMD.Value = "Editar";
            itMD.NavigateUrl = "EditarMisDatos.aspx";
            itDatos.ChildItems.Add(itMD);


            Menu1.Items.Add(itDatos);



            MenuItem itCerrar = new MenuItem("Cerrar Sessión");
            itCerrar.Value = "Cerrar Sessión";
            itCerrar.NavigateUrl = "CerrarSesion.aspx";
            Menu1.Items.Add(itCerrar);


            MenuItem itInfo = new MenuItem(_user.Nombre+" "+_user.Apellido+" ("+_user.Perfil.Nombre+")");
            itInfo.Value = "";
            itInfo.NavigateUrl = "";
            itInfo.Selectable = false;
            Menu1.Items.Add(itInfo);

        }
    }
}
