using Dominio.Entidades;
using Infraestructura.Servicios;
using Moq;
using Moq.Protected;
using System.Net;

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
            var handler = new Mock<HttpMessageHandler>();

            handler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{ \"id\": 1, \"nombre\": \"Municipio Test\" }]")
                });

            var httpClient = new HttpClient(handler.Object);
            httpClient.BaseAddress = new Uri("http://fake-url.com/");

            var service = new HttpClientService();
            service.httpClient = httpClient;

            var result = await service.Get("Catalogos/ObtenerMunicipios");

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task PostRegistros()
        {
            var handler = new Mock<HttpMessageHandler>();

            handler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"success\": true }", System.Text.Encoding.UTF8, "application/json")
                });

            var httpClient = new HttpClient(handler.Object);
            httpClient.BaseAddress = new Uri("http://fake-url.com/");

            var service = new HttpClientService();
            service.httpClient = httpClient;

            var per = new Persona
            {
                Nombre = "Jose",
                ApellidoPaterno = "Garcia",
                ApellidoMaterno = "Alvarado",
                CURP = "JOALVRTD55HLBTF",
                FechaNacimiento = new DateTime(1982, 02, 01),
                TipoPersonaID = 2,
                GeneroID = 1
            };

            var result = await service.PostPersonas("Alumno/Crear", per);

            Assert.IsNotNull(result);
        }


    }
}