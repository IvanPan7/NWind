using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NWindProxyService
{
    // HTTPClient,esta y paquete Newtosoft.Json.
    public class Proxy
    {
        string BaseAddress = "http://192.168.60.162:52546";

        public async Task<T> SendPost<T, PostData>
            (string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    //URI Absoluto
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var JSONData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response = await Client.PostAsync(requestURI, new StringContent(JSONData.ToString(), Encoding.UTF8, "application/json"));
                    var ResultWebApi = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebApi);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return Result;
        }
        public async Task<T> SendGet<T>(string requestURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var ResultJSON = await Client.GetStringAsync(requestURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return Result;
        }
        //Implementar el CRUD del servicio.
        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            return await SendPost<Product, Product>("/api/nwind/createproduct", newProduct);
        }
        public async Task<Product> RetrieveProductByIdAsync(int ID)
        {
            return await SendGet<Product>($"/api/nwind/RetrieveProductByID/{ID}");
        }
        public async Task<bool> UpdateProductAsync(Product productToUpdate)
        {
            return await SendPost<bool, Product>("/api/nwind/UpdateProduct", productToUpdate);
        }
        public async Task<bool> DeleteProductAsync(int ID)
        {
            return await SendGet<bool>($"/api/nwind/DeleteProduct/{ID}");
        }

        //FilterProducts by Category ID
        public async Task<List<Product>> FilterProductsByCategoryIDAsync(int ID)
        {
            return await SendGet<List<Product>>($"/api/nwind/FilterProductsByCategoryID/{ID}");
        }
        //Category 
        public async Task<Category> CreateCategoryAsync(Category newCategory)
        {
            return await SendPost<Category, Category>("/api/nwind/createcategory", newCategory);
        }
    }
}
