
using Backend.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FrontEnd.Http
{
    public static class HttpManager
    {
        private static string? _token;
        public static bool IsUserLoggedIn { get; private set; }

        public static readonly SocketsHttpHandler socketsHandler = new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromSeconds(5)
        };
        public static HttpClient HttpClient { get; set; } = new HttpClient(socketsHandler)
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };
        public static void SetToken(string token)
        {
            _token = token;
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<Response<List<ClothingItem>>> GetAllClothing()
        {
            var result = new Response<List<ClothingItem>>();
            try
            {
                 HttpResponseMessage response = await HttpClient.GetAsync("ClothingItems/all");
                //HttpResponseMessage response = await SendRequestAsync(() => new HttpRequestMessage(HttpMethod.Get, "ClothingItems/all"));
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }

                string httpContent = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<ClothingItem>>(httpContent);
                result.ResponseObject = list ?? new List<ClothingItem>();
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");

                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");

                {
                    result.HasError = true;
                    result.ErrorMessage = ex.Message;
                    result.StatusCode = HttpStatusCode.NotFound;
                    return result;
                };
            }
            return result;
        }

        public static async Task<Response<List<ClothingItem>>> GetFilteredClothing(string query)
        {
            Console.WriteLine($"ClothingItems?{query}");

            if (query == "all")
            {
                return await GetAllClothing();
            }

            var result = new Response<List<ClothingItem>>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"ClothingItems?{query}");
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                }

                string httpContent = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<ClothingItem>>(httpContent);

                result.ResponseObject = list ?? new List<ClothingItem>();
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");

                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");

                {
                    result.HasError = true;
                    result.ErrorMessage = ex.Message;
                    result.StatusCode = HttpStatusCode.NotFound;
                };
            }
            return result;
        }

        public static async Task<Response<ClothingItem>> GetClothingById(int id)
        {
            var result = new Response<ClothingItem>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"ClothingItems/{id}");
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }
                string httpContent = await response.Content.ReadAsStringAsync();
                var item = JsonSerializer.Deserialize<ClothingItem>(httpContent);

                result.ResponseObject = item ?? new ClothingItem();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");

                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");

                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;

            }
            return result;
        }


        public static async Task<Response<ClothingItem>> PostClothingItem(ClothingItem newClothingItem, IBrowserFile? imageFile)
        {

            var result = new Response<ClothingItem>();
            try
            {
                Response<int> imageUploadResponse = await UploadImageAsync(imageFile);
                if (imageUploadResponse.HasError)
                {
                    result.HasError = true;
                    result.ErrorMessage = imageUploadResponse.ErrorMessage;
                    return result;
                }

                newClothingItem.ImageId = imageUploadResponse.ResponseObject;



                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("ClothingItems", newClothingItem);
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                }
                string httpContent = await response.Content.ReadAsStringAsync();
                var clothingItem = JsonSerializer.Deserialize<ClothingItem>(httpContent);

                result.ResponseObject = clothingItem;
            }


            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
            }
            return result;
        }
        public static async Task<Response<int>> UploadImageAsync(IBrowserFile file)
        {
            var result = new Response<int>();

            try
            {
                if (file == null)
                {
                    result.HasError = true;
                    result.ErrorMessage = "No file selected.";
                    return result;
                }


                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10_000_000))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                };
                content.Add(fileContent, "file", file.Name);


                HttpResponseMessage response = await HttpClient.PostAsync("ClothingItems/Image", content);

                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    result.ResponseObject = 0;
                }
                else
                {

                    // result.ResponseObject = true;

                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (int.TryParse(responseBody, out int imageId))
                        result.ResponseObject = imageId;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
                result.ResponseObject = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
                result.ResponseObject = 0;
            }

            return result;
        }

        public static async Task<Response<ClothingItem?>> PutClothingItem(int id, ClothingItem updatedItem)
        {
            var result = new Response<ClothingItem>();
            try
            {
                HttpResponseMessage response = await HttpClient.PutAsJsonAsync($"clothing/{id}", updatedItem);
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }
                string httpContent = await response.Content.ReadAsStringAsync();
                var clothingItem = JsonSerializer.Deserialize<ClothingItem>(httpContent);

                result.ResponseObject = clothingItem;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
            }
            return result;
        }

        public static async Task<Response<bool>> DeleteClothingItem(int id)
        {
            var result = new Response<bool>();
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"ClothingItems/{id}");
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    result.ResponseObject = false;
                }

                result.ResponseObject = true;
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
                result.ResponseObject = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
                result.ResponseObject = false;
            }
            return result;
        }

        public static async Task<Response<string>> GetClothingImageById(int imageId)
        {
            string imageSrc;
            var result = new Response<string>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"ClothingItems/Image/imageId/{imageId}");
                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                var base64String = Convert.ToBase64String(imageBytes);
                var contentType = response.Content.Headers.ContentType?.ToString() ?? "image/jpeg";
                imageSrc = $"data:{contentType};base64,{base64String}";
                result.ResponseObject = imageSrc;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
            }
            return result;
        }
        public static async Task<Response<WeatherInfo>> GetWeatherByLocation(string location)
        {
            var result = new Response<WeatherInfo>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"Weather/{location}");
                result.StatusCode = response.StatusCode;
               
                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }
                string httpContent = await response.Content.ReadAsStringAsync();
                var weather = JsonSerializer.Deserialize<WeatherInfo>(httpContent);

                result.ResponseObject = weather;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        public static async Task<Response<string>> GetImageUrlByClothingId(int clothingId)
        {
            string imageSrc;
            var result = new Response<string>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"ClothingItems/Image/clothingId/{clothingId}");
                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                var base64String = Convert.ToBase64String(imageBytes);
                var contentType = response.Content.Headers.ContentType?.ToString() ?? "image/jpeg";
                imageSrc = $"data:{contentType};base64,{base64String}";
                result.ResponseObject = imageSrc;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return result;

        }
        public static async Task<Response<List<ClothingItem>>> GenerateOutfitByLocation(string location)
        {
            var result = new Response<List<ClothingItem>>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"Outfit/{location}");
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    return result;
                }
                string httpContent = await response.Content.ReadAsStringAsync();
                var outfit = JsonSerializer.Deserialize<List<ClothingItem>>(httpContent);

                result.ResponseObject = outfit;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        public static async Task<Response<UserLogin>> PostUserLogin(UserLogin userInfo)
        {

            var result = new Response<UserLogin>();
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Login", userInfo);
                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                }
                string httpContent = await response.Content.ReadAsStringAsync();
                var userLogin = JsonSerializer.Deserialize<UserLogin>(httpContent);

                if (userLogin?.Token != null)
                {
                   SetToken(userLogin.Token);
                    IsUserLoggedIn = true;
                }

                result.ResponseObject = userLogin;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request Failed: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                result.StatusCode = HttpStatusCode.NotFound;
            }
            return result;
        }
        public static void LogoutUser()
        {
            _token = null;
            HttpClient.DefaultRequestHeaders.Authorization = null;
            IsUserLoggedIn = false;
            Console.WriteLine("User Logged out");
        }
    }
}