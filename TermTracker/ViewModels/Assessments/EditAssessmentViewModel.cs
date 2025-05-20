using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models.TermTrackerCore;
using TermTracker.Services;


namespace TermTracker.ViewModels.Assessments
{
    public class EditAssessmentViewModel : BaseViewModel
    {
        private Assessment _assessment;

        public string Title { get; set; }
        public string SelectedType { get; set; }
        public DateTime DueDate { get; set; }
        public bool HasNotification { get; set; }

        public ObservableCollection<string> TypeOptions { get; } = new()
        {
            "Objective", "Performance"
        };

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public EditAssessmentViewModel(Assessment assessment)
        {
            _assessment = assessment;

            Title = assessment.Title;
            SelectedType = assessment.Type;
            DueDate = assessment.DueDate;
            HasNotification = assessment.HasNotification;

            UpdateCommand = new Command(async () =>
            {
                _assessment.Title = Title;
                _assessment.Type = SelectedType;
                _assessment.DueDate = DueDate;
                _assessment.HasNotification = HasNotification;

                var db = await DatabaseService.GetConnection();
                await db.UpdateAsync(_assessment);
                await Shell.Current.GoToAsync("..");
            });

            DeleteCommand = new Command(async () =>
            {
                bool confirm = await Shell.Current.DisplayAlert("Confirm Delete", "Delete this assessment?", "Yes", "No");
                if (!confirm) return;

                var db = await DatabaseService.GetConnection();
                await db.DeleteAsync(_assessment);
                await Shell.Current.GoToAsync("..");
            });
        }
    }
}
