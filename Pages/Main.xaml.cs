using FurnitureStore_Klimov.Classes;
using System.Windows.Controls;

namespace FurnitureStore_Klimov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public List<Item> items = new List<Item>();
        public List<Item> cartItems = new List<Item>();

        public MainWindow mainWindow;

        public Main(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            items.Add(new Item("Шкаф", 20000, "wardrobe.jpg"));
            items.Add(new Item("Кровать", 72000, "bed.jpg"));
            items.Add(new Item("Комод", 8000, "chest.jpg"));
            items.Add(new Item("Игровое кресло", 15000, "gaming.png"));
            items.Add(new Item("Стол", 10000, "table.png"));
            items.Add(new Item("Тумба", 25000, "pedestal.png"));

            LoadItems();
            UpdateCart();
        }

        public void LoadItems()
        {
            parent.Children.Clear();

            foreach (Item item in items)
            {
                parent.Children.Add(new Elements.Item(item));
            }
        }

        public void UpdateCart()
        {
            if (cart != null)
            {
                cart.Content = $"Корзина ({cartItems.Count})";
            }
        }

        public void ClearCart()
        {
            cartItems.Clear();
            UpdateCart();
        }

        private void Cart(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.OpenPage(new Shopping());
        }
    }
}
