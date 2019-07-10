using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXam.Views
{
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        private PostDetailViewModel ViewModel;
        public PostDetailPage(PostDetailViewModel ViewModel)
        {
            this.ViewModel = ViewModel;
            InitializeComponent();
            BindingContext = this.ViewModel;
        }
    }
}