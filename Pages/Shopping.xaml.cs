using FurnitureStore_Klimov.Elements;
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

namespace FurnitureStore_Klimov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Shopping.xaml
    /// </summary>
    public partial class Shopping : Page
    {
        private List<Classes.Item> cartItems;

        public Shopping()
        {
            InitializeComponent();

            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                if (mainWindow.frame.Content is Main mainPage)
                {
                    cartItems = mainPage.cartItems;
                    CreateProduct();
                }
            }
        }

        private void Pay(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Оплата выполнена! Спасибо за покупку!");

            cartItems.Clear();

            NavigationService.GoBack();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CreateProduct()
        {
            var bc = new BrushConverter();
            parent.Children.Clear();

            if (cartItems == null || cartItems.Count == 0)
            {
                Grid orderGrid = new Grid();
                orderGrid.Height = 75;
                orderGrid.Background = (Brush)bc.ConvertFrom("#FFECECEC");
                orderGrid.Margin = new Thickness(10);

                orderGrid.Children.Add(new TextBlock
                {
                    Text = "Корзина пуста",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                });

                parent.Children.Add(orderGrid);
                return;
            }

            int totalCost = 0;

            foreach (var item in cartItems)
            {
                totalCost += item.price;

                Grid orderGrid = new Grid();
                orderGrid.Height = 40;
                orderGrid.Background = (Brush)bc.ConvertFrom("#FFECECEC");
                orderGrid.Margin = new Thickness(10, 5, 10, 5);

                TextBlock nameText = new TextBlock
                {
                    Text = item.name,
                    FontSize = 14,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                TextBlock priceText = new TextBlock
                {
                    Text = $"{item.price} р.",
                    FontSize = 14,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 10, 0)
                };

                orderGrid.Children.Add(nameText);
                orderGrid.Children.Add(priceText);
                parent.Children.Add(orderGrid);
            }

            Grid totalGrid = new Grid();
            totalGrid.Height = 50;
            totalGrid.Background = (Brush)bc.ConvertFrom("#FFD0D0D0");
            totalGrid.Margin = new Thickness(10, 10, 10, 10);

            totalGrid.Children.Add(new TextBlock
            {
                Text = $"Общая стоимость: {totalCost} р.",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });

            parent.Children.Add(totalGrid);
        }
    }
}
