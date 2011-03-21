using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public abstract class Persona
    {

        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private long _dni;

        public long Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }

        private Perfil _perfil;

        public Perfil Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }


        public string IdPersona
        {
            get { return _id.ToString(); }
           
        }
        public string DNIStr
        {
            get { return _dni.ToString(); }
        }

        public string PerfilStr
        {
            get { return _perfil.Nombre; }
        }

        public override string ToString()
        {
            return Apellido+" "+Nombre+" - " +Dni ;
        }
    }
}
