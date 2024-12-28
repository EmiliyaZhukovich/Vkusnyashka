using Xamarin.Forms;

namespace Vkusnyashka1.Pages
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            LoadOrderStatus();
        }

        private void LoadOrderStatus()
        {
            // Здесь можно добавить логику для загрузки реального статуса заказа
            // Например, получить последний оформленный заказ из базы данных

            // Для примера установим статичный номер заказа и статус
            OrderNumberLabel.Text = "Номер заказа: 001";
            OrderStatusLabel.Text = "ЗАКАЗ ОФОРМЛЕН";
        }
    }
}
