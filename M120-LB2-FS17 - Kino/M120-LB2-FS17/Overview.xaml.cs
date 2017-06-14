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
using System.IO;

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

        }
        public Overview(int column, int row)
        {
            InitializeComponent();
            generateField(column, row);

        }

        private void generateField(int column, int row)
        {
            Grid placegrid = new Grid();
 
            placegrid.Width = 530;
            placegrid.Height = 290;
            placegrid.Name = "placegrid";
            GridLengthConverter converter = new GridLengthConverter();

            for (int i = 0; i < row; i++)
            {
                placegrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1,GridUnitType.Star)});
            }

            for (int j = 0; j < column; j++)
            {
                placegrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            }

            grid.Children.Add(placegrid);
            int counter = 1;
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < column; j++)
                {
                    int counterPlatz = 0;
                    int currentColumn = j + 1;
                    int currentRow = i + 1;

                    Button field = new Button();
                    field.Click += showDetail;
                    field.Content = currentColumn + ":" + currentRow;
                    placegrid.Children.Add(field);
                    Grid.SetRow(field, i);
                    Grid.SetColumn(field, j);

                    try
                    {
                        foreach (Platz Platz in Bibliothek.Platz_Alle())
                        {
                            counterPlatz++;
                        }
                    }
                    catch
                    {
                        counterPlatz = 0;
                    }
                    if (counterPlatz <= (column * row))
                    {
                        Platz place = new Platz();
                        place.ID = counter;
                        place.Reihe = Convert.ToInt16(currentRow);
                        place.Position = Convert.ToInt16(currentColumn);
                        place.Film = Bibliothek.Film_nach_ID(1);
                        Bibliothek.Platz_Neu(place);
                        counter++;
                    }

                    if(existRes(currentRow, currentColumn))
                    {
                        field.Background = Brushes.PaleVioletRed;
                    }else
                    {
                        field.Background = Brushes.LightGreen;
                    }
                        

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

        public bool existRes(int currentRow, int currenColumn)
        {
            Platz place = Bibliothek.Platz_nach_PosRes(currenColumn, currentRow);

            Reservation reservation = Bibliothek.Reservation_nach_Platz(place);

            if (reservation == null)
            {
                return false;
            }
            return true;
        }
    }
}
