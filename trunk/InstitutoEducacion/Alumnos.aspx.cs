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
using DataAccessObjects.DAO;

namespace InstitutoEducacion
{
    public partial class Alumnos : System.Web.UI.Page
    {

        private Dictionary<long, BussinesObjects.BussinesObjects.Persona> _dicPersonas;

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
                dt.Columns.Add("IdPersona");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Apellido");
                dt.Columns.Add("DNIStr");
                dt.Columns.Add("PerfilStr");
               


                dt.Rows.Add(new object[] { "", "", "", "", "" });

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void cargarGrilla()
        {
            _dicPersonas = PersonaDAO.Instancia.obtenerTodosPorPerfil(2);

            List<BussinesObjects.BussinesObjects.Persona> listP = _dicPersonas.Values.ToList();


            listP.Sort(delegate(BussinesObjects.BussinesObjects.Persona p1, BussinesObjects.BussinesObjects.Persona p2)
            {
                return p2.Dni.CompareTo(p1.Dni);
            });


            GridView1.DataSource = listP;

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
                    BussinesObjects.BussinesObjects.Persona p = PersonaDAO.Instancia.obtenerPorId(long.Parse(id));

                    if (p != null && p.Id != 0)
                    {
                        Session["paginaAVolver"] = "Alumnos.aspx";
                        Session["persona"] = p;
                        Response.Redirect("Persona.aspx");
                    }
                }
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Session["paginaAVolver"] = "Alumnos.aspx";
            Session["persona"] = null;
            Response.Redirect("Persona.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {

            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                string id = (row.Cells[1].Text);
                if (id != "&nbsp;")
                {
                    BussinesObjects.BussinesObjects.Persona p = PersonaDAO.Instancia.obtenerPorId(long.Parse(id));

                    if (p != null && p.Id != 0)
                    {
                        p.Borrado = true;
                        PersonaDAO.Instancia.actualizarPersona(p);
                        Response.Redirect("Alumnos.aspx");
                    }
                }
            }
                
            
        }

       
    }
}
