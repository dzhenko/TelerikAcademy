namespace TicTacToe.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class ConsoleClient
    {
        static string token = string.Empty;

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("1 - Sign up");
                Console.WriteLine("2 - Login");
                Console.WriteLine("3 - Create game");
                Console.WriteLine("4 - Join game");
                Console.WriteLine("5 - Exit");

                var choice = Console.ReadLine();

                while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("1 - Sign up");
                    Console.WriteLine("2 - Login");
                    Console.WriteLine("3 - Create game");
                    Console.WriteLine("4 - Join game");
                    choice = Console.ReadLine();
                }

                switch (choice)
                {
                    case "1": SignUp(); break;
                    case "2": LogIn(); break;
                    case "3": CreateGame(); break;
                    case "4": JoinGame(); break;
                    case "5": Console.WriteLine("Bye"); return;
                    default: break;
                }
            }
        }

        private static void JoinGame()
        {
            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:33257/") };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsync("api/Games/Join", null).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Joined!");

                PlayGame(response.Content.ReadAsStringAsync().Result.Trim(new char[] {'"'}), false);
            }
            else
            {
                Console.WriteLine("No games found!");
            }

            return;
        }

        private static void CreateGame()
        {
            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:33257/") };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = client.PostAsync("api/Games/Create", null).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Created!");

                PlayGame(response.Content.ReadAsStringAsync().Result.Trim(new char[] {'"'}), true);
            }
            else
            {
                Console.WriteLine("Error!");
            }

            return;
        }

        private static void PlayGame(string id, bool ownGame)
        {
            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:33257/") };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var statusResult = client.GetAsync(string.Format("api/Games/Status/{0}", id)).Result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(statusResult);

            var board = statusResult.Substring(statusResult.IndexOf("Board") + 8, 9);
            var status = statusResult[statusResult.Length - 2];

            while (true)
            {
                Console.WriteLine("Waiting for other players");
                while (status != (ownGame ? '1' : '2'))
                {
                    statusResult = client.GetAsync(string.Format("api/Games/Status/{0}", id)).Result.Content.ReadAsStringAsync().Result;
                    status = statusResult[statusResult.Length - 2];
                    board = statusResult.Substring(statusResult.IndexOf("Board") + 8, 9);
                }

                var move = GetCommand(board);

                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> 
                {
                    new KeyValuePair<string, string>("GameId", id),
                    new KeyValuePair<string, string>("Row", move[0].ToString()),
                    new KeyValuePair<string, string>("Col", move[1].ToString()),
                });

                var res = client.PostAsync("api/Games/Play", content).Result;

                statusResult = client.GetAsync(string.Format("api/Games/Status/{0}", id)).Result.Content.ReadAsStringAsync().Result;
                status = statusResult[statusResult.Length - 2];
                board = statusResult.Substring(statusResult.IndexOf("Board") + 8, 9);

                if (status == '5')
                {
                    Console.WriteLine("Draw!");
                    return;
                }

                if (status == '3')
                {
                    Console.WriteLine("Won By X!");
                    return;
                }

                if (status == '4')
                {
                    Console.WriteLine("Won By O!");
                    return;
                }
            }
        }

        private static void LogIn()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password :");
            var password = Console.ReadLine();

            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:33257/") };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> 
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("Username", username),
                new KeyValuePair<string, string>("Password", password),
            });

            var response = client.PostAsync("Token", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Success!");
                var all = response.Content.ReadAsStringAsync().Result;
                token = all.Substring(all.IndexOf(":\"") + 2, all.IndexOf("\",") - all.IndexOf(":\"") - 2);
            }
            else
            {
                Console.WriteLine("Error!");
            }

            return;
        }

        private static void SignUp()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password :");
            var password = Console.ReadLine();

            var client = new HttpClient() { BaseAddress = new Uri("http://localhost:33257/") };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> 
            {
                new KeyValuePair<string, string>("Email", username),
                new KeyValuePair<string, string>("Password", password),
                new KeyValuePair<string, string>("ConfirmPassword", password),
            });

            var response = client.PostAsync("api/Account/Register", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error!");
            }
            return;
        }

        private static string GetCommand(string board)
        {
            Console.WriteLine(" 1 2 3");
            Console.WriteLine("1" + board[0] + board[1] + board[2]);
            Console.WriteLine("2" + board[3] + board[4] + board[5]);
            Console.WriteLine("3" + board[6] + board[7] + board[8]);
            Console.WriteLine();
            Console.Write("Your move (Format is RC - Row Col) : ");
            var move = Console.ReadLine();

            while (move != "11" && move != "12" && move != "13" && 
                move != "21" && move != "22" && move != "23" && 
                move != "31" && move != "32" && move != "33" &&
                board[(3 * (int.Parse(move[0].ToString()) -1 )) + int.Parse(move[1].ToString()) - 1] != '-')
            {
                Console.WriteLine("Invalid move");
                Console.Write("Your move (Format is RC - Row Col - Free position From 1 to 3) : ");
                move = Console.ReadLine();
            }

            return move;
        }
    }
}
