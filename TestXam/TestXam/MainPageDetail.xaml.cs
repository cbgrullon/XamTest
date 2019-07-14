using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXam
{
    using ViewModels;
    using Views;
    using Entities;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        private MainPageDetailViewModel viewModel = new MainPageDetailViewModel();
        public MainPageDetail()
        {
            InitializeComponent();
            BindingContext = viewModel;
            posts.ItemTapped += Posts_ItemTapped;
            viewModel?.FillPostsCommand?.Execute(null);
            posts.RefreshCommand = viewModel.FillPostsCommand;
        }

        private void Posts_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            if (sender is ListView lv) lv.SelectedItem = null;
            var vmTo = new PostDetailViewModel(e.Item);
            var page = new PostDetailPage(vmTo);
            Navigation.PushAsync(page);
        }
    }
}