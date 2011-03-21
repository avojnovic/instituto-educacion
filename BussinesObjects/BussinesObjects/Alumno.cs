using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public class Alumno:Persona
    {
        private List<Materia> _listaMateriasInscriptas;

        public List<Materia> ListaMateriasInscriptas
        {
            get { return _listaMateriasInscriptas; }
            set { _listaMateriasInscriptas = value; }
        }
        private List<Materia> _listaMateriasRendidas;

        public List<Materia> ListaMateriasRendidas
        {
            get { return _listaMateriasRendidas; }
            set { _listaMateriasRendidas = value; }
        }
    }
}
