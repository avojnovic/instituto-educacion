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
using System.Collections.Generic;
using DataAccessObjects.DAO;

namespace InstitutoEducacion
{
    public partial class MateriaEdit : System.Web.UI.Page
    {

        public Materia _materia = null;
        ModosEdicionEnum _modoApertura = new ModosEdicionEnum();
        Dictionary<long, Materia> _listaMaterias = new Dictionary<long, Materia>();
        

        protected void Page_Load(object sender, EventArgs e)
        {

            _materia = (Materia)Session["materia"];
            LblMensaje.Text = "";

           
            if (_materia != null)
            {
                _modoApertura = ModosEdicionEnum.Modificar;
                _listaMaterias = MateriaDAO.Instancia.obtenerTodosMenos(_materia.Id);
               

            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
                _listaMaterias = MateriaDAO.Instancia.obtenerTodos();
           
            }

            if (!IsPostBack)
            {
              
                if (_materia != null)
                {
                    //_materia.ListaInscriptos = PersonaDAO.Instancia.obtenerTodosPorMateria(_materia.Id);
                    _materia.ListaMateriasCorrelativas = MateriaDAO.Instancia.obtenerCorrelativas(_materia.Id);
                    
                }

                cargarCombos();
                cargarMateria();

            }


          

        }

        private void cargarCombos()
        {
            if (_materia != null)
            {
                foreach (Materia m in _materia.ListaMateriasCorrelativas)
                {
                    if (_listaMaterias.ContainsKey(m.Id))
                        _listaMaterias.Remove(m.Id);
                }
            }

            ListBoxMateriasTodas.DataSource = _listaMaterias.Values.ToList();
            ListBoxMateriasTodas.DataBind();
          
        }

        private void cargarMateria()
        {
            if (_materia != null)
            {
                TxtNombre.Text = _materia.Nombre;
                TxtCodigo.Text = _materia.Codigo.ToString();

                ListBoxMateriasCorrelativas.DataSource = _materia.ListaMateriasCorrelativas;
                ListBoxMateriasCorrelativas.DataBind();
               
            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (verificar())
            {
                if (_modoApertura == ModosEdicionEnum.Nuevo)
                {
                    setearObjeto();
                    MateriaDAO.Instancia.insertarMateria(_materia);
                    
                }
                else
                {
                    if (_modoApertura == ModosEdicionEnum.Modificar)
                    {
                        setearObjeto();
                        MateriaDAO.Instancia.actualizarMateria(_materia);
                    }
                }

                Session["materia"] = null;

                string pag = Session["paginaAVolver"].ToString();
                Response.Redirect(pag);
            }

        }

        private void setearObjeto()
        {
         
           if (_materia == null)
              _materia = new Materia();

           _materia.Borrado = false;
           _materia.Codigo =long.Parse( TxtCodigo.Text);

           _materia.Nombre = TxtNombre.Text;


           _materia.ListaMateriasCorrelativas = new List<Materia>();


           foreach (ListItem item in ListBoxMateriasCorrelativas.Items)
           {
               foreach (Materia m in _listaMaterias.Values.ToList())
               {
                   if (m.ToString() ==item.Text)
                   {
                       _materia.ListaMateriasCorrelativas.Add(m);
                       break;
                   }
                   
               }
               
           }


           
        }

        private bool verificar()
        {
            if (TxtNombre.Text.Trim() == "")
            {
                LblMensaje.Text = "Completar campo Nombre";
                return false;
            }
            if (TxtCodigo.Text.Trim() == "")
            {
                LblMensaje.Text = "Completar campo Codigo";
                return false;
            }


            try
            {
                int s = 0;
                s = int.Parse(TxtCodigo.Text.Trim());

            }
            catch (Exception)
            {
                LblMensaje.Text = "Corregir campo Codigo";
                return false;
            }

            return true;
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session["materia"] = null;
            string pag = Session["paginaAVolver"].ToString();
            Response.Redirect(pag);
        }

        protected void BtnQtarCorrelativa_Click(object sender, EventArgs e)
        {
            ListBoxMateriasTodas.Items.Add(ListBoxMateriasCorrelativas.SelectedItem);
            ListBoxMateriasCorrelativas.Items.Remove(ListBoxMateriasCorrelativas.SelectedItem);

        }

        protected void BtnAgrCorrelativa_Click(object sender, EventArgs e)
        {
            ListBoxMateriasCorrelativas.Items.Add(ListBoxMateriasTodas.SelectedItem);
            ListBoxMateriasTodas.Items.Remove(ListBoxMateriasTodas.SelectedItem);
        }

        protected void ListBoxMateriasTodas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxMateriasCorrelativas.ClearSelection();
        }

        protected void ListBoxMateriasCorrelativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxMateriasTodas.ClearSelection();
        }

       


    }
}
