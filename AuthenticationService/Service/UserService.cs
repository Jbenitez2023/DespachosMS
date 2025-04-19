using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AuthenticationService.Service
{
    public class UserService :IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
        }

        public async Task<ActionResult<UserDataResponseDto>> validateUser(UserData login)
        {
            if (login == null)
            {
                return new BadRequestObjectResult("Invalid client request");
            }

            try {

                var loginData = new
                {
                    userName = login.userName,
                    password = login.password
                };

                var content = new StringContent(
                      JsonConvert.SerializeObject(loginData),
                      Encoding.UTF8,
                      "application/json"
                  );

                var response = await _httpClient.PostAsync("http://localhost:8007/api/v1/User/UserValidation", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    UserDataResponseDto loginRequest = JsonConvert.DeserializeObject<UserDataResponseDto>(responseContent);
                    return loginRequest; // Aquí puedes manejar el token o la respuesta.
                }
                else
                {
                    // Manejo de errores en caso de fallo
                    throw new Exception("Login failed");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Invalid client request");
            }
        }
    }
}
