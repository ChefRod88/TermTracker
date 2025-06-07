using Microsoft.Maui.Controls;
using TermTracker.ViewModels;



namespace TermTracker.Views;

/// <summary>
/// Main dashboard showing all terms.
/// </summary>
public partial class DashboardPage : ContentPage
{
        /// <summary>
        /// Initializes the dashboard page and sets its binding context.
        /// </summary>
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }
}
