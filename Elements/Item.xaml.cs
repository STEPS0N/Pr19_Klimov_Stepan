using FurnitureStore_Klimov.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FurnitureStore_Klimov.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        List<Item> items = new List<Item>();

        MainWindow mainWindow;

        public Item(Classes.Item item)
        {
            InitializeComponent();

            if (item != null)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/Image/" + item.src))
                    Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Image/" + item.src));
                else
                    Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Image/nophoto.png"));

                price.Content = item.price + " р.";
                name.Content = item.name;
            }
        }

        private void QuantMinus(object sender, RoutedEventArgs e)
        {
            if (count.Text != "")
            {
                if (int.Parse(count.Text) > 0)
                {
                    count.Text = (int.Parse(count.Text) - 1).ToString();

                }
            }
        }

        private void QuantPlus(object sender, RoutedEventArgs e)
        {
            if (count.Text != "")
            {
                if (int.Parse(count.Text) < 15)
                {
                    count.Text = (int.Parse(count.Text) + 1).ToString();
                }
            }
        }

        private void ToCart(object sender, RoutedEventArgs e)
        {
            if (count.Text != "" && int.Parse(count.Text) > 0)
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    if (mainWindow.frame.Content is Main mainPage)
                    {
                        for (int i = 0; i < int.Parse(count.Text); i++)
                        {
                            mainPage.cartItems.Add(new Classes.Item
                            {
                                name = name.Content.ToString(),
                                price = int.Parse(price.Content.ToString().Replace(" р.", ""))
                            });
                        }

                        mainPage.UpdateCart();
                        count.Text = "0";
                    }
                }
            }
        }
    }
}
