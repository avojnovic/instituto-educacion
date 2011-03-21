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
    public partial class VerExamenes : System.Web.UI.Page
    {

        List<Examen> _listaExamen;
        BussinesObjects.BussinesObjects.Persona _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (BussinesObjects.BussinesObjects.Persona)Session["usuario"];

            _listaExamen = ExamenDAO.Instancia.obtenerTodosPorAlumno(_user.Id);


            _listaExamen.Sort(delegate(Examen m1, Examen m2)
            {
                return m2.Fecha.CompareTo(m1.Fecha);
            });

            GridView1.DataSource = _listaExamen;
            GridView1.DataBind();

            setearGrillaSiEstaVacia();
        }

        private void setearGrillaSiEstaVacia()
        {
            if (GridView1.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MateriaStr");
                dt.Columns.Add("FechaStr");
                dt.Columns.Add("NotaStr");




                dt.Rows.Add(new object[] { "", "", "" });

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}
