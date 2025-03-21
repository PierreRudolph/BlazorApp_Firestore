using BlazorApp_Firestore.Entities;
using BlazorApp_Firestore.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp_Firestore.Pages;

public partial class UsersOverview
{
    [Inject]
    public ICustomerService CustomerService { get; set; } = null!;

    string _userNameInput = "";
    string _userEmailInput = "";
    bool _showDialog = false;
    List<Dictionary<string, string>> list = [];

    Customer _customer = new();

    private async Task AddUser()
    {
        if (_userNameInput == null || _userNameInput == null) return;
        await CustomerService.AddUser(_customer);
    }

    private async Task GetUsers()
    {
        list = await CustomerService.GetUsers();
    }
}

