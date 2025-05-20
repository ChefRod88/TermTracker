using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models.TermTrackerCore;
using TermTracker.Services;


namespace TermTracker.ViewModels.Assessments
{
    public class AddAssessmentViewModel : BaseViewModel
    {
        private Course _course;

        public string Title { get; set; }
        public string SelectedType { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Today;
        public bool HasNotification { get; set; }

        public ObservableCollection<string> TypeOptions { get; } = new()
        {
            "Objective", "Performance"
        };

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddAssessmentViewModel(Course course)
        {
            _course = course;

            SaveCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(SelectedType))
                {
                    await Shell.Current.DisplayAlert("Error", "Title and Type are required.", "OK");
                    return;
                }

                var db = await DatabaseService.GetConnection();
                var assessment = new Assessment
                {
                    CourseId = _course.Id,
                    Title = Title,
                    Type = SelectedType,
                    DueDate = DueDate,
                    HasNotification = HasNotification
                };

                await db.InsertAsync(assessment);
                await Shell.Current.GoToAsync("..");
            });

            CancelCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("..");
            });


        }
       

    }
}
