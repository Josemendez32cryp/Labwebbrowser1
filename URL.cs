using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paginaweb1
{
    internal class URL
    {
        String direccion;
        private int cantidad;
        DateTime ultimoacceso;

        public string Direccion { get => direccion; set => direccion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime Ultimoacceso { get => ultimoacceso; set => ultimoacceso = value; }
    }
}
