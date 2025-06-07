using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TermTracker.Services;     // ✅ Fixes DatabaseService not found
using TermTracker.Views;
using TermTracker.ViewModels;
using TermTracker.Models.TermTrackerCore;






namespace TermTracker.ViewModels
{
    /// <summary>
    /// View model for the dashboard screen.  Displays the list of
    /// available terms and handles navigation to other pages.
    /// </summary>
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<Term> Terms { get; set; } = new();

        private Term _activeTerm;
        public Term ActiveTerm
        {
            get => _activeTerm;
            set
            {
                _activeTerm = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes the view model and loads initial term data.
        /// </summary>
        public DashboardViewModel()
        {
            LoadData();
        }

        /// <summary>
        /// Loads all terms from the SQLite database into the observable
        /// collection. The most recent term is set as the active term.
        /// </summary>
        public async void LoadData()
        {
            var db = await DatabaseService.GetConnection();
            var terms = await db.Table<Term>().ToListAsync();

            Terms.Clear();
            foreach (var term in terms)
                Terms.Add(term);

            // For now, show the most recent one
            ActiveTerm = terms.LastOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand ViewCoursesCommand => new Command(async () =>
        {
            if (ActiveTerm != null)
            {
                await Shell.Current.GoToAsync(nameof(TermDetailPage), true,
                    new Dictionary<string, object> { { "SelectedTerm", ActiveTerm } });
            }
        });

        /// <summary>
        /// Navigates to the page for adding a new term.
        /// </summary>
        public ICommand AddTermCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(AddTermPage));
        });
    

    }

}
