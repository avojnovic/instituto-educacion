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

namespace InstitutoEducacion
{
    public partial class Login : System.Web.UI.Page
    {
        public BussinesObjects.BussinesObjects.Persona _user;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            _user = null;

            if (Login1.Password.Trim() != "" && Login1.UserName.Trim() != "")
            {
                _user = PersonaDAO.Instancia.verificarUsuario(Login1.UserName.Trim(), Login1.Password.Trim());

            }

            if (_user != null && _user.Id != 0)
            {
                Session["usuario"] = _user;
                FormsAuthentication.RedirectFromLoginPage(_user.Nombre, false);

            }
        }
    }
}
