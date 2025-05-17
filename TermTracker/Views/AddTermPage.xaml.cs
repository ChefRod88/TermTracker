using TermTracker.ViewModels;

namespace TermTracker.Views;

public partial class AddTermPage : ContentPage
{
    public AddTermPage()
    {
        InitializeComponent();
        BindingContext = new AddTermViewModel();
    }
}
