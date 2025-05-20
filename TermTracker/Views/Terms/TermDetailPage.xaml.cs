using TermTracker.Models.TermTrackerCore;
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

    private async void OnCourseSelected(object sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine("Course card tapped.");

        if (e.CurrentSelection.FirstOrDefault() is Course selectedCourse)
        {
            Console.WriteLine($"Selected course: {selectedCourse.Title}");

            await Shell.Current.GoToAsync(nameof(EditCoursePage), true, new Dictionary<string, object>
        {
            { "SelectedCourse", selectedCourse }
        });

            ((CollectionView)sender).SelectedItem = null;
        }
    }



}