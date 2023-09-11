using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NegocioCategoria
    {
        private DatosCategoria datosCategoria = new DatosCategoria();
        public List<Categoria> Listar()
        {
            return datosCategoria.Listar();
        }

        public int RegistrarCategoria(Categoria categoria, out string mensaje)
        {
            mensaje = string.Empty;

            if (categoria.descripcion == "")
            {
                mensaje += "Es necesario insertar una categoria \n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return datosCategoria.RegistrarCategoria(categoria, out mensaje);
            }
        }

        public bool EditarCategoria(Categoria categoria, out string mensaje)
        {
            mensaje = string.Empty;

            if (categoria.descripcion == "")
            {
                mensaje += "Es necesario insertar una categoria \n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return datosCategoria.EditarCategoria(categoria, out mensaje);
            }
        }

        public bool EliminarCategoria(Categoria categoria, out string mensaje)
        {
            return datosCategoria.EliminarCategoria(categoria, out mensaje);
        }
    }
}
