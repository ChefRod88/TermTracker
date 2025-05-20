using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TermTracker.Models.StudentLounge;

namespace TermTracker.ViewModels.StudentLounge
{
    public class ForumViewModel : BaseViewModel
    {
        public ObservableCollection<ForumPost> ForumPosts { get; set; } = new();
        public string NewPostContent { get; set; }

        public ICommand PostCommand { get; }

        public ForumViewModel()
        {
            PostCommand = new Command(Post);
            LoadPosts();
        }

        private void LoadPosts()
        {
            // Dummy data for now
            ForumPosts.Add(new ForumPost
            {
                Author = "Rodney C.",
                Content = "Hey, anyone working on Assessment 2?",
                Timestamp = DateTime.Now,
                Tag = "#Assessment"
            });
        }

        private void Post()
        {
            if (string.IsNullOrWhiteSpace(NewPostContent))
                return;

            ForumPosts.Insert(0, new ForumPost
            {
                Author = "You",
                Content = NewPostContent,
                Timestamp = DateTime.Now,
                Tag = "#General"
            });

            NewPostContent = string.Empty;
            OnPropertyChanged(nameof(NewPostContent));
        }
    }

}
