using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationPracticeDemo.Tests.Tests.API.DragonBallApi
{
    public class DragonBallApiTest
    {       
        [Test]
        public async Task GetCharacters_ShouldContainRequiredFields()
        {
            // Configura el cliente
            var client = new RestClient("https://dragonball-api.com"); // Base URL
            var request = new RestRequest("/api/characters", Method.Get); // Endpoint y el metodo

            // Se ejecuta el request
            var response = await client.ExecuteAsync(request);

            // Validamos las respuestas
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 

            var apiResponse = JsonSerializer.Deserialize<DragonBallApiResponse>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.That(apiResponse?.Items, Is.Not.Null);

            // Validar que todos los personajes tienen los campos requeridos
            foreach (var character in apiResponse.Items)
            {
                Assert.That(character.Id, Is.GreaterThan(0));
                Assert.That(character.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(character.Race, Is.Not.Null.And.Not.Empty);
                Assert.That(character.Gender, Is.Not.Null.And.Not.Empty);
                Assert.That(character.Image, Is.Not.Null.And.Not.Empty);
            }
        }

        [Test]
        public async Task GetCharacters_ShouldReturnPaginationMetadata()
        {
            // Se prepara el cliente
            var client = new RestClient("https://dragonball-api.com");
            var request = new RestRequest("/api/characters", Method.Get);

            // Se ejecuta el request
            var response = await client.ExecuteAsync(request);

            // Se valida el codigo
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Se deserializa la respuesta
            var apiResponse = JsonSerializer.Deserialize<DragonBallApiResponse>(response.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Validar metadata de paginación
            Assert.That(apiResponse?.Meta, Is.Not.Null);
            Assert.That(apiResponse.Meta.TotalItems, Is.GreaterThan(0));
            Assert.That(apiResponse.Meta.ItemCount, Is.GreaterThan(0));
            Assert.That(apiResponse.Meta.CurrentPage, Is.GreaterThan(0));
        }
    }

    // Modelo para la respuesta paginada del API
    public class DragonBallApiResponse
    {
        public List<DragonBallCharacter> Items { get; set; }
        public Meta Meta { get; set; }
        public Links Links { get; set; }
    }

    // Metadata de paginación
    public class Meta
    {
        public int TotalItems { get; set; }
        public int ItemCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }

    // Links de navegación
    public class Links
    {
        public string First { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
        public string Last { get; set; }
    }

    // Modelo para deserializar cada personaje
    public class DragonBallCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ki { get; set; }
        public string MaxKi { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Affiliation { get; set; }
        public string? DeletedAt { get; set; }
    }
}

