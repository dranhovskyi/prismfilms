using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrismFilms.Views;

namespace PrismFilms.RestClient
{
    public class RestClient<T>
    {
        public async Task<List<T>> GetAsync(string uri)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    var json = await httpClient.GetStringAsync(uri);
            //    return JsonConvert.DeserializeObject<List<T>>(json);
            //}

            //Simulate downloading films from the GET request
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MoviesPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("PrismFilms.movies.json");
            await Task.Delay(1000);
            string json = "";
            using (var reader = new StreamReader(stream))
            {
                json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
