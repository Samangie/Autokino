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
    /// Interaktionslogik für Overview.xaml
    /// </summary>
    public partial class Overview : UserControl
    {
        public Overview()
        {
            InitializeComponent();

            generateField(2, 2);
        }

        private void generateField(int column, int row)
        {
            for(int i = 0; i < column; i++)
            {
                DataGridTextColumn newColumn = new DataGridTextColumn();
                newColumn.Header = Convert.ToString(i);
                newColumn.Binding = new Binding(Convert.ToString(i));
                DataGridOverview.Columns.Add(newColumn);

            }
            for(int j = 0; j < row; j++)
            {
                DataGridOverview.Items.Add(new Item{ 1 = "1:1" , Start = "2012, 8, 15", Finich = "2012, 9, 15" });
            }
        }
    }
}
