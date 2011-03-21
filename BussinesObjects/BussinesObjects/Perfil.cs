using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public class Perfil
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _numero;

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
