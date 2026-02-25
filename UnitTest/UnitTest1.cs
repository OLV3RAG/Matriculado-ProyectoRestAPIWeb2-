using Dominio.Entidades;
using Infraestructura.Servicios;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task GetMunicipios()
        {
            HttpClientService httpClientService = new HttpClientService();
            httpClientService.httpClient = new HttpClient();
            httpClientService.httpClient.Timeout.Add(TimeSpan.FromSeconds(60));
            httpClientService.httpClient.BaseAddress = new Uri("http://localhost:7004/");
            var result = await httpClientService.Get("Catalogos/ObtenerMunicipios");


        }

        [Test]

        public async Task PostRegistros()
        {
            Persona per = new Persona();
            per.Nombre = "Jose";
            per.ApellidoPaterno = "Garcia";
            per.ApellidoMaterno = "Alvarado";
            per.CURP = "JOALVRTD55HLBTF";
            per.FechaNacimiento = new DateTime(1982, 02, 01);
            per.TipoPersonaID = 2;
            per.GeneroID = 1;
            HttpClientService httpCS = new HttpClientService();
            httpCS.httpClient = new HttpClient();
            httpCS.httpClient.Timeout.Add(TimeSpan.FromSeconds(60));
            httpCS.httpClient.BaseAddress = new Uri("http://localhost:7004/");
            var result = await httpCS.PostPersonas("Alumno/Crear", per);
        }
        
    
    }
}