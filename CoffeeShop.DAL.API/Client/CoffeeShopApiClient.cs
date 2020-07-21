using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;

namespace CoffeeShop.DAL.API.Client
{
    public class CoffeeShopApiClient : ICoffeeShopApiClient
    {
        private readonly string _baseAddress;

        public CoffeeShopApiClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        #region //Order

        public async Task CreateOrder(Domain.Entities.Order order)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(order);
                    HttpContent data = Content(json);

                    httpResponse = await client.PostAsync("/api/CoffeeShop/CreateOrder", data);

                    // if (httpResponse == null)
                    // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException)
            {

            }
            catch (Exception)
            {

            }
        }

        public async Task<List<Domain.Entities.Order>> GetOrders(int clientId)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/CoffeeShop/GetOrders?clientId={clientId}";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<List<Domain.Entities.Order>>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException)
            {
                return new List<Domain.Entities.Order>();
            }
            catch (Exception)
            {
                return new List<Domain.Entities.Order>();
            }
        }

        #endregion //Order 

        #region //Client

        public async Task<List<Domain.Entities.Client>> GetClients()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/CoffeeShop/GetClients";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<List<Domain.Entities.Client>>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException)
            {
                return new List<Domain.Entities.Client>();
            }
            catch (Exception)
            {
                return new List<Domain.Entities.Client>();
            }
        }

        #endregion //Client

        #region //Point

        //Task<List<Domain.Entities.Point>> GetPointsByClientId(int id);

        public async Task CreatePoint(Domain.Entities.Point point)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(point);
                    HttpContent data = Content(json);

                    httpResponse = await client.PostAsync("/api/CoffeeShop/CreatePoint", data);

                    // if (httpResponse == null)
                    // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException)
            {

            }
            catch (Exception)
            {

            }
        }

        #endregion //Point

        #region //PointConvert

        //Task<List<Domain.Entities.Point>> GetConvertedPoints(int id);

        public async Task CreateConvertedPoints(Domain.Entities.PointConvert pointConvert)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(pointConvert);
                    HttpContent data = Content(json);

                    httpResponse = await client.PostAsync("/api/CoffeeShop/CreateConvertedPoints", data);

                    // if (httpResponse == null)
                    // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException)
            {

            }
            catch (Exception)
            {

            }
        }

        #endregion //PointConvert

        #region //ClientCoffee

        public async Task<Domain.Entities.ClientCoffee> GetClientCoffeeBought(int id)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/CoffeeShop/GetClientCoffeeBought?id={id}";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<Domain.Entities.ClientCoffee>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException)
            {
                return new Domain.Entities.ClientCoffee();
            }
            catch (Exception)
            {
                return new Domain.Entities.ClientCoffee();
            }
        }

        public async Task CreateClientCoffee(Domain.Entities.ClientCoffee clientCoffee)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(clientCoffee);
                    HttpContent data = Content(json);

                    httpResponse = await client.PostAsync("/api/CoffeeShop/CreateClientCoffee", data);

                    // if (httpResponse == null)
                    // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException)
            {

            }
            catch (Exception)
            {

            }
        }

        public async Task UpdateClientCoffee(Domain.Entities.ClientCoffee clientCoffee)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(clientCoffee);
                    HttpContent data = Content(json);

                    httpResponse = await client.PutAsync("/api/CoffeeShop/UpdateClientCoffee", data);

                    // if (httpResponse == null)
                    // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException)
            {

            }
            catch (Exception)
            {

            }
        }

        #endregion //ClientCoffee

        #region //PointWorth

        public async Task<Domain.Entities.PointWorth> GetPointWorth()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/CoffeeShop/GetPointWorth";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<Domain.Entities.PointWorth>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException)
            {
                return new Domain.Entities.PointWorth();
            }
            catch (Exception)
            {
                return new Domain.Entities.PointWorth();
            }
        }

        #endregion //PointWorth

        #region //CoffeePointWorth

        public async Task<Domain.Entities.CoffeePointWorth> GetCoffeePointWorth()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/CoffeeShop/GetCoffeePointWorth";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<Domain.Entities.CoffeePointWorth>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException)
            {
                return new Domain.Entities.CoffeePointWorth();
            }
            catch (Exception)
            {
                return new Domain.Entities.CoffeePointWorth();
            }
        }

        #endregion //CoffeePointWorth

        private HttpContent Content(string json)
        {
            HttpContent data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

        private HttpClient Client()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

    }
}
