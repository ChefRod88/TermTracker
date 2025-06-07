using TermTracker.Models.TermTrackerCore;
using TermTracker.ViewModels;

namespace TermTracker.Views;

/// <summary>
/// Page for creating a new assessment for a course.
/// </summary>
[QueryProperty(nameof(SelectedCourse), "SelectedCourse")]
public partial class AddAssessmentPage : ContentPage
{
    private Course _selectedCourse;

    /// <summary>
    /// Course that the new assessment will belong to.
    /// </summary>
    public Course SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            BindingContext = new AddAssessmentViewModel(_selectedCourse);
        }
    }

    /// <summary>
    /// Initializes the page.
    /// </summary>
    public AddAssessmentPage()
    {
        InitializeComponent();
    }
}
