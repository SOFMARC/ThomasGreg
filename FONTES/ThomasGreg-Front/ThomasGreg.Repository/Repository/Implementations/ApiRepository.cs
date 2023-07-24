using System.Net.Http.Headers;
using System.Net.Http.Json;
using ThomasGreg.Domain.Entities;
using ThomasGreg.Domain.Interfaces.Repository;
using Microsoft.Extensions.Options;
using System.Net.Http;


namespace ThomasGreg.Repository.Repository.Implementations
{


    public class ApiRepository : IApiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _apiHttpClient;
        private readonly HttpClient _authApiHttpClient;
        private readonly AuthApiSettings _authApiSettings;
        private readonly ApiSettings _apiSettings;

        public ApiRepository(HttpClient httpClient, IHttpClientFactory httpClientFactory, IOptions<AuthApiSettings> authApiSettings, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiHttpClient = httpClientFactory.CreateClient("ApiHttpClient");

            _authApiHttpClient = httpClientFactory.CreateClient("AuthApiHttpClient");
            _authApiSettings = authApiSettings.Value;
            _apiSettings = apiSettings.Value;
        }
        private async Task AuthenticateAsync()
        {
            if (string.IsNullOrEmpty(_authApiSettings.Username) || string.IsNullOrEmpty(_authApiSettings.Password))
            {
                //não definidor ainda, cliar mais tarde
            }

            if (string.IsNullOrEmpty(_authApiHttpClient.DefaultRequestHeaders.Authorization?.Parameter))
            {
                //var response = await _authApiHttpClient.PostAsJsonAsync("login", new
                //{
                //    Username = _authApiSettings.Username,
                //    Password = _authApiSettings.Password,
                //    nome = _authApiSettings.Username
                //});
                var response = await _authApiHttpClient.PostAsJsonAsync($"{_authApiSettings.BaseApiUrl}/login", new
                {
                    userName = _authApiSettings.Username,
                    nome = _authApiSettings.Username, // supondo que o 'nome' é igual ao 'userName'
                    passwordHash = _authApiSettings.Password
                });

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();

                var token = result["token"];
                _authApiHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }


        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;
           
            var response = await _apiHttpClient.GetAsync($"{_apiSettings.BaseApiUrl}/cliente/{id}");

            response.EnsureSuccessStatusCode();

            var cliente = await response.Content.ReadFromJsonAsync<Cliente>();

            return cliente;
        }



        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;

           
            var response = await _apiHttpClient.PostAsJsonAsync($"{_apiSettings.BaseApiUrl}/cliente", cliente);


            response.EnsureSuccessStatusCode();

            var clienteAdicionado = await response.Content.ReadFromJsonAsync<Cliente>();

            return clienteAdicionado;
        }


        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;
 
            var response = await _apiHttpClient.PutAsJsonAsync($"{_apiSettings.BaseApiUrl}/cliente/{cliente.Id}", cliente);

            response.EnsureSuccessStatusCode();

            var clienteAtualizado = cliente;

            return clienteAtualizado;
        }


        public async Task DeleteClienteAsync(int id)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;

            var response = await _apiHttpClient.DeleteAsync($"{_apiSettings.BaseApiUrl}/cliente/{id}");


            response.EnsureSuccessStatusCode();
        }


        public async Task<Logradouro> GetLogradouroByIdAsync(int id)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;
           
            var response = await _apiHttpClient.GetAsync($"{_apiSettings.BaseApiUrl}/logradouros/{id}");


            response.EnsureSuccessStatusCode();

            var logradouro = await response.Content.ReadFromJsonAsync<Logradouro>();

            return logradouro;
        }

        public async Task<Logradouro> AddLogradouroAsync(Logradouro logradouro)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;

            var response = await _apiHttpClient.PostAsJsonAsync($"{_apiSettings.BaseApiUrl}/logradouros", logradouro);

            response.EnsureSuccessStatusCode();

            var logradouroAdicionado = await response.Content.ReadFromJsonAsync<Logradouro>();

            return logradouroAdicionado;
        }

        public async Task<Logradouro> UpdateLogradouroAsync(Logradouro logradouro)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;
      
            var response = await _apiHttpClient.PutAsJsonAsync($"{_apiSettings.BaseApiUrl}/logradouros/{logradouro.Id}", logradouro);


            response.EnsureSuccessStatusCode();

            var logradouroAtualizado = await response.Content.ReadFromJsonAsync<Logradouro>();

            return logradouroAtualizado;
        }

        public async Task DeleteLogradouroAsync(int id)
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;
           
            var response = await _apiHttpClient.DeleteAsync($"{_apiSettings.BaseApiUrl}/logradouros/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;

            var response = await _apiHttpClient.GetAsync($"{_apiSettings.BaseApiUrl}/cliente");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return Enumerable.Empty<Cliente>();
            }

            response.EnsureSuccessStatusCode();

            var clientes = await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();

            return clientes;
        }


        public async Task<IEnumerable<Logradouro>> GetAllLogradouroAsync()
        {
            await AuthenticateAsync();

            _apiHttpClient.DefaultRequestHeaders.Authorization = _authApiHttpClient.DefaultRequestHeaders.Authorization;

            var response = await _apiHttpClient.GetAsync($"{_apiSettings.BaseApiUrl}/Logradouro");

            response.EnsureSuccessStatusCode();

            var logradouros = await response.Content.ReadFromJsonAsync<IEnumerable<Logradouro>>();

            return logradouros;
        }
    }
}



