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
    public partial class Inscripcion : System.Web.UI.Page
    {
        private Dictionary<long, Materia> _dicMaterias;
        BussinesObjects.BussinesObjects.Persona _alumno;
        private Dictionary<long, Materia> _dicMateriasInscriptas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BtnGuardar.Attributes.Add("OnClick", "javascript:if(confirm('¿Esta seguro que desea inscribirse a las materias seleccionadas?')== false) return false;");
            }

            _alumno = (BussinesObjects.BussinesObjects.Persona)Session["usuario"];
            cargarCombo();
        }

        private void cargarCombo()
        {
            if (_alumno != null)
            {
                _dicMaterias = MateriaDAO.Instancia.obtenerTodosAInscribirse(_alumno.Id);
                _dicMateriasInscriptas = MateriaDAO.Instancia.obtenerMateriasInscriptas(_alumno.Id);

                ListBoxMateriasInscriptas.DataSource = _dicMateriasInscriptas.Values.ToList();
                ListBoxMateriasInscriptas.DataBind();
            }

            

            if (!IsPostBack)
            {
                ListMateriasCheck.DataSource = _dicMaterias.Values.ToList();
                ListMateriasCheck.DataBind();
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            MateriaDAO.Instancia.BorrarInscripciones(_alumno.Id);
            for (int i = 0; i < ListMateriasCheck.Items.Count; i++)
            {

                if (ListMateriasCheck.Items[i].Selected)
                {
                    Materia m = new Materia();

                    foreach (Materia mat in _dicMaterias.Values.ToList())
                    {
                        if (mat.ToString() == ListMateriasCheck.Items[i].Text)
                        {
                            m = mat;
                            break;
                        }
                    }

                    MateriaDAO.Instancia.inscribirAMateria(_alumno.Id, m.Id);
                }

            }


        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


    }
}
