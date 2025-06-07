using TermTracker.Models.TermTrackerCore;
using TermTracker.ViewModels;

namespace TermTracker.Views
{
    /// <summary>
    /// Page for entering details of a new course.
    /// </summary>
    [QueryProperty(nameof(SelectedTerm), "SelectedTerm")]
    public partial class AddCoursePage : ContentPage
    {
        private Term _selectedTerm;

        /// <summary>
        /// The term selected in the previous page used to associate the new
        /// course.
        /// </summary>
        public Term SelectedTerm
        {
            get => _selectedTerm;
            set
            {
                _selectedTerm = value;
                BindingContext = new AddCourseViewModel(_selectedTerm);
            }
        }

        /// <summary>
        /// Initializes the page components.
        /// </summary>
        public AddCoursePage()
        {
            InitializeComponent();
        }
    }
}
