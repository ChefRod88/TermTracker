using TermTracker.Models.TermTrackerCore;
using TermTracker.ViewModels;

namespace TermTracker.Views;

/// <summary>
/// Page for editing an existing assessment.
/// </summary>
[QueryProperty(nameof(SelectedAssessment), "SelectedAssessment")]
public partial class EditAssessmentPage : ContentPage
{
    private Assessment _selectedAssessment;

    /// <summary>
    /// Assessment selected from the list.
    /// </summary>
    public Assessment SelectedAssessment
    {
        get => _selectedAssessment;
        set
        {
            _selectedAssessment = value;
            BindingContext = new EditAssessmentViewModel(_selectedAssessment);
        }
    }

    /// <summary>
    /// Initializes the page.
    /// </summary>
    public EditAssessmentPage()
    {
        InitializeComponent();
    }
}
