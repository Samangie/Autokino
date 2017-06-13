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
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        int column, row;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(int column, int row)
        {
            this.column = column;
            this.row = row;
            InitializeComponent();
            loadOverview();
        

        }

        private void showList_Click(object sender, RoutedEventArgs e)
        {
            Listview liste = new Listview();
            liste.HorizontalAlignment = HorizontalAlignment.Left;
            liste.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(liste);
        }

        private void showOverview_Click(object sender, RoutedEventArgs e)
        {
            loadOverview();
        }

        private void loadOverview()
        {
            Overview overview = new Overview(column, row);
            overview.HorizontalAlignment = HorizontalAlignment.Left;
            overview.VerticalAlignment = VerticalAlignment.Top;
            inhalt.Children.Clear();
            inhalt.Children.Add(overview);
        }
    }
}
