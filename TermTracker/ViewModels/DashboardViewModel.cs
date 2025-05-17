using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TermTracker.Models;       // ✅ Fixes Term not found
using TermTracker.Services;     // ✅ Fixes DatabaseService not found




namespace TermTracker.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
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

        public DashboardViewModel()
        {
            LoadData();
        }

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
    }
}
