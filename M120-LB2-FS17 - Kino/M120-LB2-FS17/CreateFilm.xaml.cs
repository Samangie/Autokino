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
    /// Interaktionslogik für CreateFilm.xaml
    /// </summary>
    public partial class CreateFilm : UserControl
    {
        public CreateFilm()
        {
            InitializeComponent();
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            String filmname = tbfilm.Text;

            if (checkInput(filmname))
            {
                Film film = new Film();
                film.Name = filmname;
                Bibliothek.Film_Neu(film);

                MessageBox.Show("Film wurde hinzugefügt.");
                tbfilm.Clear();

            }
        }

        private bool checkInput(String value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show("Bitte füllen Sie das Feld aus!");
                return false;
            }
            return true;

        }
    }
}
