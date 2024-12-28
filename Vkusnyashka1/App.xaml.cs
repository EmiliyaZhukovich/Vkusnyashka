using Xamarin.Forms;
using Vkusnyashka1.Pages; // Убедитесь, что пространство имен соответствует вашему проекту

namespace Vkusnyashka1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Устанавливаем MainPage внутри NavigationPage для поддержки навигации
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Обработка при запуске приложения
        }

        protected override void OnSleep()
        {
            // Обработка при переходе приложения в спящий режим
        }

        protected override void OnResume()
        {
            // Обработка при возобновлении приложения
        }
    }
}
