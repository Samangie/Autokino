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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120_LB2_FS17
{
    /// <summary>
    /// Interaktionslogik für KinoConfig.xaml
    /// </summary>
    public partial class KinoConfig : UserControl
    {
        public KinoConfig()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            int column = Convert.ToInt16(txtColumn.Text);
            int row = Convert.ToInt16(txtRow.Text);
            Menu menu = new Menu(column, row);
            menu.HorizontalAlignment = HorizontalAlignment.Left;
            menu.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(menu);
        }
    }
}
