using System;
using System.Windows.Input;
using TermTracker.Models;
using TermTracker.Services;


namespace TermTracker.ViewModels.Terms
{
    /// <summary>
    /// View model for the <see cref="AddTermPage"/> allowing users to create
    /// a new term.
    /// </summary>
    public class AddTermViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(180); // 6 months

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Initializes commands used by the Add Term page.
        /// </summary>
        public AddTermViewModel()
        {
            SaveCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    await Shell.Current.DisplayAlert("Error", "Please enter a term title.", "OK");
                    return;
                }

                var newTerm = new Term
                {
                    Title = Title,
                    StartDate = StartDate,
                    EndDate = EndDate
                };

                var db = await DatabaseService.GetConnection();
                await db.InsertAsync(newTerm);
                await Shell.Current.GoToAsync("..");
            });

            CancelCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("..");
            });
        }
       

    }
}
