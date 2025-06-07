using TermTracker.Models.TermTrackerCore;
using TermTracker.ViewModels;

namespace TermTracker.Views;

/// <summary>
/// Displays courses for a selected term and allows navigation to
/// course-related pages.
/// </summary>
[QueryProperty(nameof(SelectedTerm), "SelectedTerm")]
public partial class TermDetailPage : ContentPage
{
    private Term _selectedTerm;

    /// <summary>
    /// The term supplied via query parameters when navigating to this page.
    /// Setting this property loads a new <see cref="TermDetailViewModel"/>.
    /// </summary>
    public Term SelectedTerm
    {
        get => _selectedTerm;
        set
        {
            _selectedTerm = value;
            BindingContext = new TermDetailViewModel(_selectedTerm);
        }
    }

    /// <summary>
    /// Default constructor required for routing.
    /// </summary>
    public TermDetailPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Navigates to the edit course page when a course is selected from
    /// the list.
    /// </summary>
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
