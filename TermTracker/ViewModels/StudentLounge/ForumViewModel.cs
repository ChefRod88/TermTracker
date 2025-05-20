using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models.StudentLounge;
using TermTracker.Services;

namespace TermTracker.ViewModels.StudentLounge
{
    public class ForumViewModel : BaseViewModel
    {
        private readonly ForumService _forumService;

        public ObservableCollection<ForumPost> ForumPosts { get; set; } = new();
        public string NewPostContent { get; set; }

        public ICommand PostCommand { get; }

        public ForumViewModel(ForumService service)
        {
            _forumService = service;
            PostCommand = new Command(async () => await CreatePost());
            LoadPosts();
        }

        private async void LoadPosts()
        {
            var posts = await _forumService.GetPostsAsync();
            ForumPosts.Clear();
            foreach (var post in posts)
                ForumPosts.Add(post);
        }

        private async Task CreatePost()
        {
            if (string.IsNullOrWhiteSpace(NewPostContent))
                return;

            var post = new ForumPost
            {
                Author = "Rodney C.", // Replace later with logged-in user
                Content = NewPostContent,
                Timestamp = DateTime.UtcNow,
                Tag = "#General"
            };

            if (await _forumService.CreatePostAsync(post))
            {
                ForumPosts.Insert(0, post);
                NewPostContent = string.Empty;
                OnPropertyChanged(nameof(NewPostContent));
            }
        }
    }
}
