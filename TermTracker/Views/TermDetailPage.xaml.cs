using TermTracker.Models;
using TermTracker.ViewModels;

namespace TermTracker.Views;

[QueryProperty(nameof(SelectedTerm), "SelectedTerm")]
public partial class TermDetailPage : ContentPage
{
    private Term _selectedTerm;
    public Term SelectedTerm
    {
        get => _selectedTerm;
        set
        {
            _selectedTerm = value;
            BindingContext = new TermDetailViewModel(_selectedTerm);
        }
    }

    public TermDetailPage()
    {
        InitializeComponent();
    }
}