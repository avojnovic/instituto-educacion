using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public class Instituto
    {
        private List<Materia> _listaMaterias;

        public List<Materia> ListaMaterias
        {
            get { return _listaMaterias; }
            set { _listaMaterias = value; }
        }
        private List<Alumno> _listaAlumnos;

        public List<Alumno> ListaAlumnos
        {
            get { return _listaAlumnos; }
            set { _listaAlumnos = value; }
        }
        private List<Profesor> _listaProfesores;

        public List<Profesor> ListaProfesores
        {
            get { return _listaProfesores; }
            set { _listaProfesores = value; }
        }
    }
}
