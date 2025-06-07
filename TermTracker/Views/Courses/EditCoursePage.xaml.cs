using TermTracker.Models.TermTrackerCore;
using TermTracker.ViewModels;

namespace TermTracker.Views
{
    /// <summary>
    /// Page for editing an existing course.
    /// </summary>
    [QueryProperty(nameof(SelectedCourse), "SelectedCourse")]
    public partial class EditCoursePage : ContentPage
    {
        /// <summary>
        /// Course selected from the previous page. Setting this property
        /// updates the binding context with a new view model.
        /// </summary>
        public Course SelectedCourse
        {
            get => (Course)BindingContext;
            set
            {
                if (value != null)
                    BindingContext = new EditCourseViewModel(value);
            }
        }

        /// <summary>
        /// Initializes the page.
        /// </summary>
        public EditCoursePage()
        {
            InitializeComponent();
        }
    }
}
