using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VirtualBankLib;

namespace VirtualBanker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CurrencyInputModel> notationsList = new List<CurrencyInputModel>() {
            new CurrencyInputModel() { Name = "25 Cent", Value=0.25M },
            new CurrencyInputModel() { Name = "1 Dollar", Value=1 },
            new CurrencyInputModel() { Name = "2 Dollars", Value=2 },
            new CurrencyInputModel() { Name = "10 Dollars", Value=10 },
            new CurrencyInputModel() { Name = "25 Dollars", Value=25 },
        };

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = notationsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var holder = new CurrencyHolder(notationsList.Select(f => f.GetNotation()).ToList());
            var value = inputTextBox.Text;

            IChangeSolver solver = null;
            if (recursiveRadioButton.IsChecked.GetValueOrDefault(false)) solver = new RecursiveSolver();
            if (iterativeRadioButton.IsChecked.GetValueOrDefault(false)) solver = new IterativeSolver();

            if (solver != null && decimal.TryParse(value, out decimal amount)) {
                solver.FindReturnFor(holder, amount);
                notationsList.ForEach(f => f.Update());
                dataGrid.Items.Refresh();
                changeLabel.Content = $"Amount left: {amount - holder.SumTaken()}";
            } else
            {

            }
        }
    }
}
