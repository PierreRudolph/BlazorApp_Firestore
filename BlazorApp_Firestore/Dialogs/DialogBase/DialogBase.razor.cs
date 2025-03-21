using Microsoft.AspNetCore.Components;

namespace BlazorApp_Firestore.Dialogs.DialogBase;
public partial class DialogBase
{
    private bool _showDialog;
    private RenderFragment? ChildContent;

    private void CloseDialog()
    {
        _showDialog = false;
    }
}
