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
using System.Collections.Generic;
using BussinesObjects.BussinesObjects;
using DataAccessObjects.DAO;

namespace InstitutoEducacion
{
    public partial class Materias : System.Web.UI.Page
    {
        private Dictionary<long, Materia> _dicMaterias;

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            setearGrillaSiEstaVacia();
        }

        private void setearGrillaSiEstaVacia()
        {
            if (GridView1.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdMateria");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("CodigoStr");
   



                dt.Rows.Add(new object[] { "", "", "" });

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void cargarGrilla()
        {
            _dicMaterias = MateriaDAO.Instancia.obtenerTodos();

            List<Materia> listM = _dicMaterias.Values.ToList();


            listM.Sort(delegate(Materia m1, Materia m2)
            {
                return m2.Nombre.CompareTo(m1.Nombre);
            });


            GridView1.DataSource = listM;

            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                string id = (row.Cells[1].Text);
                if (id != "&nbsp;")
                {
                    Materia m =MateriaDAO.Instancia.obtenerPorId(long.Parse(id));

                    if (m != null && m.Id != 0)
                    {
                        Session["paginaAVolver"] = "Materias.aspx";
                        Session["materia"] = m;
                        Response.Redirect("MateriaEdit.aspx");
                    }
                }
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Session["paginaAVolver"] = "Materias.aspx";
            Session["materia"] = null;
            Response.Redirect("MateriaEdit.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {

            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                string id = (row.Cells[1].Text);
                if (id != "&nbsp;")
                {
                    Materia m = MateriaDAO.Instancia.obtenerPorId(long.Parse(id));

                    if (m != null && m.Id != 0)
                    {

                        m.Borrado = true;
                        MateriaDAO.Instancia.actualizarMateria(m);
                        Response.Redirect("Materias.aspx");

                      
                    }
                }
            }

        }
    }
}
