using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VideoGamesBackend.Models;

namespace VideoGamesBackend.Controllers
{
    public class ApiController
    {
        // La clase HttpClient es una clase que permite enviar solicitudes HTTP a un servidor y recibir respuestas HTTP.
        // Se utiliza para interactuar con APIs y servicios web.
        private readonly HttpClient _httpClient;
        private const string API_KEY = "69c35b37c8894720b413bbcc5cb67c14";
        private const string ApiUrl = $"https://api.rawg.io/api/games?key={API_KEY}";

        public ApiController() // declaramso el constructor
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Videogame>> GetVideogamesFromAPI()
        {
            List<Videogame> videogames = new List<Videogame>(); // declaramos el arreglo cuyos elementos seran del tipo "Videogame"

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    //videogames = await response.Content.ReadAsAsync<List<Videogame>>(); --> la propiedad "ReadAsAsync" se dejo de usar y por eos daba error

                    // leemos el contenido de la respuesta Http y retornamos el valor de esta peticion, desserializando el contenido JSON
                    // en una operacion asyncronica...devolviendo una lista(array) donde sus elementos seran parceados al modelo de "Videogame"
                    videogames = await response.Content.ReadFromJsonAsync<List<Videogame>>();
                }
                else
                {
                    Console.WriteLine("Error al obtener los datos de la API y colocarlas en un arreglo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al  realizar la peticion a la API: {ex.Message}");
            }

            return videogames; // retornamos el arreglo de videojuegos
        }


    }
}
