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

        public Main()
        {
            InitializeComponent();

            items.Add(new Item("Шкаф", 20000, "E:\\3 курс\\Ощепков\\Практические работы\\Практическая работа №19\\FurnitureStore_Klimov\\Images\\Wardrobe.jpg"));

            LoadItems();
        }

        public void LoadItems()
        {
            parent.Children.Clear();

            foreach (Item item in items)
            {
                parent.Children.Add(new Elements.Item(item));
            }
        }
    }
}
