using System.Net.Http;
using System.Net.Http.Json;
using TicketSystem.Desktop.Models;

namespace TicketSystem.Desktop.Services
{
    public static class ApiService
    {
        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5123/swagger/index.html")
            //BaseAddress = new Uri("https://localhost:5001/")
        };

        public static async Task<User> Login(string u, string p)
        {
            var res = await client.PostAsJsonAsync("auth/login", new { Username = u, Password = p });
            return await res.Content.ReadFromJsonAsync<User>();
        }

        public static async Task<List<Ticket>> GetTickets(User user)
        {
            return await client.GetFromJsonAsync<List<Ticket>>($"tickets?userId={user.Id}&role={user.Role}");
        }

        public static async Task CreateTicket(object ticket)
        {
            await client.PostAsJsonAsync("tickets", ticket);
        }

        public static async Task<List<TicketHistory>> GetHistory(int id)
        {
            return await client.GetFromJsonAsync<List<TicketHistory>>($"tickets/history/{id}");
        }

        public static async Task UpdateTicket(object data)
        {
            await client.PostAsJsonAsync("tickets/update", data);
        }
    }
}
