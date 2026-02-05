using Contratos.Servicios;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infraestructura.Servicios
{
 
    public class HttpClientService : IHttpClientService
    {
        public HttpClient httpClient = new HttpClient();
        public HttpClientService()
        {
            httpClient.BaseAddress = new Uri( "https://localhost:7004/");
        }
        public async Task<List<Municipio>> Get(string resource)
        {
            try
            {
                var result = await httpClient.GetAsync(resource);
                var contenido = await result.Content.ReadAsStringAsync();
                var mpo = System.Text.Json.JsonSerializer.Deserialize<List<Municipio>>(contenido);
                    return mpo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            
             
        }

        public async Task<List<Registros>> PostPersonas(string resource, Persona per)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync(resource, per);
                var contenido = await result.Content.ReadAsStringAsync();
                var perso = System.Text.Json.JsonSerializer.Deserialize<List<Registros>>(contenido);
                return perso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Genero>> GetGenero(string resource)
        {
            try
            {
                var result = await httpClient.GetAsync(resource);
                var contenido = await result.Content.ReadAsStringAsync();
                var gene = System.Text.Json.JsonSerializer.Deserialize<List<Genero>>(contenido);
                return gene;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<List<TipoPersona>> GetTipoPersona(string resource)
        {
            try
            {
                var result = await httpClient.GetAsync(resource);
                var contenido = await result.Content.ReadAsStringAsync();
                var perso = System.Text.Json.JsonSerializer.Deserialize<List<TipoPersona>>(contenido);
                return perso;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
