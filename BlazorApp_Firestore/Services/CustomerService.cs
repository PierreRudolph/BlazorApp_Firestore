using BlazorApp_Firestore.Entities;
using Microsoft.JSInterop;
using System.Text.Json.Nodes;
namespace BlazorApp_Firestore.Services;

public class CustomerService(IJSRuntime JS) : ICustomerService
{

    public async Task AddUser(Customer customer)
    {
        JsonObject user = new();
        user.Add("LastName", customer.LastName);
        user.Add("FirstName", customer.FirstName);
        user.Add("Email", customer.Email);
        user.Add("Phone", customer.Phone);
        await JS.InvokeVoidAsync("addCustomer", user);
    }

    public async Task<List<Dictionary<string, string>>> GetUsers()
    {
        var users = await JS.InvokeAsync<List<Dictionary<string, string>>>("getUsers");
        return users;
    }
}

