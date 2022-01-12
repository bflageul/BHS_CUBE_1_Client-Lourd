using Microsoft.EntityFrameworkCore;
using Negosud_RichClient.Data;
using Negosud_RichClient.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Negosud_RichClient
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private readonly NegosudDbContext context;
        Product NewProduct = new();
        Product selectedProduct = new();


        public ProductWindow(NegosudDbContext context)
        {
            InitializeComponent();
            this.context = context;
            GetProducts();
            NewProductGrid.DataContext = NewProduct;
        }


        private void GetProducts()
        {
            ProductDG.ItemsSource = context.Products.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            context.Products.Add(NewProduct);
            context.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            NewProductGrid.DataContext = NewProduct;
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedProduct);
            context.SaveChanges();
            GetProducts();
        }

        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }

        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Product;
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            GetProducts();
        }

        private void BtnMenu(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new();
            window.Show();
            this.Close();
        }
    }
}
