
using BlazorApp_Firestore.Entities;
using System.Text.Json.Nodes;

namespace BlazorApp_Firestore.Services
{
    public interface ICustomerService
    {
        Task AddUser(Customer customer);

        Task<List<Dictionary<string, string>>> GetUsers();
    }
}
