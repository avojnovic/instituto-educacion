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

namespace InstitutoEducacion
{
    public partial class EditarMisDatos : System.Web.UI.Page
    {
        BussinesObjects.BussinesObjects.Persona _user;

        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (BussinesObjects.BussinesObjects.Persona)Session["usuario"];

            Session["paginaAVolver"] = "Default.aspx";
            Session["persona"] = _user;
            Response.Redirect("Persona.aspx");
        }
    }
}
