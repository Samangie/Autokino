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

            generateField(2, 3);
        }

        private void generateField(int column, int row)
        {
            Grid placegrid = new Grid();

            placegrid.Width = 530;
            placegrid.Height = 320;
            placegrid.Name = "placegrid";
            GridLengthConverter converter = new GridLengthConverter();

            //RowDefinitions für die Zeilen; alle werden gleich hoch
            for (int i = 0; i < row; i++)
            {
                placegrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1,GridUnitType.Star)});
            }


            //ColumnDefinitions für die Spalten; alle werden gleich breit
            for (int j = 0; j < column; j++)
            {
                placegrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            }

            //Grid als Child-Element des Canvas ("parkflaeche") definieren
            grid.Children.Add(placegrid);
            int counter = 1;
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < column; j++)
                {
                    int currentColumn = j + 1;
                    int currentRow = i + 1;

                    Button field = new Button();
                    field.Click += showDetail;
                    field.Content = currentRow + ":" + currentColumn;
                    placegrid.Children.Add(field);
                    Grid.SetRow(field, i);
                    Grid.SetColumn(field, j);

                    Platz place = new Platz();
                    place.ID = counter;
                    place.Reihe = Convert.ToInt16(currentRow);
                    place.Position = Convert.ToInt16(currentColumn);
                    place.Film = Bibliothek.Film_nach_ID(1);
                    Bibliothek.Platz_Neu(place);
                    counter++;

                }

            }

        }
        private void showDetail(object sender, EventArgs e)
        {
            String[] btnContent = (sender as Button).Content.ToString().Split(':');
            int column = Convert.ToInt16(btnContent[0]);
            int row = Convert.ToInt16(btnContent[1]);

            Detailview detail = new Detailview(column, row);
            detail.HorizontalAlignment = HorizontalAlignment.Left;
            detail.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Clear();
            grid.Children.Add(detail);
        }
    }
}
