using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.BussinesObjects
{
    public class Profesor:Persona
    {
        private List<Materia> _listaMateriasDictadas;

        public List<Materia> ListaMateriasDictadas
        {
            get { return _listaMateriasDictadas; }
            set { _listaMateriasDictadas = value; }
        }

    }
}
