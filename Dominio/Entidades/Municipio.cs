using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Municipio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int EstadoID { get; set; }
    }
}
