using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TermTracker.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand GoBackCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("//DashboardPage"); // Absolute route from the Shell root
        });

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
