using Backend.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Net;
using System.Text.Json;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace FrontEnd.Http
{
    public static class HttpManager
    {
        public static readonly SocketsHttpHandler socketsHandler = new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromSeconds(5)
        };
        public static HttpClient HttpClient { get; set; } = new HttpClient(socketsHandler)
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };

        public static async Task<Response<List<ClothingItem>>> GetAllClothing()
        {
            var result = new Response<List<ClothingItem>>();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("ClothingItems/all");
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
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");

                {
                    result.HasError = true;
                    result.ErrorMessage = ex.Message;
                    result.StatusCode = System.Net.HttpStatusCode.NotFound;
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
                result.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");

                {
                    result.HasError = true;
                    result.ErrorMessage = ex.Message;
                    result.StatusCode = System.Net.HttpStatusCode.NotFound;
                };
            }
            return result;
        }

        public static async Task<Response<ClothingItem>> PostClothingItem(ClothingItem newClothingItem, IBrowserFile imageFile)
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
                var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10_000_000)) // Image size set to 10MB
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                };
                content.Add(fileContent, "file", file.Name);


                HttpResponseMessage response = await HttpClient.PostAsync("Image", content);

                result.StatusCode = response.StatusCode;

                if (!response.IsSuccessStatusCode)
                {
                    result.HasError = true;
                    result.ErrorMessage = $"Http Error: {response.StatusCode}";
                    result.ResponseObject = 0;

                    Console.WriteLine("Image Upload Attempt Failure : " + result.ErrorMessage);
                }
                else
                {
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
                result.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        public static async Task<Response<bool>> DeleteClothingItem(int id)
        {
            var result = new Response<bool>();
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"clothing/{id}");
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


    }
}
