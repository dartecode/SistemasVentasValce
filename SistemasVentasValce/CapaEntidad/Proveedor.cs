﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public int idProveedor { get; set; }
        public string cedula { get; set; }
        public string razonSocial { get; set; }
        public string email { get; set;}
        public string telefono { get; set; }
        public bool estado { get; set; }
        public string fechaCreacion { get; set; }

    }
}
