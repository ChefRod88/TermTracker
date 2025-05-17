using TermTracker.Models;
using TermTracker.ViewModels;

namespace TermTracker.Views;

[QueryProperty(nameof(SelectedAssessment), "SelectedAssessment")]
public partial class EditAssessmentPage : ContentPage
{
    private Assessment _selectedAssessment;

    public Assessment SelectedAssessment
    {
        get => _selectedAssessment;
        set
        {
            _selectedAssessment = value;
            BindingContext = new EditAssessmentViewModel(_selectedAssessment);
        }
    }

    public EditAssessmentPage()
    {
        InitializeComponent();
    }
}
