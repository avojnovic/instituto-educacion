﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesObjects.Exceptions
{
    public class ExcepcionComunicacionBD : Exception
    {
        public ExcepcionComunicacionBD(Exception innerException)
            : base("", innerException)
        {

        }
    }
}
