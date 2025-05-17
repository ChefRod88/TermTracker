using TermTracker.Models;
using TermTracker.ViewModels;

namespace TermTracker.Views
{
    [QueryProperty(nameof(SelectedCourse), "SelectedCourse")]
    public partial class EditCoursePage : ContentPage
    {
        public Course SelectedCourse
        {
            get => (Course)BindingContext;
            set
            {
                if (value != null)
                    BindingContext = new EditCourseViewModel(value);
            }
        }

        public EditCoursePage()
        {
            InitializeComponent();
        }
    }
}
