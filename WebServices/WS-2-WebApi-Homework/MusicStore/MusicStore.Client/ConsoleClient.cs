namespace MusicStore.Client
{
    using MusicStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class ConsoleClient
    {
        public static void Main()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:31237/")
            };

            GetAllAlbums(client);

            PostAlbum(client);

            UpdateAlbum(client);

            DeleteAlbum(client);
        }

        private static void PostAlbum(HttpClient client)
        {
            Console.WriteLine("Creating album");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Title", "Best of best"),
                new KeyValuePair<string, string>("Year", "1999"),
                new KeyValuePair<string, string>("Producer", "Bay Milko")
            });

            HttpResponseMessage response = client.PostAsync("api/Albums/Post", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Created");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllAlbums(HttpClient client)
        {
            Console.WriteLine("All albums");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Albums/get").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(albums);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateAlbum(HttpClient client)
        {
            Console.WriteLine("Updating album");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Title", "Best of best of best updated!"),
                new KeyValuePair<string, string>("Year", "1999"),
                new KeyValuePair<string, string>("Producer", "Bay Milko")
            });

            HttpResponseMessage response = client.PutAsync("api/Albums/Put/1", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void DeleteAlbum(HttpClient client)
        {
            Console.WriteLine("Deleting album");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Albums/Delete/1").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
