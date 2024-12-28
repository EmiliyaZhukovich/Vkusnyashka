using System;
using Xamarin.Forms;

namespace Vkusnyashka1.Pages
{
    public partial class OrderPage : ContentPage
    {
        // Цены товаров
        private readonly decimal PriceCakes = 100m;
        private readonly decimal PriceTorts = 200m;
        private readonly decimal PriceMacarons = 50m;
        private readonly decimal PriceZefir = 40m;
        private readonly decimal PriceEclairs = 60m;
        private readonly decimal PriceCroissants = 70m;

        // Количества товаров
        private int QuantityCakes = 0;
        private int QuantityTorts = 0;
        private int QuantityMacarons = 0;
        private int QuantityZefir = 0;
        private int QuantityEclairs = 0;
        private int QuantityCroissants = 0;

        // Общая сумма
        private decimal Total = 0m;

        public OrderPage()
        {
            InitializeComponent();
            UpdateTotal();
        }

        // Обработчики нажатия на кнопки "+" и "-" для каждого товара

        // Кексы
        private void OnIncreaseCakesQuantity(object sender, EventArgs e)
        {
            QuantityCakes++;
            CakesQuantityLabel.Text = QuantityCakes.ToString();
            UpdateTotal();
        }

        private void OnDecreaseCakesQuantity(object sender, EventArgs e)
        {
            if (QuantityCakes > 0)
            {
                QuantityCakes--;
                CakesQuantityLabel.Text = QuantityCakes.ToString();
                UpdateTotal();
            }
        }

        // Торты
        private void OnIncreaseTortsQuantity(object sender, EventArgs e)
        {
            QuantityTorts++;
            TortsQuantityLabel.Text = QuantityTorts.ToString();
            UpdateTotal();
        }

        private void OnDecreaseTortsQuantity(object sender, EventArgs e)
        {
            if (QuantityTorts > 0)
            {
                QuantityTorts--;
                TortsQuantityLabel.Text = QuantityTorts.ToString();
                UpdateTotal();
            }
        }

        // Макарони
        private void OnIncreaseMacaronsQuantity(object sender, EventArgs e)
        {
            QuantityMacarons++;
            MacaronsQuantityLabel.Text = QuantityMacarons.ToString();
            UpdateTotal();
        }

        private void OnDecreaseMacaronsQuantity(object sender, EventArgs e)
        {
            if (QuantityMacarons > 0)
            {
                QuantityMacarons--;
                MacaronsQuantityLabel.Text = QuantityMacarons.ToString();
                UpdateTotal();
            }
        }

        // Зефир
        private void OnIncreaseZefirQuantity(object sender, EventArgs e)
        {
            QuantityZefir++;
            ZefirQuantityLabel.Text = QuantityZefir.ToString();
            UpdateTotal();
        }

        private void OnDecreaseZefirQuantity(object sender, EventArgs e)
        {
            if (QuantityZefir > 0)
            {
                QuantityZefir--;
                ZefirQuantityLabel.Text = QuantityZefir.ToString();
                UpdateTotal();
            }
        }

        // Эклеры
        private void OnIncreaseEclairsQuantity(object sender, EventArgs e)
        {
            QuantityEclairs++;
            EclairsQuantityLabel.Text = QuantityEclairs.ToString();
            UpdateTotal();
        }

        private void OnDecreaseEclairsQuantity(object sender, EventArgs e)
        {
            if (QuantityEclairs > 0)
            {
                QuantityEclairs--;
                EclairsQuantityLabel.Text = QuantityEclairs.ToString();
                UpdateTotal();
            }
        }

        // Круассаны
        private void OnIncreaseCroissantsQuantity(object sender, EventArgs e)
        {
            QuantityCroissants++;
            CroissantsQuantityLabel.Text = QuantityCroissants.ToString();
            UpdateTotal();
        }

        private void OnDecreaseCroissantsQuantity(object sender, EventArgs e)
        {
            if (QuantityCroissants > 0)
            {
                QuantityCroissants--;
                CroissantsQuantityLabel.Text = QuantityCroissants.ToString();
                UpdateTotal();
            }
        }

