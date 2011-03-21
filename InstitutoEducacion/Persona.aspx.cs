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
using DataAccessObjects.DAO;
using System.Collections.Generic;

namespace InstitutoEducacion
{
    public partial class Persona : System.Web.UI.Page
    {

        public BussinesObjects.BussinesObjects.Persona _persona = null;
        ModosEdicionEnum _modoApertura = new ModosEdicionEnum();
        Dictionary<long, Perfil> _listaPerfiles = new Dictionary<long, Perfil>();

        protected void Page_Load(object sender, EventArgs e)
        {
            _persona = (BussinesObjects.BussinesObjects.Persona)Session["persona"];
            LblMensaje.Text = "";

           

            if (_persona != null)
            {
                _modoApertura = ModosEdicionEnum.Modificar;

                if (_persona.Perfil.Numero != Convert.ToInt32(PerfilesEnum.Admin))
                {
                    CmbPerfil.Enabled = false;
                    _listaPerfiles = PerfilDAO.Instancia.obtenerPerfiles();
                }
                else
                {
                    _listaPerfiles = PerfilDAO.Instancia.obtenerTodos();
                }
            }
            else
            {
                _listaPerfiles = PerfilDAO.Instancia.obtenerTodos();
                _modoApertura = ModosEdicionEnum.Nuevo;
            }


            if (!IsPostBack)
            {
                cargarCombos();
                cargarPersona();
            }
        }

        private void cargarCombos()
        {
            CmbPerfil.DataSource = _listaPerfiles.Values.ToList();
            CmbPerfil.DataBind();

        }

        private void cargarPersona()
        {
            if (_persona != null)
            {
                TxtNombre.Text = _persona.Nombre;
                TxtApellido.Text = _persona.Apellido;
                TxtUsuario.Text = _persona.Usuario;
               
                TxtContrasena.Text = _persona.Password;

                TxtDni.Text = _persona.Dni.ToString();

                CmbPerfil.SelectedValue = _listaPerfiles[_persona.Perfil.Id].ToString();

            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (verificar())
            {
                if (_modoApertura == ModosEdicionEnum.Nuevo)
                {
                    setearObjeto();
                    PersonaDAO.Instancia.insertarPersona(_persona);
                    

                }
                else
                {
                    if (_modoApertura == ModosEdicionEnum.Modificar)
                    {
                        setearObjeto();
                        PersonaDAO.Instancia.actualizarPersona(_persona);
                    }
                }

                Session["persona"] = null;

                string pag = Session["paginaAVolver"].ToString();
                Response.Redirect(pag);
            }
        }

        private void setearObjeto()
        {

            Perfil p=new Perfil();

            foreach (Perfil c in _listaPerfiles.Values.ToList())
            {
                if (c.ToString() == CmbPerfil.SelectedItem.Text)
                {
                    p = c;
                    break;
                }
            }

            if (p.Numero ==Convert.ToInt32( PerfilesEnum.Profesor))
            {
                if (_persona == null)
                    _persona = new BussinesObjects.BussinesObjects.Profesor();

            }
            else
            {
                if (_persona == null)
                    _persona = new BussinesObjects.BussinesObjects.Alumno();

            }

            _persona.Perfil = p;
            _persona.Borrado = false;


            _persona.Nombre = TxtNombre.Text;
            _persona.Apellido = TxtApellido.Text;
            _persona.Dni =int.Parse( TxtDni.Text);
            _persona.Password = TxtContrasena.Text;

            _persona.Usuario = TxtUsuario.Text;
            
        }

        private bool verificar()
        {
            if (TxtNombre.Text.Trim() == "")
            {
                LblMensaje.Text = "Completar campo Nombre";
                return false;
            }
            if (TxtApellido.Text.Trim() == "")
            {
                LblMensaje.Text = "Completar campo Apellido";
                return false;
            }
            if (TxtUsuario.Text.Trim() == "")
            {
                LblMensaje.Text = "Completar campo Usuario";
                return false;
            }
            
            try
            {
                int s = 0;
                s = int.Parse(TxtDni.Text.Trim());

            }
            catch (Exception)
            {
                LblMensaje.Text = "Corregir campo DNI";
                return false;
            }

            if (_modoApertura != ModosEdicionEnum.Nuevo)
            {
                if (TxtContrasena.Text.Trim() == "")
                {
                    LblMensaje.Text = "Completar campo Contraseña";
                    return false;
                }
            }
            else
            {
                if (TxtContrasena.Text.Trim() == "")
                    TxtContrasena.Text = TxtDni.Text.Trim();
            }

            return true;
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session["persona"] = null;
            string pag = Session["paginaAVolver"].ToString();
            Response.Redirect(pag);
        }
    }
}
