using TermTracker.ViewModels;

namespace TermTracker.Views;

/// <summary>
/// Page for creating a new academic term.
/// </summary>
public partial class AddTermPage : ContentPage
{
    /// <summary>
    /// Initializes the page and assigns its view model.
    /// </summary>
    public AddTermPage()
    {
        InitializeComponent();
        BindingContext = new AddTermViewModel();
    }
}
