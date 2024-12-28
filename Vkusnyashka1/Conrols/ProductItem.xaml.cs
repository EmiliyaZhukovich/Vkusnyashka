using Xamarin.Forms;

namespace Vkusnyashka1.Controls
{
    public partial class ProductItem : ContentView
    {
        public ProductItem()
        {
            InitializeComponent();
        }

        // Свойство для заголовка
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(ProductItem), default(string));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        // Свойство для изображения
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ProductItem), default(string));

        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        // Свойство для количества
        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(int), typeof(ProductItem), 0);

        public int Quantity
        {
            get => (int)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        // Команда для кнопки "+"
        public static readonly BindableProperty OnAddProperty =
            BindableProperty.Create(nameof(OnAdd), typeof(Command), typeof(ProductItem), null);

        public Command OnAdd
        {
            get => (Command)GetValue(OnAddProperty);
            set => SetValue(OnAddProperty, value);
        }

        // Команда для кнопки "-"
        public static readonly BindableProperty OnRemoveProperty =
            BindableProperty.Create(nameof(OnRemove), typeof(Command), typeof(ProductItem), null);

        public Command OnRemove
        {
            get => (Command)GetValue(OnRemoveProperty);
            set => SetValue(OnRemoveProperty, value);
        }
    }
}
