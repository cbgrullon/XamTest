using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
namespace TestXam.ViewModels
{
    using Entities;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainPageViewModel:BaseViewModel
    {
        private ObservableCollection<long> menu;
        private async Task FillMenuItems()
        {
            StartProcess();
            using(var api = new ApiCaller())
            {
                var result = await api.GetPosts("https://jsonplaceholder.typicode.com/posts");
                Menu = new ObservableCollection<long>((from r in result select r.UserId).Distinct());
            }
            EndProcess();
        }
        public ObservableCollection<long> Menu
        {
            get => menu;
            set
            {
                menu = value;
                OnPropertyChanged();
            }
        }
        public ICommand FillMenuCommand;
        public MainPageViewModel()
        {
            FillMenuCommand = new Command(async () => { await FillMenuItems(); });
        }
    }
}
