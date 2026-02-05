using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.Servicios
{
    public interface IHttpClientService
    {
        Task<List<Municipio>> Get(string resource);

        Task<List<Registros>> PostPersonas(string resource, Persona per);

        Task<List<Genero>> GetGenero(string resource);
        Task<List<TipoPersona>> GetTipoPersona(string resource);

    }
}
