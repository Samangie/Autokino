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
        public int column { get; set; }
        public int row { get; set; }
        public KinoConfig()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (checkInput(txtColumn.Text) && checkInput(txtRow.Text))
            {
                column = Convert.ToInt16(txtColumn.Text);
                row = Convert.ToInt16(txtRow.Text);
                Menu menu = new Menu(column, row);
                menu.HorizontalAlignment = HorizontalAlignment.Left;
                menu.VerticalAlignment = VerticalAlignment.Top;
                kinoinhalt.Children.Clear();
                kinoinhalt.Children.Add(menu);
            }
            
        }
         
        private bool checkInput(String value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show("Bitte füllen Sie die Felder aus!");
                return false;
            }
            try
            {
                Convert.ToInt16(value);
            }catch
            {
                MessageBox.Show("Bitte verwenden Sie Zahlen!");
                return false;
            }
            return true;
            
        }
    }
}
