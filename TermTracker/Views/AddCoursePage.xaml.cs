using TermTracker.Models;
using TermTracker.ViewModels;

namespace TermTracker.Views
{
    [QueryProperty(nameof(SelectedTerm), "SelectedTerm")]
    public partial class AddCoursePage : ContentPage
    {
        private Term _selectedTerm;

        public Term SelectedTerm
        {
            get => _selectedTerm;
            set
            {
                _selectedTerm = value;
                BindingContext = new AddCourseViewModel(_selectedTerm);
            }
        }

        public AddCoursePage()
        {
            InitializeComponent();
        }
    }
}
