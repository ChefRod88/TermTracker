using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TermTracker.ViewModels.StudentLounge
{
    public class ChatRoomViewModel : BaseViewModel
    {
        private HubConnection _hubConnection;
        public ObservableCollection<ChatMessage> Messages { get; set; } = new();
        public string NewMessage { get; set; }

        public ICommand SendMessageCommand { get; }

        public ChatRoomViewModel()
        {
            SendMessageCommand = new Command(async () => await SendMessage());

            ConnectToChat();
        }

        private async void ConnectToChat()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://your-api-url.com/chathub")  // Replace with your actual hosted SignalR Hub
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Messages.Add(new ChatMessage
                    {
                        Sender = user,
                        Message = message,
                        Timestamp = DateTime.Now
                    });
                });
            });

            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Could not connect to chat: {ex.Message}");
            }
        }

        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(NewMessage))
                return;

            await _hubConnection.InvokeAsync("SendMessage", "Rodney", NewMessage); // Replace "Rodney" with dynamic user
            NewMessage = string.Empty;
            OnPropertyChanged(nameof(NewMessage));
        }
    }

}
