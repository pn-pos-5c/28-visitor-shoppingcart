using ElementLib;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace VisitorShoppingCart
{
    public partial class MainWindow : Window
    {
        private List<Good> cart = new();
        private List<Good> bag = new();

        public MainWindow()
        {
            InitializeComponent();

            lstCart.ItemsSource = cart;
            lstBag.ItemsSource = bag;
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddClicked(object sender, RoutedEventArgs e)
        {
            string category = "";
            foreach (var cat in panCategories.Children)
            {
                var button = (RadioButton)cat;
                if ((bool)button.IsChecked) category = button.Content.ToString();
            }

            string name = txtName.Text;
            double pricePerUnit = double.Parse(txtPricePerUnit.Text, CultureInfo.InvariantCulture);
            int units = (int)sldUnits.Value;
            int weight = (int)sldWeight.Value;
            bool cartChecked = rdoCart.IsChecked ?? false;

            var good = GoodFactory.GetGood(category);
            good.Name = name;
            good.Weight = weight;
            good.NrUnits = units;
            good.PricePerUnit = pricePerUnit;

            if (cartChecked)
            {
                cart.Add(good);
                lstCart.Items.Refresh();
            }
            else
            {
                bag.Add(good);
                lstBag.Items.Refresh();
            }
        }

        private void PanButtons_Click(object sender, RoutedEventArgs e)
        {
            var goods = cart.Concat(bag).ToList();

            switch ((e.OriginalSource as Button).Name)
            {
                case "btnAlc":
                    MessageBox.Show(Visit(new AlcVisitor(), goods));
                    break;
                case "btnCal":
                    MessageBox.Show(Visit(new CaloryVisitor(), goods));
                    break;
                case "btnCash":
                    MessageBox.Show(Visit(new CashVisitor(), goods));
                    break;
                case "btnHtml":
                    MessageBox.Show(GetHtml(goods));
                    break;
                case "btnScale":
                    MessageBox.Show(Visit(new ScaleVisitor(), goods));
                    break;
            }
        }

        private static string Visit(IVisitor visitor, List<Good> goods)
        {
            foreach (var good in goods) good.Accept(visitor);
            return visitor.ResultString;
        }

        private string GetHtml(List<Good> goods)
        {
            var visitor = new HtmlVisitor();
            var html = "<table><tr><th>Produkt</th><th>Preis</th><th>Gewicht</th><th>Info</th></tr>";

            foreach (var good in goods)
            {
                good.Accept(visitor);
                html += visitor.ResultString;
            }
            return html += "</table>";
        }
    }
}
