using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amiibopedia.ViewModel;
using Xamarin.Forms;

namespace amiibopedia
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel viewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewModel = new MainPageViewModel();
            await viewModel.LoadCharacters();
            this.BindingContext = viewModel;
        }

        async void Handle_Appearing(object sender, System.EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.TranslationX = -100;
            view.Opacity = 0;

            await Task.WhenAny<bool>
                (
                    view.TranslateTo(0, 0, 250, Easing.SinIn),
                    view.FadeTo(1, 500, Easing.BounceIn)
                );
        }
    }
}
