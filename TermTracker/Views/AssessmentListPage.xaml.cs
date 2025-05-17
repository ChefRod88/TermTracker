using TermTracker.Models;
using TermTracker.ViewModels;

namespace TermTracker.Views;

[QueryProperty(nameof(SelectedCourse), "SelectedCourse")]
public partial class AssessmentListPage : ContentPage
{
    private Course _selectedCourse;

    public Course SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            _selectedCourse = value;
            BindingContext = new AssessmentListViewModel(_selectedCourse);
        }
    }

    public AssessmentListPage()
    {
        InitializeComponent();
    }
}

