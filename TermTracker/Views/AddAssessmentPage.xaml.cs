using TermTracker.Models;
using TermTracker.ViewModels;

namespace TermTracker.Views;

[QueryProperty(nameof(SelectedCourse), "SelectedCourse")]
public partial class AddAssessmentPage : ContentPage
{
    private Course _selectedCourse;

    public Course SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            BindingContext = new AddAssessmentViewModel(_selectedCourse);
        }
    }

    public AddAssessmentPage()
    {
        InitializeComponent();
    }
}
