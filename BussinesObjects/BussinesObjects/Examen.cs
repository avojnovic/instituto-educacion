using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public class Examen
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Materia _materia;

        public Materia Materia
        {
            get { return _materia; }
            set { _materia = value; }
        }
        private Alumno _alumno;

        public Alumno Alumno
        {
            get { return _alumno; }
            set { _alumno = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private double _nota;

        public double Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }


        public string MateriaStr
        {
            get { return Materia.Codigo +" - "+ Materia.Nombre; }
        }
        public string FechaStr
        {
            get { return Fecha.ToShortDateString(); }
        }
        public string NotaStr
        {
            get { return Nota.ToString(); }
        }
    }
}
