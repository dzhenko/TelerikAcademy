namespace StudentsSystem.Client
{
    using StudentsSystem.Models;
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
                BaseAddress = new Uri("http://localhost:37524/")
            };

            GetAllStudents(client);

            PostStudent(client);

            UpdateStudent(client);

            DeleteStudent(client);
        }

        private static void PostStudent(HttpClient client)
        {
            Console.WriteLine("Creating student");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("FirstName", "Gosho"),
                new KeyValuePair<string, string>("LastName", "TheNewCommer"),
                new KeyValuePair<string, string>("Level", "99"),
                new KeyValuePair<string, string>("StudentIdentification", "11111"),
                new KeyValuePair<string, string>("Address", "posted address"),
                new KeyValuePair<string, string>("Email", "posted email"),
            });

            HttpResponseMessage response = client.PostAsync("api/Students/Post", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllStudents(HttpClient client)
        {
            Console.WriteLine("All students");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Students/get").Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(students);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateStudent(HttpClient client)
        {
            Console.WriteLine("Updating student");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("FirstName", "The new Gosho"),
                new KeyValuePair<string, string>("LastName", "TheNewCommer"),
                new KeyValuePair<string, string>("Level", "99"),
                new KeyValuePair<string, string>("StudentIdentification", "11111"),
                new KeyValuePair<string, string>("Address", "posted address"),
                new KeyValuePair<string, string>("Email", "posted email"),
            });

            HttpResponseMessage response = client.PutAsync("api/Students/Put/1", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void DeleteStudent(HttpClient client)
        {
            Console.WriteLine("Deleting student");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Students/Delete/1").Result;

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
