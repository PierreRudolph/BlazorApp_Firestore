using BlazorApp_Firestore.Entities;
using BlazorApp_Firestore.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace BlazorApp_Firestore.Dialogs
{
    public partial class AddCustomerDialog
    {
        [Inject]
        public ICustomerService CustomerService { get; set; } = null!;

        private Customer _customer = new();
        private EditContext editContext;
        EditForm _editForm;
        [Parameter]
        public EventCallback<Customer> OnCustomerAdded { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(_customer);
        }



        private async Task HandleValidSubmit()
        {
            await OnCustomerAdded.InvokeAsync(_customer);
            _customer = new Customer();
            editContext = new EditContext(_customer);
        }
    }

}
