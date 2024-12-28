using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vkusnyashka1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void OnHamburgerTapped(object sender, EventArgs e)
        {
            Overlay.IsVisible = true;
            await Overlay.FadeTo(0.4, 200, Easing.Linear);
            await SideMenu.TranslateTo(0, 0, 250, Easing.Linear);
        }

        private async void CloseMenu(object sender, EventArgs e)
        {
            await SideMenu.TranslateTo(-250, 0, 250, Easing.Linear);
            await Overlay.FadeTo(0, 200, Easing.Linear);
            Overlay.IsVisible = false;
        }

        private async void OnOrderInfoTapped(object sender, EventArgs e)
        {
            // Закрытие меню перед навигацией (если нужно)
            await SideMenu.TranslateTo(-250, 0, 250, Easing.Linear);
            await Overlay.FadeTo(0, 200, Easing.Linear);
            Overlay.IsVisible = false;

            // Логика навигации
            // await Navigation.PushAsync(new OrderInfoPage());
        }
        private async void OnMainMenuTapped(object sender, EventArgs e)
        {
            // Закрываем боковое меню
            await SideMenu.TranslateTo(-250, 0, 250, Easing.Linear);
            await Overlay.FadeTo(0, 200, Easing.Linear);
            Overlay.IsVisible = false;

            // Переходим на главную страницу
            await Navigation.PopToRootAsync();
        }

    }
}
