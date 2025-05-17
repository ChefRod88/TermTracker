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

