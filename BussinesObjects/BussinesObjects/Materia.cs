using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public class Materia
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private long _codigo;

        public long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }

        private List<Persona> _listaInscriptos;

        public List<Persona> ListaInscriptos
        {
            get { return _listaInscriptos; }
            set { _listaInscriptos = value; }
        }

        private List<Materia> _ListaMateriasCorrelativas;

        public List<Materia> ListaMateriasCorrelativas
        {
            get { return _ListaMateriasCorrelativas; }
            set { _ListaMateriasCorrelativas = value; }
        }

        public override string ToString()
        {
            return Codigo+" "+ Nombre;
        }



        public string IdMateria
        {
            get { return Id.ToString(); }
            
        }
        public string CodigoStr
        {
            get { return Codigo.ToString(); }

        }

    }
}