        // Метод для обновления общей суммы
        private void UpdateTotal()
        {
            Total = (PriceCakes * QuantityCakes) +
                    (PriceTorts * QuantityTorts) +
                    (PriceMacarons * QuantityMacarons) +
                    (PriceZefir * QuantityZefir) +
                    (PriceEclairs * QuantityEclairs) +
                    (PriceCroissants * QuantityCroissants);

            // Обновляем текст общего счета
            TotalLabel.Text = $"{Total}₽";
        }

        // Обработчик нажатия на кнопку "Оформить заказ"
        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            // Проверяем, есть ли товары в заказе
            if (Total == 0)
            {
                await DisplayAlert("Ошибка", "Ваша корзина пуста. Пожалуйста, добавьте товары в заказ.", "OK");
                return;
            }

            // Логика оформления заказа
            bool confirm = await DisplayAlert("Оформление заказа", "Вы уверены, что хотите оформить заказ?", "Да", "Нет");
            if (confirm)
            {
                // Генерация номера заказа (например, текущая дата и время)
                string orderNumber = GenerateOrderNumber();

                // Здесь добавьте логику оформления заказа (например, отправка данных на сервер)

                // Показать сообщение об успешном оформлении
                await DisplayAlert("Успех", "Ваш заказ успешно оформлен!", "OK");

                // Сброс количеств до 0
                ResetQuantities();

                // Обновление общей суммы
                UpdateTotal();

                // Сохранение номера заказа для использования на CartPage
                Application.Current.Properties["LastOrderNumber"] = orderNumber;
                await Application.Current.SavePropertiesAsync();

                // Навигация на CartPage после успешного оформления заказа
                await Navigation.PushAsync(new CartPage());

                // Закрытие меню, если оно открыто
                await CloseMenuAsync();
            }
        }

        // Метод для генерации номера заказа
        private string GenerateOrderNumber()
        {
            // Пример простой генерации номера заказа
            // В реальном приложении можно использовать более сложную логику или GUID
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        // Метод для сброса количеств товаров до 0
        private void ResetQuantities()
        {
            QuantityCakes = 0;
            CakesQuantityLabel.Text = QuantityCakes.ToString();

            QuantityTorts = 0;
            TortsQuantityLabel.Text = QuantityTorts.ToString();

            QuantityMacarons = 0;
            MacaronsQuantityLabel.Text = QuantityMacarons.ToString();

            QuantityZefir = 0;
            ZefirQuantityLabel.Text = QuantityZefir.ToString();

            QuantityEclairs = 0;
            EclairsQuantityLabel.Text = QuantityEclairs.ToString();

            QuantityCroissants = 0;
            CroissantsQuantityLabel.Text = QuantityCroissants.ToString();
        }

        // Обработчик нажатия на иконку меню (гамбургер)
        private async void OnHamburgerTapped(object sender, EventArgs e)
        {
            // Открыть выдвижное меню
            await OpenMenu();
        }

        // Обработчик нажатия на "Информация о заказе" в меню
        private async void OnCartPageTapped(object sender, EventArgs e)
        {
            // Навигация к странице CartPage
            await Navigation.PushAsync(new CartPage());

            // Закрыть меню
            await CloseMenuAsync();
        }

        // Обработчик нажатия на "О нас" в меню
        private async void OnAboutTapped(object sender, EventArgs e)
        {
            // Навигация к странице "О нас"
            await Navigation.PushAsync(new AboutPage());

            // Закрыть меню
            await CloseMenuAsync();
        }

        // Метод для открытия выдвижного меню с анимацией
        private async System.Threading.Tasks.Task OpenMenu()
        {
            Overlay.IsVisible = true;
            await SideMenu.TranslateTo(0, 0, 250, Easing.CubicIn);
        }

        // Метод для закрытия выдвижного меню с анимацией
        private async System.Threading.Tasks.Task CloseMenuAsync()
        {
            await SideMenu.TranslateTo(-250, 0, 250, Easing.CubicIn);
            Overlay.IsVisible = false;
        }

        // Обработчик нажатия на оверлей для закрытия меню
        private async void CloseMenu(object sender, EventArgs e)
        {
            await CloseMenuAsync();
        }

        // Дополнительный обработчик для кнопки "Оформить заказ" на главной странице (если необходимо)
        private async void OnOrderButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage());
        }
    }
}
