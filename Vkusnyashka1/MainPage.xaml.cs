using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vkusnyashka1.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnHamburgerTapped(object sender, EventArgs e)
        {
            // Логика открытия бокового меню
            Overlay.IsVisible = true;
            await Overlay.FadeTo(0.4, 200, Easing.Linear);
            await SideMenu.TranslateTo(0, 0, 250, Easing.Linear);
        }

        private async void CloseMenu(object sender, EventArgs e)
        {
            // Логика закрытия бокового меню
            await SideMenu.TranslateTo(-250, 0, 250, Easing.Linear);
            await Overlay.FadeTo(0, 200, Easing.Linear);
            Overlay.IsVisible = false;
        }

        private async void OnOrderButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage());
        }
        // Обработчик нажатия на "Информация о заказе" в меню
        private async void OnCartPageTapped(object sender, EventArgs e)
        {
            // Навигация к странице CartPage
            await Navigation.PushAsync(new CartPage());
        }


        private async void OnAboutTapped(object sender, EventArgs e)
        {
            // Закрываем меню перед навигацией (опционально)
            await SideMenu.TranslateTo(-250, 0, 250, Easing.Linear);
            await Overlay.FadeTo(0, 200, Easing.Linear);
            Overlay.IsVisible = false;

            // Переход на страницу "О НАС"
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
