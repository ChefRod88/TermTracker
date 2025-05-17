using Microsoft.Maui.Controls;
using TermTracker.ViewModels;



namespace TermTracker.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardViewModel();
    }
}