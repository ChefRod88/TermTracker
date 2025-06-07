using TermTracker.Models.TermTrackerCore;
using TermTracker.ViewModels;

namespace TermTracker.Views;

/// <summary>
/// Page that lists all assessments for a course.
/// </summary>
[QueryProperty(nameof(SelectedCourse), "SelectedCourse")]
public partial class AssessmentListPage : ContentPage
{
    private Course _selectedCourse;

    /// <summary>
    /// Course whose assessments are displayed.
    /// </summary>
    public Course SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            BindingContext = new AssessmentListViewModel(_selectedCourse);
        }
    }

    /// <summary>
    /// Initializes the page.
    /// </summary>
    public AssessmentListPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Navigates to the edit page when an assessment is selected.
    /// </summary>
    private async void OnAssessmentSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Assessment selected)
        {
            await Shell.Current.GoToAsync(nameof(EditAssessmentPage), true, new Dictionary<string, object>
        {
            { "SelectedAssessment", selected }
        });

            ((CollectionView)sender).SelectedItem = null;
        }
    }

}

