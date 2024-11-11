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

namespace Unidad_3.Views
{
    /// <summary>
    /// Lógica de interacción para Menú.xaml
    /// </summary>
    public partial class Menú : UserControl
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void btnLíneas_Click(object sender, RoutedEventArgs e)
        {
            Líneas L = new();
            L.ShowDialog();
        }

        private void btnElípses_Click(object sender, RoutedEventArgs e)
        {
            Window1 W = new();
            W.ShowDialog();
        }
    }
}
