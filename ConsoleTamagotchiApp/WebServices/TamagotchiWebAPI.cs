using ConsoleTamagotchiApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleTamagotchiApp.WebServices
{
    public class TamagotchiWebAPI
    {
        private HttpClient client;
        private string baseUri;

        public TamagotchiWebAPI(string baseUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
        }

        public async Task<string> GetTestAsync()
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/Test");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<ActionOptionDTO>> GetAllGamesAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetAllGames");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActionOptionDTO> fList = JsonSerializer.Deserialize<List<ActionOptionDTO>>(content, options);
                    return fList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> DoActionPlayAsync(ActionOptionDTO actionOptionDTO)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUri}/DoActionPlay";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(actionOptionDTO);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<ActionOptionDTO>> GetAllFoodAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetAllFood");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActionOptionDTO> fList = JsonSerializer.Deserialize<List<ActionOptionDTO>>(content, options);
                    return fList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<PlayerDTO> SignUpAsync(PlayerDTO player1)
        {
            try
            {
                string jason = JsonSerializer.Serialize(player1);
                StringContent content = new StringContent(jason, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/SignUp", content);
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content2 = await response.Content.ReadAsStringAsync();
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(content2, options);
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> DoActionFeedAsync(ActionOptionDTO actionOptionDTO)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUri}/DoActionFeed";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(actionOptionDTO);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public async Task<List<PetDTO>> GetPlayerPetsAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetPets");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }; 
                    string content = await response.Content.ReadAsStringAsync();
                    List<PetDTO> fList = JsonSerializer.Deserialize<List<PetDTO>>(content, options);
                    return fList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async void UpdateAsync(PlayerDTO player)
        {
            string json = JsonSerializer.Serialize(player);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/Update", content);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string contentt = await response.Content.ReadAsStringAsync();
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(contentt, options);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            }
        public async Task<PlayerDTO> LoginAsync(string email, string pass)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/Login?email={email}&pass={pass}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(content, options);
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
