using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace TestXam.ViewModels
{
    using Entities;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainPageDetailViewModel : BaseViewModel
    {
        private ObservableCollection<GetPostResult> posts;
        private ObservableCollection<GetPostResult> toShow;
        public ObservableCollection<GetPostResult> ToShow
        {
            get => toShow;
            set
            {
                toShow = value;
                OnPropertyChanged();
            }
        }
        public ICommand FillPostsCommand { get; private set; }
        public ICommand FilterByUserIdCommand { get; private set; }
        private void FilterByUserId(int UserId)
        {
            StartProcess();
            ToShow = new ObservableCollection<GetPostResult>(posts?.Where(x => x.UserId == UserId));
            EndProcess();
        }
        private async Task FillPostsAsync()
        {
            using (var caller = new ApiCaller())
            {
                StartProcess();
                var posts = await caller.GetPosts("https://jsonplaceholder.typicode.com/posts");
                ToShow = new ObservableCollection<GetPostResult>(posts);
                EndProcess();
            }
        }
        public MainPageDetailViewModel()
        {
            FillPostsCommand = new Command(async () => { await FillPostsAsync(); });
            FilterByUserIdCommand = new Command((UserId) => { FilterByUserId((int)UserId); });
        }
    }
}
