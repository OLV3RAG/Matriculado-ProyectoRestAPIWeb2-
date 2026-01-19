using Dominio.Entidades;
using Infraestructura.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplicacion
{
    public class AlumnoNegocio
    {
        public async Task<Registros> RegistrarInfo(Persona per)
        {
            Registros reg = new Registros();
            string resource = "Alumno/Crear";
            HttpClientService httpCS = new HttpClientService();
            reg = await httpCS.PostPersonas(resource, per);
            return reg;
        }

        public async Task<List<Genero>> CargarGen()
        {
            List<Genero> gen = new List<Genero>();
            HttpClientService httpCS = new HttpClientService();
            string resource = "Catalogos/ObtenerGenerosAlumnos";
            gen = await httpCS.GetGenero(resource);
            return gen;
        }

        public async Task<List<TipoPersona>> CargarTipoPer()
        {
            List<TipoPersona> tipoPer = new List<TipoPersona>();
            HttpClientService httpCS = new HttpClientService();
            string resource = "Catalogos/ObtenerTipoPersonas";
            tipoPer = await httpCS.GetTipoPersona(resource);
            return tipoPer;
        }
    }
}
