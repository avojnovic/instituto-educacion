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
using DataAccessObjects.DAO;
using BussinesObjects.BussinesObjects;
using System.Collections.Generic;

namespace InstitutoEducacion.Images
{
    public partial class AsignacionMateria : System.Web.UI.Page
    {
        Dictionary<long, BussinesObjects.BussinesObjects.Persona> _listaProfesores = new Dictionary<long, BussinesObjects.BussinesObjects.Persona>();
        Dictionary<long, BussinesObjects.BussinesObjects.Materia> _listaMaterias = new Dictionary<long, BussinesObjects.BussinesObjects.Materia>();
        Dictionary<long, BussinesObjects.BussinesObjects.Materia> _listaMateriasAsignadas = new Dictionary<long, BussinesObjects.BussinesObjects.Materia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            _listaProfesores = PersonaDAO.Instancia.obtenerTodosPorPerfil(PerfilesEnum.Profesor);
            _listaMaterias = MateriaDAO.Instancia.obtenerTodos();

            if (!IsPostBack)
            {
                cargarCombos();
            }
        }

        private void cargarCombos()
        {
            CmbProfesores.DataSource = _listaProfesores.Values.ToList();
            CmbProfesores.DataBind();

            CmbMaterias.DataSource = _listaMaterias.Values.ToList();
            CmbMaterias.DataBind();

            CargarAsignaciones();

        }

        protected void CmbProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAsignaciones();
        }

        private void CargarAsignaciones()
        {
            BussinesObjects.BussinesObjects.Persona p = new Profesor();

            foreach (BussinesObjects.BussinesObjects.Persona prof in _listaProfesores.Values.ToList())
            {
                if (prof.ToString() == CmbProfesores.SelectedItem.Text)
                {
                    p = (Profesor)prof;
                    break;
                }
            }


            _listaMateriasAsignadas = MateriaDAO.Instancia.obtenerMateriasAsignadas(p.Id);

            ListBoxMateriasAsignadas.DataSource = _listaMateriasAsignadas.Values.ToList();
            ListBoxMateriasAsignadas.DataBind();
        }

        protected void BtnAsignar_Click(object sender, EventArgs e)
        {
            BussinesObjects.BussinesObjects.Persona p = new Profesor();

            foreach (BussinesObjects.BussinesObjects.Persona prof in _listaProfesores.Values.ToList())
            {
                if (prof.ToString() == CmbProfesores.SelectedItem.Text)
                {
                    p = (Profesor)prof;
                    break;
                }
            }


            Materia m = new Materia();

            foreach (Materia mat in _listaMaterias.Values.ToList())
            {
                if (mat.ToString() == CmbMaterias.SelectedItem.Text)
                {
                    m = mat;
                    break;
                }
            }


            if (!_listaMateriasAsignadas.ContainsKey(m.Id))
            {
                _listaMateriasAsignadas.Add(m.Id, m);
                MateriaDAO.Instancia.insertarProfesorAsignado(p.Id, m.Id);

                CargarAsignaciones();
            }

        }

        protected void BtnQuitar_Click(object sender, EventArgs e)
        {
            BussinesObjects.BussinesObjects.Persona p = new Profesor();

            foreach (BussinesObjects.BussinesObjects.Persona prof in _listaProfesores.Values.ToList())
            {
                if (prof.ToString() == CmbProfesores.SelectedItem.Text)
                {
                    p = (Profesor)prof;
                    break;
                }
            }


            Materia m = new Materia();

            foreach (Materia mat in _listaMaterias.Values.ToList())
            {
                if (mat.ToString() == ListBoxMateriasAsignadas.SelectedItem.Text)
                {
                    m = mat;
                    break;
                }
            }


            if (m != null && m.Id > 0 && p != null && p.Id > 0)
            {
                MateriaDAO.Instancia.quitarProfesorAsignado(p.Id, m.Id);
                CargarAsignaciones();
            }
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void CmbProfesores_DataBinding(object sender, EventArgs e)
        {
            
        }
    }
}
